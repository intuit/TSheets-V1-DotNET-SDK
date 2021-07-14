// *******************************************************************************
// <copyright file="ResilientRestClient.cs" company="Intuit">
// Copyright (c) 2019 Intuit
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
// *******************************************************************************

namespace Intuit.TSheets.Client.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;
    using Polly;
    using Polly.Retry;

    /// <summary>
    /// An HTTP Client to the TSheets Rest API that seamlessly retries calls when
    /// transient network errors are encountered.
    /// </summary>
    internal class ResilientRestClient : IRestClient
    {
        private const string LogContextKey = "LogContext";
        private const string MaxRetryCount = "MaxRetries";
        private const string RetryNumberKey = "RetryNumber";

        private readonly IRestClient restClient;
        private readonly RetrySettings retrySettings;
        private readonly AsyncRetryPolicy retryPolicy;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResilientRestClient"/> class.
        /// </summary>
        /// <param name="context">
        /// Container for data needed to establish a connection to the TSheets API, <see cref="DataServiceContext"/>
        /// </param>
        /// <param name="retrySettings">
        /// Settings for controlling retry behavior, <see cref="RetrySettings"/>.
        /// </param>
        /// <param name="logger">
        /// Logging provider, an instance of <see cref="ILogger"/>.
        /// </param>
        internal ResilientRestClient(
            DataServiceContext context,
            RetrySettings retrySettings,
            ILogger logger)
            : this(retrySettings, new RestClient(context, logger), logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResilientRestClient"/> class.
        /// </summary>
        /// <remarks>
        /// Unit testing constructor.
        /// </remarks>
        /// <param name="retrySettings">
        /// Settings for controlling retry behavior, <see cref="RetrySettings"/>.
        /// </param>
        /// <param name="restClient">
        /// The underlying rest client of which this class is composed, a <see cref="IRestClient"/> instance.
        /// </param>
        /// <param name="logger">
        /// Logging provider, an instance of <see cref="ILogger"/>.
        /// </param>
        internal ResilientRestClient(
            RetrySettings retrySettings,
            IRestClient restClient,
            ILogger logger)
        {
            this.retrySettings = retrySettings;
            this.restClient = restClient;
            this.retryPolicy = GetPolicy(retrySettings, logger);
        }

        /// <summary>
        /// Creates entities in TSheets via an HTTP POST call to the API endpoint, with retries.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="jsonData">The content to be sent in the body of the request.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<string> CreateAsync(
            EndpointName endpointName,
            string jsonData,
            LogContext logContext,
            CancellationToken cancellationToken)
        {
            return await ExecutePolicyAsync(
                logContext,
                () => this.restClient.CreateAsync(
                    endpointName,
                    jsonData,
                    logContext,
                    cancellationToken)).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves entities from TSheets via an HTTP GET call to the API endpoint, with retries.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="filters">The key-value pairs to be sent as URL request parameters.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<string> GetAsync(
            EndpointName endpointName,
            Dictionary<string, string> filters,
            LogContext logContext,
            CancellationToken cancellationToken)
        {
            return await ExecutePolicyAsync(
                logContext,
                () => this.restClient.GetAsync(
                    endpointName,
                    filters,
                    logContext,
                    cancellationToken)).ConfigureAwait(false);
        }

        /// <summary>
        /// Downloads binary data from TSheets via an HTTP POST call to the API endpoint, with retries.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="filters">The key-value pairs to be sent as URL request parameters.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<byte[]> DownloadAsync(
            EndpointName endpointName,
            Dictionary<string, string> filters,
            LogContext logContext,
            CancellationToken cancellationToken)
        {
            return await ExecutePolicyAsync(
                    logContext,
                    () => this.restClient.DownloadAsync(endpointName, filters, logContext, cancellationToken))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Updates entities in TSheets via an HTTP PUT call to the API endpoint, with retries.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="jsonData">The content to be sent in the body of the request.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<string> UpdateAsync(
            EndpointName endpointName,
            string jsonData,
            LogContext logContext,
            CancellationToken cancellationToken)
        {
            return await ExecutePolicyAsync(
                    logContext,
                    () => this.restClient.UpdateAsync(endpointName, jsonData, logContext, cancellationToken))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Removes entities in TSheets via an HTTP DELETE call to the API endpoint, with retries.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="ids">The ids of the entities to be deleted.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<string> DeleteAsync(
            EndpointName endpointName,
            IEnumerable<long> ids,
            LogContext logContext,
            CancellationToken cancellationToken)
        {
            return await ExecutePolicyAsync(
                    logContext,
                    () => this.restClient.DeleteAsync(endpointName, ids, logContext, cancellationToken))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The retry callback method.
        /// </summary>
        /// <param name="exception">The exception encountered during the call.</param>
        /// <param name="timeSpan">The time to wait before retrying the call.</param>
        /// <param name="context">Contextual information about the retry.</param>
        /// <param name="logger">An instance of <see cref="ILogger"/>, for logging purposes.</param>
        internal static void OnRetryCallback(
            Exception exception,
            TimeSpan timeSpan,
            Context context,
            ILogger logger)
        {
            var logContext = (LogContext)context[LogContextKey];
            int totalRetries = (int)context[MaxRetryCount];
            int retryNumber = (int)context[RetryNumberKey];

            // increment the retry number for next time around.
            context[RetryNumberKey] = retryNumber + 1;

            logger?.LogWarning(
                logContext.EventId,
                "{CorrelationId} Retry {RetryNumber}/{TotalRetries} in {WaitTimeInMs}ms. {ErrorMessage}",
                logContext.CorrelationId,
                retryNumber,
                totalRetries,
                timeSpan.TotalMilliseconds,
                exception.Message);
        }

        private static AsyncRetryPolicy GetPolicy(
            RetrySettings settings,
            ILogger logger)
        {
            var policyBuilder = Policy
                .Handle<ApiException>(ex => settings.RetryTypes.Any(t => ex.GetType() == t));

            return policyBuilder
                .WaitAndRetryAsync(
                    settings.MaxRetryCount,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(retryAttempt, settings.Exponent) * settings.Multiplier),
                    (exception, timespan, context) => OnRetryCallback(exception, timespan, context, logger));
        }

        private async Task<T> ExecutePolicyAsync<T>(
            LogContext logContext,
            Func<Task<T>> action)
        {
            // Set context state, for access in the retry callback method.
            var context = new Context
            {
                { LogContextKey, logContext },
                { MaxRetryCount, this.retrySettings.MaxRetryCount },
                { RetryNumberKey, 1 }
            };

            PolicyResult<T> policyResult = await this.retryPolicy.ExecuteAndCaptureAsync(
                async ctx => await action().ConfigureAwait(false),
                context).ConfigureAwait(false);

            // At this point, all retries have been exhausted.  If error persists, throw.
            if (policyResult.Outcome == OutcomeType.Failure)
            {
                throw policyResult.FinalException;
            }

            return policyResult.Result;
        }
    }
}