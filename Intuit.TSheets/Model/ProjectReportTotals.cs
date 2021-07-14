// *******************************************************************************
// <copyright file="ProjectReportTotals.cs" company="Intuit">
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
    /// Report Totals Data, per User, Group, Jobcode, and CustomField
    /// </summary>
    [JsonObject]
    public class ProjectReportTotals
    {
        /// <summary>
        /// Gets User Report Totals
        /// </summary>
        [JsonProperty("users")]
        public IReadOnlyDictionary<long, float> Users { get; internal set; }

        /// <summary>
        /// Gets Group Report Totals
        /// </summary>
        [JsonProperty("groups")]
        public IReadOnlyDictionary<long, float> Groups { get; internal set; }

        /// <summary>
        /// Gets Jobcode Report Totals
        /// </summary>
        [JsonProperty("jobcodes")]
        public IReadOnlyDictionary<long, float> Jobcodes { get; internal set; }

        /// <summary>
        /// Gets Custom Field Report Totals
        /// </summary>
        [JsonProperty("customfields")]
        public IReadOnlyDictionary<long, IReadOnlyDictionary<long, float>> CustomFields { get; internal set; }
    }
}
