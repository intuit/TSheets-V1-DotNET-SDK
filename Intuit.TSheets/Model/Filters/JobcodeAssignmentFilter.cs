// *******************************************************************************
// <copyright file="JobcodeAssignmentFilter.cs" company="Intuit">
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
    using System;
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="JobcodeAssignment"/> entities.
    /// </summary>
    [JsonObject]
    public class JobcodeAssignmentFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the user ids for whom you'd like to retrieve jobcode assignments.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<long> UserIds { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering by jobcode type, e.g. 'regular', 'PTO', etc.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public JobcodeType? JobcodeType { get; set; }

        /// <summary>
        /// Gets or sets the jobcode ids you'd like to filter on.
        /// </summary>
        [JsonProperty("jobcode_id")]
        public long? JobcodeId { get; set; }

        /// <summary>
        /// Gets or sets the jobcode parent id you'd like to filter on.
        /// </summary>
        /// <remarks>
        /// When omitted, all jobcode assignments are returned regardless of jobcode parent.
        /// If specified, only assignments for jobcodes with the given jobcode parent_id are returned.
        /// To get a list of only top-level jobcode assignments, pass in a jobcode_parent_id of 0.
        /// </remarks>
        [JsonProperty("jobcode_parent_id")]
        public long? JobcodeParentId { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering by active or inactive state, or both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("active")]
        public TristateChoice? Active { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those jobcode assignments modified before this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those jobcode assignments modified after this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }
    }
}
