// *******************************************************************************
// <copyright file="PayrollByJobcodeReportFilters.cs" company="Intuit">
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
    using Newtonsoft.Json;

    /// <summary>
    /// The filter settings used to generate the report.
    /// </summary>
    [JsonObject]
    public class PayrollByJobcodeReportFilters
    {
        /// <summary>
        /// Gets the start date for the report.
        /// </summary>
        /// <remarks>
        /// Any time with a date falling on or after this date will be included.
        /// </remarks>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("start_date")]
        public DateTimeOffset? StartDate { get; internal set; }

        /// <summary>
        /// Gets the end date for the report.
        /// </summary>
        /// <remarks>
        /// Any time with a date falling on or before this date will be included.
        /// </remarks>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("end_date")]
        public DateTimeOffset? EndDate { get; internal set; }

        /// <summary>
        /// Gets the ids for users to be included in the report.
        /// </summary>
        /// <remarks>
        /// Only time for these users will be included.
        /// </remarks>
        [JsonProperty("user_ids")]
        public IReadOnlyList<int> UserIds { get; internal set; }

        /// <summary>
        /// Gets the ids for groups to be included in the report.
        /// </summary>
        /// <remarks>
        /// Only time for these groups will be included.
        /// </remarks>
        [JsonProperty("group_ids")]
        public IReadOnlyList<int> GroupIds { get; internal set; }

        /// <summary>
        /// Gets the value indicating whether or not advanced overtime is enabled for the report.
        /// </summary>
        /// <remarks>
        /// If 'yes', overtime will be formatted such that it includes the time for individual multipliers
        /// and can support more than just 1.5x (OT) and 2x (DT) overtime.
        /// </remarks>
        [JsonProperty("advanced_overtime")]
        public bool? AdvancedOvertime { get; internal set; }
    }
}
