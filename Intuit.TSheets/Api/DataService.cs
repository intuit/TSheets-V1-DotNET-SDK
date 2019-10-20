// *******************************************************************************
// <copyright file="DataService.cs" company="Intuit">
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

namespace Intuit.TSheets.Api
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.Pipelines;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    public partial class DataService : IDataService
    {
        private readonly IRestClient restClient;
        private readonly ILogger logger;
        private readonly IPipelineFactory pipelineFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="authToken">
        /// The authentication token.
        /// </param>
        public DataService(string authToken)
            : this(new DataServiceContext(authToken), new RetrySettings(), NullLogger.Instance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="authToken">
        /// The authentication token.
        /// </param>
        /// <param name="logger">
        /// An instance of a <see cref="ILogger"/> class.
        /// </param>
        public DataService(string authToken, ILogger logger)
            : this(new DataServiceContext(authToken), new RetrySettings(), logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="authToken">
        /// The authentication token.
        /// </param>
        /// <param name="retrySettings">
        /// An instance of <see cref="RetrySettings"/> class, to define retry behavior for transient faults.
        /// </param> 
        /// <param name="logger">
        /// An instance of a <see cref="ILogger"/> class.
        /// </param>
        public DataService(string authToken, RetrySettings retrySettings, ILogger logger)
            : this(new DataServiceContext(authToken), retrySettings, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="context">
        /// A <see cref="DataServiceContext"/> object for establishing a connection to the TSheets API.
        /// </param>
        public DataService(DataServiceContext context)
            : this(context, new RetrySettings(), NullLogger.Instance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="context">
        /// A <see cref="DataServiceContext"/> object for establishing a connection to the TSheets API.
        /// </param>
        /// <param name="logger">
        /// An instance of a <see cref="ILogger"/> class.
        /// </param>
        public DataService(DataServiceContext context, ILogger logger)
            : this(context, new RetrySettings(), logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="context">
        /// A <see cref="DataServiceContext"/> object for establishing a connection to the TSheets API.
        /// </param>
        /// <param name="retrySettings">
        /// An instance of <see cref="RetrySettings"/> class, to define retry behavior for transient faults.
        /// </param>
        /// <param name="logger">
        /// An instance of a <see cref="ILogger"/> class.
        /// </param> 
        public DataService(DataServiceContext context, RetrySettings retrySettings, ILogger logger)
        {
            this.restClient = new ResilientRestClient(context, retrySettings, logger);

            this.logger = logger;
            this.pipelineFactory = PipelineFactory.Instance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <remarks>
        /// Internal unit test constructor.
        /// </remarks>
        /// <param name="context">
        /// A <see cref="DataServiceContext"/> object for establishing a connection to the TSheets API.
        /// </param>
        /// <param name="pipelineFactory">
        /// An instance of <see cref="IPipelineFactory"/> request processing class.
        /// </param>
        /// <param name="logger">
        /// An instance of a <see cref="ILogger"/> class.
        /// </param>
        internal DataService(DataServiceContext context, IPipelineFactory pipelineFactory, ILogger logger)
        {
            this.restClient = new ResilientRestClient(context, new RetrySettings(), logger);

            this.logger = logger;
            this.pipelineFactory = pipelineFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <remarks>
        /// Internal unit test constructor.
        /// </remarks>
        /// <param name="pipelineFactory">
        /// A <see cref="IPipelineFactory"/> instance for generating a request pipeline.
        /// </param>
        /// <param name="restClient">
        /// An instance of <see cref="IRestClient"/> rest client class.
        /// </param>
        /// <param name="logger">
        /// An instance of a <see cref="ILogger"/> class.
        /// </param>
        internal DataService(IPipelineFactory pipelineFactory, IRestClient restClient, ILogger logger)
        {
            this.pipelineFactory = pipelineFactory;
            this.restClient = restClient;
            this.logger = logger;
        }

        /// <summary>
        /// Asynchronously execute a request pipeline call to perform an API operation.
        /// </summary>
        /// <typeparam name="T">The entity data type.</typeparam>
        /// <param name="context">Vehicle of state, <see cref="PipelineContext{T}"/></param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        internal async Task ExecuteOperationAsync<T>(
            PipelineContext<T> context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                context.RestClient = this.restClient;

                IPipeline requestPipeline = this.pipelineFactory.GetPipeline(context);
                await requestPipeline.ProcessAsync(context, this.logger, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                LogException(context, ex);

                if (ex is ApiException)
                {
                    throw;
                }

                throw new FatalClientException(ex);
            }
        }

        private void LogException<T>(PipelineContext<T> context, Exception ex)
        {
            string methodType = context.MethodType.ToString().ToUpperInvariant();

            if (ex is ApiException apiEx)
            {
                logger?.LogError(
                    context.LogContext.EventId,
                    "{CorrelationId} {HttpMethod} ERROR {HttpCode} ({ErrorText}) {ErrorMessage}",
                    context.LogContext.CorrelationId,
                    methodType,
                    apiEx.ErrorCode,
                    apiEx.ErrorText,
                    apiEx.Message);

                if (apiEx is MultiStatusException<T> multiStatusException)
                {
                    foreach (ErrorItem<T> errorItem in multiStatusException.FailureResults)
                    {
                        logger?.LogError(
                            context.LogContext.EventId,
                            "{CorrelationId} {HttpMethod} ERROR {HttpCode} index:{ErrorIndex} id:{ErrorId} code:{ErrorCode} ({ErrorMessage}) {ErrorExtra}.",
                            context.LogContext.CorrelationId,
                            methodType,
                            apiEx.ErrorCode,
                            errorItem.Index,
                            errorItem.Id,
                            errorItem.Code,
                            errorItem.Message,
                            errorItem.Extra);
                    }
                }
                else
                {
                    logger?.LogDebug(
                        context.LogContext.EventId,
                        apiEx,
                        "{CorrelationId} {Processor}::{Method}(): {HttpMethod} ERROR",
                        context.LogContext.CorrelationId,
                        nameof(DataService),
                        nameof(ExecuteOperationAsync),
                        methodType);
                }
            }
            else
            {
                logger?.LogCritical(
                    context.LogContext.EventId,
                    ex,
                    "{CorrelationId} {Processor}::{Method}(): {HttpMethod} ERROR",
                        context.LogContext.CorrelationId,
                        nameof(DataService),
                        nameof(ExecuteOperationAsync),
                        methodType);
            }
        }
    }
}
