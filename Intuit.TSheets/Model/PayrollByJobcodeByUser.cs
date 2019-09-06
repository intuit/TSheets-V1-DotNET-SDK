// *******************************************************************************
// <copyright file="PayrollByJobcodeByUser.cs" company="Intuit">
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
    /// Payroll By Jobcode Report, by User
    /// </summary>
    [JsonObject]
    public class PayrollByJobcodeByUser
    {
        /// <summary>
        ///  Gets the user id to which this report data pertains.
        /// </summary>
        [JsonProperty("user_id")]
        public int UserId { get; internal set; }

        /// <summary>
        /// Gets the Payroll By Jobcode Totals for this User
        /// </summary>
        [JsonProperty("totals")]
        public IReadOnlyDictionary<string, PayrollByJobcodeReportItem> Totals { get; internal set; }
        
        /// <summary>
        /// Gets the Payroll By Jobcode By Date Totals for this User
        /// </summary>
        [JsonProperty("dates")]
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, PayrollByJobcodeReportItem>> Dates { get; internal set; }
    }
}
