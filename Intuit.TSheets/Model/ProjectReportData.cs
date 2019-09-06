// *******************************************************************************
// <copyright file="ProjectReportData.cs" company="Intuit">
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
    using Newtonsoft.Json;

    /// <summary>
    /// The report data.
    /// </summary>
    [JsonObject]
    public class ProjectReportData
    {
        /// <summary>
        /// Gets the filter settings used to generate the report.
        /// </summary>
        [JsonProperty("filters")]
        public ProjectReportFilters Filters { get; internal set; }

        /// <summary>
        /// Gets totals, indexed by unique user id.
        /// </summary>
        [JsonProperty("totals")]
        public ProjectReportTotals Totals { get; internal set; }
    }
}
