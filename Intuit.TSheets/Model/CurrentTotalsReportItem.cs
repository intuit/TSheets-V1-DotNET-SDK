// *******************************************************************************
// <copyright file="CurrentTotalsReportItem.cs" company="Intuit">
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
    /// CurrentTotalsReportItem, a snapshot report item for a single user, with the
    /// current totals (shift and day) along with additional information.
    /// </summary>
    [JsonObject]
    public class CurrentTotalsReportItem
    {
        /// <summary>
        ///  Gets the user id to which these totals pertain.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; internal set; }

        /// <summary>
        /// Gets the value indicating whether this user is on or off the clock.
        /// </summary>
        [JsonProperty("on_the_clock")]
        public bool? OnTheClock { get; internal set; }

        /// <summary>
        /// Gets the timesheet id for the current timesheet.
        /// </summary>
        [JsonProperty("timesheet_id")]
        public long? TimesheetId { get; internal set; }

        /// <summary>
        /// Gets the jobcode id for the current timesheet.
        /// </summary>
        [JsonProperty("jobcode_id")]
        public long? JobcodeId { get; internal set; }

        /// <summary>
        /// Gets the unique group id for this user (value of zero represents those without a group).
        /// </summary>
        [JsonProperty("group_id")]
        public long? GroupId { get; internal set; }

        /// <summary>
        /// Gets the value indicating whether geolocations are available for the current timesheet.
        /// </summary>
        [JsonProperty("shift_geolocations_available")]
        public bool? ShiftGeolocationsAvailable { get; internal set; }

        /// <summary>
        /// Gets the total time for the current shift, in seconds. 
        /// </summary>
        [JsonProperty("shift_seconds")]
        public int? ShiftSeconds { get; internal set; }

        /// <summary>
        /// Gets the total time for the current day, in seconds. 
        /// </summary>
        [JsonProperty("day_seconds")]
        public int? DaySeconds { get; internal set; }
    }
}
