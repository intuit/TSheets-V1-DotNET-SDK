// *******************************************************************************
// <copyright file="IRestClient.cs" company="Intuit">
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
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Utilities;

    /// <summary>
    /// Interface for an HTTP client to the TSheets Rest API.
    /// </summary>
    internal interface IRestClient
    {
        /// <summary>
        /// Creates entities in TSheets via an HTTP POST call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="jsonData">The content to be sent in the body of the request.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The serialized response of the API method call.</returns>
        Task<string> CreateAsync(
            EndpointName endpointName,
            string jsonData,
            LogContext logContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves entities from TSheets via an HTTP GET call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="filters">The key-value pairs to be sent as URL request parameters.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The serialized response of the API method call.</returns>
        Task<string> GetAsync(
            EndpointName endpointName,
            Dictionary<string, string> filters,
            LogContext logContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Downloads binary data from TSheets via an HTTP POST call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="filters">The key-value pairs to be sent as URL request parameters.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The serialized response of the API method call.</returns>
        Task<byte[]> DownloadAsync(
            EndpointName endpointName,
            Dictionary<string, string> filters,
            LogContext logContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Updates entities in TSheets via an HTTP PUT call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="jsonData">The content to be sent in the body of the request.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The serialized response of the API method call.</returns>
        Task<string> UpdateAsync(
            EndpointName endpointName,
            string jsonData,
            LogContext logContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Removes entities in TSheets via an HTTP DELETE call to the API endpoint.
        /// </summary>
        /// <param name="endpointName">The name of the endpoint, <see cref="EndpointName"/></param>
        /// <param name="ids">The ids of the entities to be deleted.</param>
        /// <param name="logContext">Call-specific contextual information for logging purposes.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The serialized response of the API method call.</returns>
        Task<string> DeleteAsync(
            EndpointName endpointName,
            IEnumerable<long> ids,
            LogContext logContext,
            CancellationToken cancellationToken);
    }
}
