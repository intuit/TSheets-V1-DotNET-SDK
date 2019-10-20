// *******************************************************************************
// <copyright file="RestClientPostHandler.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow.PipelineElements
{
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A singleton pipeline stage that invokes the http rest client to perform a "create" operation.
    /// </summary>
    internal class RestClientPostHandler : PipelineElement<RestClientPostHandler>
    {
        private RestClientPostHandler()
        {
        }

        /// <summary>
        /// Calls the rest client with a serialized request to create data entities.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        protected override async Task _ProcessAsync<T>(
            PipelineContext<T> context,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            string serializedRequest = ((ISerializedRequest)context).SerializedRequest;

            context.ResponseContent = await context.RestClient.CreateAsync(
                context.Endpoint,
                serializedRequest,
                context.LogContext,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
