// *******************************************************************************
// <copyright file="AutoBatchingPipeline.cs" company="Intuit">
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
    using System.Linq;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Extensions;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A composite request pipeline that automatically handles batched create and update calls
    /// for batch sizes that exceed the maximum allowed entity item count of 50.
    /// </summary>
    /// <remarks>
    /// To clients of this pipeline, it is as if there is no limit to the number of entities
    /// that can be created or updated in a single call.
    /// </remarks>
    internal class AutoBatchingPipeline : IPipeline
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoBatchingPipeline"/> class.
        /// </summary>
        /// <param name="innerPipeline">
        /// A standard pipeline instance which handles calls for each batch.
        /// </param>
        internal AutoBatchingPipeline(IPipeline innerPipeline)
        {
            InnerPipeline = innerPipeline;
        }

        /// <summary>
        /// The maximum number of items in a create or update batch.
        /// </summary>
        internal static int MaxItemsPerBatch => 50;

        /// <summary>
        /// Gets or sets the standard pipeline instance which handles calls for each batch.
        /// </summary>
        internal IPipeline InnerPipeline { get; set; }

        /// <summary>
        /// Splits the set of entities to be created or updated into batches of 50,
        /// processes each sequentially, and consolidates and returns the results.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <returns>The completed asynchronous task.</returns>
        public async Task ProcessAsync<T>(PipelineContext<T> context, ILogger logger)
        {
            var writeContext = (IWritableContext<T>)context;
            string correlationId = context.LogContext.CorrelationId;
            string httpMethod = context.MethodType.ToString();

            var allResults = new Results<T>();
            var allSupplementalData = new SupplementalData();

            int batchNumber = 0;
            if (writeContext.Items.Count() > MaxItemsPerBatch)
            {
                List<T> allItems = writeContext.Items.ToList();

                int totalBatchCount = GetBatchCount(allItems.Count, MaxItemsPerBatch);
                foreach (IEnumerable<T> batch in allItems.MakeBatchesOfSize(MaxItemsPerBatch))
                {
                    T[] batchItems = batch.ToArray();

                    ++batchNumber;
                    logger?.LogInformation(
                        context.LogContext.EventId,
                        "{CorrelationId} {HttpMethod} Sending batch #{BatchNumber} of {TotalBatchCount} (batch size: {BatchSize}).",
                        context.LogContext.CorrelationId,
                        httpMethod,
                        batchNumber,
                        totalBatchCount,
                        batchItems.Length);

                    writeContext.Items = batchItems;

                    try
                    {
                        await InnerPipeline.ProcessAsync(context, logger).ConfigureAwait(false);
                    }
                    catch (MultiStatusException<T> ex)
                    {
                        // The index values for error items will be in the range of 0-49
                        // since the underlying pipeline handles single calls of max 50 items.
                        // We need to offset the indexes to account for the previous batches
                        // that have already been sent,.
                        int indexOffset = (batchNumber - 1) * MaxItemsPerBatch;

                        allResults.ErrorItems.AddRange(
                            ex.FailureResults.Select(f =>
                            {
                                f.Index += indexOffset;
                                return f;
                            }));
                    }

                    // Consolidate the results of each batch back into a single list.
                    allResults.Items.AddRange(context.Results.Items);
                    allSupplementalData.AddOrUpdate(
                        context.ResultsMeta.SupplementalData.GetAll());
                }

                context.Results = allResults;
                context.ResultsMeta.SupplementalData = allSupplementalData;
            }
            else
            {
                // There are few enough items that batching isn't needed.
                // In this case, we can simply call the inner pipeline.
                await InnerPipeline.ProcessAsync(context, logger).ConfigureAwait(false);
            }
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

        private static int GetBatchCount(int totalCount, int batchSize)
            => (int)Math.Ceiling((double)totalCount / batchSize);
    }
}
