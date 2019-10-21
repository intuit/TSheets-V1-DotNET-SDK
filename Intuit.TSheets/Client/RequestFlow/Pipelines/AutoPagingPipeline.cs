// *******************************************************************************
// <copyright file="AutoPagingPipeline.cs" company="Intuit">
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
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A composite request pipeline that automatically handles paginated results from
    /// a "get" call by detecting and retrieving additional pages of results.
    /// </summary>
    /// <remarks>
    /// To clients of this pipeline, it is as if pagination does not exist. Results from
    /// all pages will be returned, regardless of the max number of items per page.
    /// For this pipeline to be used, the AutoPaging property of the <see cref="RequestOptions"/>
    /// object passed to the DataService method must be 'true'.
    /// </remarks>
    internal class AutoPagingPipeline : IPipeline
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoPagingPipeline"/> class.
        /// </summary>
        /// <param name="innerPipeline">
        /// A standard pipeline instance which handles calls for each page.
        /// </param>
        internal AutoPagingPipeline(IPipeline innerPipeline)
        {
            InnerPipeline = innerPipeline;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoPagingPipeline"/> class.
        /// </summary>
        /// <remarks>
        /// For unit testing.
        /// </remarks>
        internal AutoPagingPipeline()
        {
        }

        /// <summary>
        /// Gets or sets the standard pipeline instance which handles calls for each page.
        /// </summary>
        internal IPipeline InnerPipeline { get; set; }

        /// <summary>
        /// Starts retrieving results from the page number set in the provided context,
        /// and continues making follow-up calls for additional pages until none remain.
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
            var getContext = (GetContext<T>)context;
            var consolidatedItems = new List<T>();

            do
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (getContext.Options.Page.HasValue)
                {
                    logger?.LogInformation(
                        context.LogContext.EventId,
                        "{CorrelationId} GET AutoPager retrieving page #{Page} of {Endpoint}",
                        context.LogContext.CorrelationId,
                        getContext.Options.Page,
                        getContext.Endpoint);
                }

                await InnerPipeline.ProcessAsync(getContext, logger, cancellationToken).ConfigureAwait(false);
                consolidatedItems.AddRange(getContext.Results.Items);

                if (getContext.ResultsMeta.More)
                {
                    getContext.Options.Page = getContext.ResultsMeta.Page + 1;
                }
            }
            while (getContext.ResultsMeta.More);

            getContext.Results.Items = consolidatedItems;
        }

        /// <summary>
        /// Not supported. Additional stages must be added to the underlying pipeline.
        /// </summary>
        /// <param name="pipelineElements">
        /// The individual elements which comprise the pipeline.
        /// </param>
        public void AddStage(params IPipelineElement[] pipelineElements)
        {
            throw new NotImplementedException();
        }
    }
}
