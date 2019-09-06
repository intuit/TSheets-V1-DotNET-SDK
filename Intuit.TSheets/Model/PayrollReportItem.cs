// *******************************************************************************
// <copyright file="PayrollReportItem.cs" company="Intuit">
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
    /// Payroll Report data, specific to a single user.
    /// </summary>
    [JsonObject]
    public class PayrollReportItem 
    {
        /// <summary>
        /// Gets the user id to which this payroll data pertains.
        /// </summary>
        [JsonProperty("user_id")]
        public int UserId { get; internal set; }

        /// <summary>
        /// Gets the client id to which this payroll data pertains.
        /// </summary>
        [JsonProperty("client_id")]
        public int ClientId { get; internal set; }

        /// <summary> 
        /// Gets start of the reporting time frame.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("start_date")]
        public DateTimeOffset? StartDate { get; internal set; }

        /// <summary>
        /// Gets end of the reporting time frame.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("end_date")]
        public DateTimeOffset? EndDate { get; internal set; }

        /// <summary>
        /// Gets regular time, in seconds 
        /// </summary>
        [JsonProperty("total_re_seconds")]
        public int? TotalReSeconds { get; internal set; }

        /// <summary>
        /// Gets total PTO time, in seconds 
        /// </summary>
        [JsonProperty("total_pto_seconds")]
        public int? TotalPtoSeconds { get; internal set; }

        /// <summary>
        /// Gets total overall time, in seconds 
        /// </summary>
        [JsonProperty("total_work_seconds")]
        public int? TotalWorkSeconds { get; internal set; }

        /// <summary>
        /// Gets breakdown of PTO time by PTO code.
        /// </summary>
        [JsonProperty("pto_seconds")]
        public IReadOnlyDictionary<string, int> PtoSeconds { get; internal set; }

        /// <summary>
        /// Gets the value which replaces total OT and total DT seconds.
        /// </summary>
        [JsonProperty("overtime_seconds")]
        public IReadOnlyDictionary<string, int> OvertimeSeconds { get; internal set; }

        /// <summary>
        /// Gets the value which replaces total OT and total DT seconds.
        /// </summary>
        [JsonProperty("fixed_rate_seconds")]
        public IReadOnlyDictionary<string, int> FixedRateSeconds { get; internal set; }
    }
}
