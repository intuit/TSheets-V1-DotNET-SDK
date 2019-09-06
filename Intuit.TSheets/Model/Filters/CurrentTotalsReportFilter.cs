// *******************************************************************************
// <copyright file="CurrentTotalsReportFilter.cs" company="Intuit">
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
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="CurrentTotalsReport"/>.
    /// </summary>
    [JsonObject]
    public class CurrentTotalsReportFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the user ids where which totals will be included.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<int> UserIds { get; set; }

        /// <summary>
        /// Gets or sets the group ids for which users belonging Only totals for users from these groups will be included.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("group_ids")]
        public IEnumerable<int> GroupIds { get; set; }

        /// <summary>
        /// Gets or sets the value indicating filtering by users who are on or off the clock, or both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("on_the_clock")]
        public TristateChoice? OnTheClock { get; set; }

        /// <summary>
        /// Gets or sets the page of results you'd like to retrieve. Default is 1.
        /// </summary>
        [JsonProperty("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets how many results you'd like to retrieve per request (page).
        /// </summary>
        /// <remarks>
        /// Default is 50. Max is 50.  Using this filter requires a page to be defined.
        /// </remarks>
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        /// <summary>
        /// Gets or sets the attribute name by which to order the result data.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("order_by")]
        public ReportOrder? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the data will be ordered descending by the attribute specified in the OrderBy property.
        /// </summary>
        [JsonProperty("order_desc")]
        public bool? OrderDesc { get; set; }
    }
}
