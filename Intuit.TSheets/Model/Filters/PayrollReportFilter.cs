// *******************************************************************************
// <copyright file="PayrollReportFilter.cs" company="Intuit">
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
    using Newtonsoft.Json;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="PayrollReport"/>.
    /// </summary>
    [JsonObject]
    public class PayrollReportFilter : EntityFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayrollReportFilter"/> class.
        /// </summary>
        public PayrollReportFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayrollReportFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="startDate">
        /// The start date for the range of report data.
        /// </param>
        /// <param name="endDate">
        /// The end date for the range of report data.
        /// </param>
        public PayrollReportFilter(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Gets or sets the value for the start date of the report.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("start_date")]
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        ///  Gets or sets the value for the end date of the report.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("end_date")]
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the user ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<int> UserIds { get; set; }

        /// <summary>
        /// Gets or sets the group ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("group_ids")]
        public IEnumerable<int> GroupIds { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to include all users in the report, even if they had zero hours for the time period.
        /// </summary>
        [JsonProperty("include_zero_time")]
        public bool? IncludeZeroTime { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to format report results such that it includes the time for individual multipliers and can support more than just 1.5x (OT) and 2x (dt) overtime.
        /// </summary>
        [JsonConverter(typeof(BoolStringConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("advanced_overtime")]
        public bool? AdvancedOvertime { get; set; }
    }
}
