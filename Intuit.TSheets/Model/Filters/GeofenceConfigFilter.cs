// *******************************************************************************
// <copyright file="GeofenceConfigFilter.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="GeofenceConfig"/> entities.
    /// </summary>
    [JsonObject]
    public class GeofenceConfigFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<int> Ids { get; set; }

        /// <summary>
        /// Gets or sets the geofence configurations you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public GeofenceConfigType? GeofenceConfig { get; set; }

        /// <summary>
        /// Gets or sets the type ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("type_ids")]
        public IEnumerable<int> TypeIds { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to return enabled or disabled geofence configurations.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to filter by active or inactive state, or both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("active")]
        public TristateChoice? Active { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those geofence configurations modified before this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those geofence configurations modified after this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to limit results by jobcode assignment.
        /// </summary>
        /// <remarks>
        /// If specified, only geofence configurations related to a location that is mapped to a jobcode the user is assigned to will be returned. 
        /// </remarks>
        [JsonProperty("by_jobcode_assignment")]
        public bool? ByJobcodeAssignment { get; set; }
    }
}
