// *******************************************************************************
// <copyright file="RequestPipeline.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow.Pipelines
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A list of stateless pipeline elements that are called in sequence,
    /// collectively to process a single TSheets API method call.
    /// </summary>
    internal class RequestPipeline : IPipeline
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="RequestPipeline"/> class,
        /// initialized with the provided pipeline elements.
        /// </summary>
        /// <param name="pipelineElements">
        /// One or more elements with which to initialize the pipeline.
        /// </param>
        internal RequestPipeline(params IPipelineElement[] pipelineElements)
        {
            PipelineElements = new List<IPipelineElement>(pipelineElements);
            Name = GetType().Name;
        }

        /// <summary>
        /// Gets the list of pipeline elements.
        /// </summary>
        internal List<IPipelineElement> PipelineElements { get; }

        /// <summary>
        /// Gets the name of the pipeline.
        /// </summary>
        internal string Name { get; }

        /// <summary>
        /// Calls each pipeline element in sequence.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <returns>The completed asynchronous task.</returns>
        public async Task ProcessAsync<T>(
            PipelineContext<T> context,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            foreach (IPipelineElement pipelineElement in PipelineElements)
            {
                await pipelineElement.ProcessAsync(context, logger, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Adds elements to the end of the pipeline.
        /// </summary>
        /// <param name="pipelineElements">
        /// One or more elements to add to the end of the pipeline.
        /// </param>
        public void AddStage(params IPipelineElement[] pipelineElements)
        {
            foreach (IPipelineElement pipelineElement in pipelineElements)
            {
                PipelineElements.Add(pipelineElement);
            }
        }
    }
}
