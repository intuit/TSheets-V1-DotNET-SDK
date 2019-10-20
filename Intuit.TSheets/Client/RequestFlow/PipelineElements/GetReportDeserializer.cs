// *******************************************************************************
// <copyright file="GetReportDeserializer.cs" company="Intuit">
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
    using Newtonsoft.Json;

    /// <summary>
    /// A singleton pipeline stage that deserializes the response from a report retrieval operation.
    /// </summary>
    internal class GetReportDeserializer : PipelineElement<GetReportDeserializer>
    {
        private GetReportDeserializer()
        {
        }

        /// <summary>
        /// Reads from the context object the JSON response string representing the report returned
        /// from the retrieval call, deserializes it, and writes it back into the context.
        /// </summary>
        /// <typeparam name="T">The type of report.</typeparam>
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
            var reportContext = (GetReportContext<T>)context;
            var report = JsonConvert.DeserializeObject<Report<T>>(context.ResponseContent);

            reportContext.Results = report.Results;

            return Task.CompletedTask;
        }
    }
}
