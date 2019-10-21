// *******************************************************************************
// <copyright file="ModificationResultsDeserializer.cs" company="Intuit">
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
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Extensions;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A singleton pipeline stage that deserializes the response from a "create" or "update" operation.
    /// </summary>
    internal class ModificationResultsDeserializer : PipelineElement<ModificationResultsDeserializer>
    {
        private ModificationResultsDeserializer()
        {
        }

        /// <summary>
        /// Steps through the results of a create or update operation, deserializing each item into lists
        /// of success and failure result entities that are written back to the context object.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The completed asynchronous task.</returns>
        protected override Task _ProcessAsync<T>(
            PipelineContext<T> context,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            JToken document = JToken.Parse(context.ResponseContent);
            IEnumerable<JToken> tokens = document.SelectTokens(context.JsonPath());

            var results = new Results<T>();

            int index = 0;
            foreach (JToken token in tokens)
            {
                Status status = JsonConvert.DeserializeObject<Status>(token.ToString());

                // If not success, we may not be able to deserialize the entity, but we'll try anyway.
                // It's not a problem if serialization fails here, as a later pipeline stage will still
                // be able to retrieve the error status codes and descriptions.
                T entity = default;
                try
                {
                    entity = JsonConvert.DeserializeObject<T>(token.ToString());
                }
                catch (Exception e) when (!status.IsSuccess)
                {
                    logger?.LogWarning(context.LogContext.EventId, e, "Failed to deserialize response.");
                }

                // Add the entity, to either the "success" list, or the "error" list.
                if (status.IsSuccess)
                {
                    results.Items.Add(entity);
                }
                else
                {
                    results.ErrorItems.Add(new ErrorItem<T>(index, entity, status));
                }

                index++;
            }

            context.Results = results;

            return Task.CompletedTask;
        }
    }
}
