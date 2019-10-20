// *******************************************************************************
// <copyright file="UpdateRequestSerializer.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// A singleton pipeline stage which serializes to JSON the input entities to be updated.
    /// </summary>
    internal class UpdateRequestSerializer : PipelineElement<UpdateRequestSerializer>
    {
        private UpdateRequestSerializer()
        {
        }

        /// <summary>
        /// A JSON converter which will ignore the attributed data entity properties that must not
        /// be serialized on an update operation (i.e. CreatedDate, etc.)
        /// </summary>
        private static JsonConverter SerializationConverter =>
            new SerializationConverter(typeof(NoSerializeOnWriteAttribute));

        /// <summary>
        /// Reads from the context object the set of entities to be updated, and writes it back to 
        /// the context as a serialized JSON string, in the format expected by the TSheets API.
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
            var updateContext = (UpdateContext<T>)context;

            updateContext.SerializedRequest = JsonConvert.SerializeObject(
                new Request<T>(updateContext.Items),
                Formatting.Indented,
                SerializationConverter);

            return Task.CompletedTask;
        }
    }
}
