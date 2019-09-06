// *******************************************************************************
// <copyright file="CurrentTotalsReport.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// CurrentTotalsReport, a snapshot report for the current totals (shift and day) along with
    /// additional information provided for those who are currently on the clock.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class CurrentTotalsReport
    {
        /// <summary>
        /// Gets the list of per-user Reports.
        /// </summary>
        [JsonProperty("current_totals")]
        public IReadOnlyDictionary<string, CurrentTotalsReportItem> CurrentTotals { get; internal set; }
    }
}
