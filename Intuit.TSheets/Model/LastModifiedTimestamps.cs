// *******************************************************************************
// <copyright file="LastModifiedTimestamps.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// LastModifiedTimestamps, contains the most recent modification
    /// timestamp for objects from each requested API endpoint.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class LastModifiedTimestamps
    {
        /// <summary>
        /// Gets the last modified timestamp for the CurrentUser endpoint
        /// </summary>
        [JsonProperty("current_user")]
        public DateTimeOffset? CurrentUser { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the CustomFields endpoint
        /// </summary>
        [JsonProperty("customfields")]
        public DateTimeOffset? CustomFields { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the CustomFieldItems endpoint
        /// </summary>
        [JsonProperty("customfielditems")]
        public DateTimeOffset? CustomFieldItems { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the EffectiveSettings endpoint
        /// </summary>
        [JsonProperty("effective_settings")]
        public DateTimeOffset? EffectiveSettings { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the Geolocations endpoint
        /// </summary>
        [JsonProperty("geolocations")]
        public DateTimeOffset? Geolocations { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the Jobcodes endpoint
        /// </summary>
        [JsonProperty("jobcodes")]
        public DateTimeOffset? Jobcodes { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the JobcodeAssignments endpoint
        /// </summary>
        [JsonProperty("jobcode_assignments")]
        public DateTimeOffset? JobcodeAssignments { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the Timesheets endpoint
        /// </summary>
        [JsonProperty("timesheets")]
        public DateTimeOffset? Timesheets { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the TimesheetDeleted endpoint
        /// </summary>
        [JsonProperty("timesheets_deleted")]
        public DateTimeOffset? TimesheetDeleted { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the Users endpoint
        /// </summary>
        [JsonProperty("users")]
        public DateTimeOffset? Users { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the Reminders endpoint
        /// </summary>
        [JsonProperty("reminders")]
        public DateTimeOffset? Reminders { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the Locations endpoint
        /// </summary>
        [JsonProperty("locations")]
        public DateTimeOffset? Locations { get; internal set; }

        /// <summary>
        /// Gets the last modified timestamp for the GeofenceConfigs endpoint
        /// </summary>
        [JsonProperty("geofence_configs")]
        public DateTimeOffset? GeofenceConfigs { get; internal set; }
    }
}
