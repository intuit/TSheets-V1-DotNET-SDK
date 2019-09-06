// *******************************************************************************
// <copyright file="PipelineFactory.cs" company="Intuit">
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
    using System.Linq;
    using Intuit.TSheets.Client.Extensions;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Intuit.TSheets.Client.Utilities;

    /// <summary>
    /// A factory object for creating request pipeline instances.
    /// </summary>
    internal class PipelineFactory : Singleton<PipelineFactory>, IPipelineFactory
    {
        // Default pipeline for a "get" call
        private readonly IPipeline getPipeline = new RequestPipeline(
            RestClientGetHandler.Instance,
            GetResultsDeserializer.Instance,
            GetResultsMetaDeserializer.Instance);

        // Default pipeline for a "get" call, with supplemental data included.
        private readonly IPipeline getPipelineWithSupplementalData = new RequestPipeline(
            RestClientGetHandler.Instance,
            GetResultsDeserializer.Instance,
            GetResultsMetaDeserializer.Instance,
            SupplementalDataDeserializer.Instance);

        // Default pipeline for a "download" call
        private readonly IPipeline downloadPipeline = new RequestPipeline(
            RestClientDownloadHandler.Instance);

        // Default pipeline for retrieving a report
        private readonly IPipeline getReportPipeline = new RequestPipeline(
            GetReportSerializer.Instance,
            RestClientPostHandler.Instance,
            GetReportDeserializer.Instance,
            SupplementalDataDeserializer.Instance);

        // Default pipeline for a "create" call
        private readonly IPipeline createPipeline = new RequestPipeline(
            CreateContextValidator.Instance,
            CreateRequestSerializer.Instance,
            RestClientPostHandler.Instance,
            ModificationResultsDeserializer.Instance,
            SupplementalDataDeserializer.Instance,
            MultiStatusHandler.Instance);

        // Default pipeline for a "create" call
        private readonly IPipeline updatePipeline = new RequestPipeline(
            UpdateContextValidator.Instance,
            UpdateRequestSerializer.Instance,
            RestClientPutHandler.Instance,
            ModificationResultsDeserializer.Instance,
            SupplementalDataDeserializer.Instance,
            MultiStatusHandler.Instance);

        // Default pipeline for a "delete" call
        private readonly IPipeline deletePipeline = new RequestPipeline(
            DeleteContextValidator.Instance,
            RestClientDeleteHandler.Instance,
            DeleteResultsDeserializer.Instance,
            MultiStatusHandler.Instance);

        private PipelineFactory()
        {
        }

        /// <summary>
        /// Returns a request pipeline appropriate to the type of context object passed in,
        /// as well as the values of its properties.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <returns>
        /// An instance of an <see cref="IPipeline"/>, which when invoked processes the entire API method call.
        /// </returns>
        public IPipeline GetPipeline<T>(PipelineContext<T> context)
        {
            switch (context)
            {
                // create a "get" pipeline, based on the options for
                // supplemental data and auto paging.
                case GetContext<T> getContext:
                    IPipeline pipeline = getContext.Options.IncludeSupplementalData.IsTrueOrNull()
                        ? this.getPipelineWithSupplementalData
                        : this.getPipeline;

                    return getContext.Options.AutoPaging
                        ? new AutoPagingPipeline(pipeline)
                        : pipeline;

                case CreateContext<T> createContext:
                    return createContext.Items.Count() > AutoBatchingPipeline.MaxItemsPerBatch
                        ? new RequestPipeline(
                            new AutoBatchingPipeline(this.createPipeline),
                            MultiStatusHandler.Instance)
                        : this.createPipeline;

                case UpdateContext<T> updateContext:
                    return updateContext.Items.Count() > AutoBatchingPipeline.MaxItemsPerBatch
                        ? new RequestPipeline(
                            new AutoBatchingPipeline(this.updatePipeline),
                            MultiStatusHandler.Instance)
                        : this.updatePipeline;

                case DownloadContext<T> _:
                    return this.downloadPipeline;

                case GetReportContext<T> _:
                    return this.getReportPipeline;

                case DeleteContext<T> _:
                    return this.deletePipeline;

                default:
                    throw new InvalidProgramException($"Unexpected context type '{context}'.");
            }
        }
    }
}
