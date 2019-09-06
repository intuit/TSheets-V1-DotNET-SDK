// *******************************************************************************
// <copyright file="GeofenceConfig.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Geofence configuration. Geofencing makes it easy to track the time when
    /// an employee arrives at or leaves a job site.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class GeofenceConfig : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the geofence config.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets the type of entity the geofence config is related to.
        /// </summary>
        /// <remarks>
        /// See <see cref="GeofenceConfigType"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public GeofenceConfigType? GeofenceConfigType { get; internal set; }

        /// <summary>
        /// Gets the id of the entity the geofence config is related to.
        /// </summary>
        [JsonProperty("type_id")]
        public int? TypeId { get; internal set; }

        /// <summary>
        /// Gets the status of this geofence config.
        /// </summary>
        /// <remarks>
        /// If true, this geofence config is active. If false, this geofence config is archived.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; internal set; }

        /// <summary>
        /// Gets the value indicating whether a geofence for the associated entity should be enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; internal set; }

        /// <summary>
        /// Gets the size of the geofence.
        /// </summary>
        [JsonProperty("radius")]
        public int? Radius { get; internal set; }

        /// <summary>
        /// Gets the date/time when this geofence config was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the date/time when this geofence config was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }
    }
}
