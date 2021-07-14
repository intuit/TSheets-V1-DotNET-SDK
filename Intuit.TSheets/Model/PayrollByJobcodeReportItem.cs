// *******************************************************************************
// <copyright file="PayrollByJobcodeReportItem.cs" company="Intuit">
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
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Payroll By Jobcode Report Item
    /// </summary>
    [JsonObject]
    public class PayrollByJobcodeReportItem
    {
        /// <summary>
        ///  Gets the jobcode id to which this data pertains.
        /// </summary>
        [JsonProperty("jobcode_id")]
        public long JobcodeId { get; internal set; }

        /// <summary>
        /// Gets regular time, in seconds 
        /// </summary>
        [JsonProperty("total_re_seconds")]
        public int? TotalReSeconds { get; internal set; }

        /// <summary>
        /// Gets overtime time, in seconds 
        /// </summary>
        [JsonProperty("total_ot_seconds")]
        public int? TotalOtSeconds { get; internal set; }

        /// <summary>
        /// Gets double time, in seconds 
        /// </summary>
        [JsonProperty("total_dt_seconds")]
        public int? TotalDtSeconds { get; internal set; }

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
