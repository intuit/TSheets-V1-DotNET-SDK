// *******************************************************************************
// <copyright file="GetReportContext.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow.Contexts
{
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model.Filters;
    using Newtonsoft.Json;

    /// <summary>
    /// For a report retrieval (POST) operation, provides contextual information as the vehicle of state through the request pipeline.
    /// </summary>
    /// <typeparam name="T">The type of report.</typeparam>
    [JsonObject]
    internal class GetReportContext<T> : PipelineContext<T>, ISerializedRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetReportContext{T}"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint with which to interact.</param>
        /// <param name="filter">The filter for tuning the report results.</param>
        internal GetReportContext(EndpointName endpoint, EntityFilter filter)
            : base(MethodType.Post, endpoint)
        {
            Filter = filter ?? new NullFilter();
        }

        /// <summary>
        /// Gets or sets the report request information, as a serialized JSON string.
        /// </summary>
        [JsonProperty]
        public string SerializedRequest { get; set; }

        /// <summary>
        /// Gets or sets the instance of <see cref="IEntityFilter"/>, for tuning the report results.
        /// </summary>
        [JsonProperty]
        internal IEntityFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the report to be returned.
        /// </summary>
        [JsonProperty]
        internal new T Results { get; set; }
    }
}
