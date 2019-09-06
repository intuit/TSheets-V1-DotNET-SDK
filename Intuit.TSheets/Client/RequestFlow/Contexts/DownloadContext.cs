// *******************************************************************************
// <copyright file="DownloadContext.cs" company="Intuit">
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
    /// For a download operation (POST/byte[] response), provides contextual information as the vehicle of state through the request pipeline.
    /// </summary>
    /// <typeparam name="T">The type of data entity.</typeparam>
    [JsonObject]
    internal class DownloadContext<T> : PipelineContext<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadContext{T}"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint with which to interact.</param>
        /// <param name="filter">The filter for narrowing down the result set.</param>
        internal DownloadContext(EndpointName endpoint, EntityFilter filter)
            : base(MethodType.Get, endpoint)
        {
            Filter = filter ?? new NullFilter();
        }

        /// <summary>
        /// Gets or sets the instance of <see cref="IEntityFilter"/>, for narrowing down the result set.
        /// </summary>
        [JsonProperty]
        internal IEntityFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the array of bytes representing the item downloaded.
        /// </summary>
        [JsonProperty]
        internal byte[] RawResponseContent { get; set; }
    }
}