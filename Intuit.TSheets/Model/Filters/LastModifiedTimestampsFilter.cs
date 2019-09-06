// *******************************************************************************
// <copyright file="LastModifiedTimestampsFilter.cs" company="Intuit">
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

namespace Intuit.TSheets.Model.Filters
{
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="LastModifiedTimestamps"/>.
    /// </summary>
    [JsonObject]
    public class LastModifiedTimestampsFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the endpoints for which you'd like to retrieve last modified timestamp values.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("endpoints")]
        public Endpoints? Endpoints { get; set; }
    }
}
