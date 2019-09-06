// *******************************************************************************
// <copyright file="RestClient.cs" company="Intuit">
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
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Extensions;
    using Intuit.TSheets.Client.Utilities;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// An HTTP Client to the TSheets Rest API
    /// </summary>
    internal class RestClient : IRestClient
    {
        private const string ProductName = "TSheets-V1-DotNET-SDK";
        private const string ProductVersion = "2.0";
        
        private readonly HttpClient httpClient;
        private readonly DataServiceContext context;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class.
        /// </summary>
        /// <param name="context">
        /// Container for data needed to establish a connection to the TSheets API, <see cref="DataServiceContext"/>
        /// </param>
        /// <param name="logger">
        /// Logging provider, an instance of <see cref="ILogger"/>.
        /// </param>
        public RestClient(DataServiceContext context, ILogger logger)
            : this(context, new HttpClient(), logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class.
        /// </summary>
        /// <remarks>
        /// Internal unit test constructor for injection of mock HttpClient.
        /// </remarks>
        /// <param name="context">
        /// Container for data needed to establish a connection to the TSheets API, <see cref="DataServiceContext"/>
        /// </param>
        /// <param name="httpClient">
        /// An instance of an httpClient.
        /// </param>
        /// <param name="logger">
        /// Logging provider, an instance of <see cref="ILogger"/>.
        /// </param>
        internal RestClient(DataServiceContext context, HttpClient httpClient, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
            this.httpClient = httpClient;

            this.httpClient.BaseAddress = context.ConnectionInfo.BaseUri;

            // Set the User Agent
            string productVersion = AssemblyUtil.GetProductVersion();
            var userAgent = new ProductInfoHeaderValue(ProductName, productVersion);
            this.httpClient.DefaultRequestHeaders.UserAgent.Clear();
            this.httpClient.DefaultRequestHeaders.UserAgent.Add(userAgent);

            // Set the media type headers
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            // Set the authorization header
            string accessToken = context.AuthProvider.GetAccessToken();
            this.httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            // Set the managed client id, if requested.
            if (context.ManagedClientId.HasValue)
            {
                this.httpClient.DefaultRequestHeaders.Add("vnd.tsheets.ManagedClientId", context.ManagedClientId.Value.ToString());
            }
        }

        /// <summary>
        /// Creates entities in TSheets via an HTTP POST call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="requestData">The content to be sent in the body of the request.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<string> CreateAsync(
            EndpointName endpointName,
            string requestData,
            LogContext logContext)
        {
            Uri requestUri = CreateRequestUri(endpointName);

            LogMethodCall(MethodType.Post, requestUri, logContext, requestData);

            HttpContent content = new StringContent(requestData, Encoding.UTF8);
            HttpResponseMessage response = await this.httpClient.PostAsync(requestUri, content).ConfigureAwait(false);

            return ProcessResponse(response, logContext, MethodType.Post);
        }

        /// <summary>
        /// Retrieves entities from TSheets via an HTTP GET call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="filters">The key-value pairs to be sent as URL request parameters.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<string> GetAsync(EndpointName endpointName, Dictionary<string, string> filters, LogContext logContext)
        {
            Uri requestUri = CreateRequestUri(endpointName, filters);

            LogMethodCall(MethodType.Get, requestUri, logContext);

            HttpResponseMessage response = await this.httpClient.GetAsync(requestUri).ConfigureAwait(false);

            return ProcessResponse(response, logContext, MethodType.Get);
        }

        /// <summary>
        /// Updates entities in TSheets via an HTTP PUT call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="requestData">The content to be sent in the body of the request.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<string> UpdateAsync(EndpointName endpointName, string requestData, LogContext logContext)
        {
            Uri requestUri = CreateRequestUri(endpointName);

            LogMethodCall(MethodType.Put, requestUri, logContext, requestData);

            HttpContent content = new StringContent(requestData, Encoding.UTF8);
            HttpResponseMessage response = await this.httpClient.PutAsync(requestUri, content).ConfigureAwait(false);

            return ProcessResponse(response, logContext, MethodType.Put);
        }

        /// <summary>
        /// Removes entities in TSheets via an HTTP DELETE call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="ids">The ids of the entities to be deleted.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<string> DeleteAsync(EndpointName endpointName, IEnumerable<int> ids, LogContext logContext)
        {
            var filter = new Dictionary<string, string>
            {
                { "ids", string.Join(",", ids) }
            };

            Uri requestUri = CreateRequestUri(endpointName, filter);

            LogMethodCall(MethodType.Delete, requestUri, logContext);

            HttpResponseMessage response = await this.httpClient.DeleteAsync(requestUri).ConfigureAwait(false);

            return ProcessResponse(response, logContext, MethodType.Delete);
        }

        /// <summary>
        /// Downloads binary data from TSheets via an HTTP POST call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="filters">The key-value pairs to be sent as URL request parameters.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <returns>The serialized response of the API method call.</returns>
        public async Task<byte[]> DownloadAsync(
            EndpointName endpointName,
            Dictionary<string, string> filters,
            LogContext logContext)
        {
            Uri requestUri = CreateRequestUri(endpointName, filters);

            LogMethodCall(MethodType.Get, requestUri, logContext);

            HttpResponseMessage response = await this.httpClient.GetAsync(requestUri).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                HandleFailure(response, logContext, MethodType.Get);
            }

            string httpMethod = MethodType.Get.ToString().ToUpperInvariant();
            logger?.LogInformation(
                logContext.EventId,
                "{CorrelationId} {HttpMethod} Response {HttpCode} {HttpReason}",
                logContext.CorrelationId,
                httpMethod,
                (int)response.StatusCode,
                response.ReasonPhrase);

            byte[] responseContent = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            logger?.LogDebug(
                logContext.EventId,
                "{CorrelationId} {HttpMethod} Response: {ResponseLength} bytes.",
                logContext.CorrelationId,
                httpMethod,
                responseContent.Length);

            return responseContent;
        }

        private Uri CreateRequestUri(EndpointName endpointName, Dictionary<string, string> filters = null)
        {
            string endpointSegment = EndpointMapper.GetEndpoint(endpointName);
            Uri fullUri = new Uri($"{this.context.ConnectionInfo.BaseUri}/{endpointSegment}");

            return filters?.Count > 0
                ? new UriBuilder(fullUri)
                {
                    Query = filters.ToUrlQueryString()
                }.Uri
                : fullUri;
        }

        private void LogMethodCall(MethodType methodType, Uri requestUri, LogContext logContext, string requestData = null)
        {
            string httpMethod = methodType.ToString().ToUpperInvariant();

            logger?.LogInformation(
                logContext.EventId,
                "{CorrelationId} {HttpMethod} Request {RequestUri}",
                logContext.CorrelationId,
                httpMethod,
                requestUri);

            if (!string.IsNullOrWhiteSpace(requestData))
            {
                logger?.LogDebug(
                    logContext.EventId,
                    "{CorrelationId} {HttpMethod} Request Body\n{RequestBody}",
                    logContext.CorrelationId,
                    httpMethod,
                    requestData);
            }
        }

        private void LogPostMethodCall(MethodType methodType, LogContext logContext, HttpResponseMessage response, string responseContent)
        {
            string httpMethod = methodType.ToString().ToUpperInvariant();

            logger?.LogInformation(
                logContext.EventId,
                "{CorrelationId} {HttpMethod} Response {HttpCode} {HttpReason}",
                logContext.CorrelationId,
                httpMethod,
                (int)response.StatusCode,
                response.ReasonPhrase);

            logger?.LogDebug(
                logContext.EventId,
                "{CorrelationId} {HttpMethod} Response Body\n{ResponseBody}",
                logContext.CorrelationId,
                httpMethod,
                responseContent);
        }

        private string ProcessResponse(HttpResponseMessage response, LogContext logContext, MethodType methodType)
        {
            if (!response.IsSuccessStatusCode)
            {
                HandleFailure(response, logContext, methodType);
            }

            string responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            LogPostMethodCall(MethodType.Post, logContext, response, responseContent);

            return responseContent;
        }

        private void HandleFailure(HttpResponseMessage response, LogContext logContext, MethodType methodType)
        {
            string errorMessage = GetErrorDescription(response.Content, logContext, methodType);

            logger?.LogError(
                logContext.EventId,
                "{CorrelationId} {HttpMethod} Response {HttpCode} ({HttpReason}) {ErrorMessage}",
                logContext.CorrelationId,
                methodType.ToString().ToUpperInvariant(),
                (int)response.StatusCode,
                response.ReasonPhrase,
                errorMessage);

            throw ExceptionMapper.Map((int)response.StatusCode, response.ReasonPhrase, errorMessage);
        }

        private string GetErrorDescription(HttpContent content, LogContext logContext, MethodType methodType)
        {
            // Error responses come if a couple of different formats...
            string responseBody = string.Empty;
            string errorMessage = string.Empty;
            try
            {
                // Get the message body for rethrow, with body included
                responseBody = AsyncUtil.RunSync(content.ReadAsStringAsync);

                try
                {
                    // Try error format #1
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
                    errorMessage = errorResponse.ErrorDetail.Message;
                }
                catch (JsonSerializationException)
                {
                    // That didn't work, so try error format #2
                    ErrorResponseBasic errorResponseBasic = JsonConvert.DeserializeObject<ErrorResponseBasic>(responseBody);
                    errorMessage = errorResponseBasic.Description;
                }
            }
            catch (Exception)
            {
                // Unexpected condition, likely to be hit only if some new error response format is added to the API.
                logger?.LogWarning(
                    logContext.EventId,
                    "{CorrelationId} {HttpMethod} Failed to parse error response body:\n{ResponseBody}",
                    logContext.CorrelationId,
                    methodType.ToString().ToUpperInvariant(),
                    responseBody);
            }

            return errorMessage;
        }
    }
}
