// *******************************************************************************
// <copyright file="ProjectReportFilters.cs" company="Intuit">
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

namespace Intuit.TSheets.Model
{
    using System;
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// The filters used to generate the report.
    /// </summary>
    [JsonObject]
    public class ProjectReportFilters
    {
        /// <summary>
        /// Gets filter for the ids for <see cref="User"/> objects to be included in the report.
        /// </summary>
        /// <remarks>
        /// Only time for these users will be included.
        /// </remarks>
        [JsonProperty("user_ids")]
        public IReadOnlyList<long> UserIds { get; internal set; }

        /// <summary>
        /// Gets filter for the ids for <see cref="Group"/> objects to be included in the report.
        /// </summary>
        /// <remarks>
        /// Only time for these groups will be included.
        /// </remarks>
        [JsonProperty("group_ids")]
        public IReadOnlyList<long> GroupIds { get; internal set; }

        /// <summary>
        /// Gets filter for the start date for the report.
        /// </summary>
        /// <remarks>
        /// Any time with a date falling on or after this date will be included.
        /// </remarks>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("start_date")]
        public DateTimeOffset? StartDate { get; internal set; }

        /// <summary>
        /// Gets filter for the end date for the report.
        /// </summary>
        /// <remarks>
        /// Any time with a date falling on or before this date will be included.
        /// </remarks>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("end_date")]
        public DateTimeOffset? EndDate { get; internal set; }

        /// <summary>
        /// Gets filter for the ids for <see cref="Jobcode"/> objects to be included in the report.
        /// </summary>
        /// <remarks>
        /// Only time for these jobcodes will be included.
        /// </remarks>
        [JsonProperty("jobcode_ids")]
        public IReadOnlyList<long> JobcodeIds { get; internal set; }

        /// <summary>
        /// Gets filters for the <see cref="CustomFieldItems"/> objects to be included in the report.
        /// </summary>
        [JsonConverter(typeof(EmptyArrayObjectConverter))]
        [JsonProperty("customfielditems")]
        public IReadOnlyDictionary<string, IReadOnlyList<string>> CustomFieldItems { get; internal set; }

        /// <summary>
        /// Gets filters for the types of <see cref="Jobcode"/> objects to be included in the report.
        /// </summary>
        /// <remarks>
        /// See <see cref="JobcodeType"/>.
        /// Only time for these jobcode types will be included.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("jobcode_type")]
        public JobcodeType? JobcodeType { get; internal set; }
    }
}
