// *******************************************************************************
// <copyright file="Geolocation.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Geolocation. A set of GPS data corresponding to an employee's location
    /// at a specific time, while on-the-clock.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class Geolocation : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Geolocation"/> class.
        /// </summary>
        public Geolocation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Geolocation"/> class,
        /// with minimal required parameters to create the new entity. 
        /// </summary>
        /// <param name="created">Date/time when this geolocation was created.</param>
        /// <param name="userId">Id of the geolocation.</param>
        /// <param name="accuracy">The radius of accuracy around the geolocation in meters.</param>
        /// <param name="altitude">The altitude of the geolocation in meters.</param>
        /// <param name="latitude">The latitude of the geolocation in degrees.</param>
        /// <param name="longitude">The longitude of the geolocation in degrees.</param>
        public Geolocation(
            DateTimeOffset created,
            long userId,
            float accuracy,
            float altitude,
            float latitude,
            float longitude)
        {
            Created = created;
            UserId = userId;
            Accuracy = accuracy;
            Altitude = altitude;
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Gets the id of the geolocation.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id for the user that this geolocation belongs to.
        /// </summary>
        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// Gets or sets the radius of accuracy around the geolocation in meters.
        /// </summary>
        [JsonProperty("accuracy")]
        public float? Accuracy { get; set; }

        /// <summary>
        /// Gets or sets the altitude of the geolocation in meters.
        /// </summary>
        [JsonProperty("altitude")]
        public float? Altitude { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the geolocation in degrees.
        /// </summary>
        [JsonProperty("latitude")]
        public float? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the geolocation in degrees.
        /// </summary>
        [JsonProperty("longitude")]
        public float? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the speed of travel (in meters per second) at time of geolocation recording.
        /// </summary>
        [JsonProperty("speed")]
        public float? Speed { get; set; }

        /// <summary>
        /// Gets or sets the heading of the geolocation, in degrees.
        /// </summary>
        [JsonProperty("heading")]
        public int? Heading { get; set; }

        /// <summary>
        /// Gets or sets the method by which the GPS point was obtained.
        /// </summary>
        /// <remarks>
        /// See <see cref="GeolocationSource"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("source")]
        public GeolocationSource? Source { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the device associated with this geolocation.
        /// </summary>
        [JsonProperty("device_identifier")]
        public string DeviceIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the date/time when this geolocation was created.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; set; }
    }
}
