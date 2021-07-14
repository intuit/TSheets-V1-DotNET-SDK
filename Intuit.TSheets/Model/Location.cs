// *******************************************************************************
// <copyright file="Location.cs" company="Intuit">
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
    /// Location.  A physical address that can be attached to a jobcode. GPS data will automatically
    /// be added by the geocode service after the location has been created, provided the location's
    /// address is valid.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class Location : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class,
        /// with minimal required parameters to create the new entity. 
        /// </summary>
        /// <param name="addr1">
        /// The first line of the location's address.
        /// </param>
        /// <param name="addr2">
        /// The second line of the location's address.
        /// </param>
        /// <param name="city">
        /// The city of the location's address.
        /// </param>
        /// <param name="state">
        /// The state of the location's address.
        /// </param>
        /// <param name="zip">
        /// The zip code of the location's address.
        /// </param>
        /// <param name="country">
        /// The country of the location's address.
        /// </param>
        public Location(string addr1, string addr2, string city, string state, string zip, string country)
        {
            Addr1 = addr1;
            Addr2 = addr2;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }

        /// <summary>
        /// Gets the id of the location.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the first line of the location's address.
        /// </summary>
        [JsonProperty("addr1")]
        public string Addr1 { get; set; }

        /// <summary>
        /// Gets or sets the second line of the location's address.
        /// </summary>
        [JsonProperty("addr2")]
        public string Addr2 { get; set; }

        /// <summary>
        /// Gets or sets the city of the location's address.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state of the location's address.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the location's address.
        /// </summary>
        [JsonProperty("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the country of the location's address
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets the formatted address.
        /// </summary>
        /// <remarks>
        /// Address is built from the objects addr1, addr2, city, state, and zip.
        /// If the location doesn't contain addr1, addr2, or city properties, the value
        /// will default what is set in the <see cref="Label"/> property.
        /// </remarks>
        [NoSerializeOnWrite]
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; internal set; }

        /// <summary>
        /// Gets or sets the status of the location.
        /// </summary>
        /// <remarks>
        /// If true, this location is active. If false, this location is archived.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the location (in signed degrees format).
        /// </summary>
        [JsonProperty("latitude")]
        public float? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the location (in signed degrees format).
        /// </summary>
        [JsonProperty("longitude")]
        public float? Longitude { get; set; }

        /// <summary>
        /// Gets the MD5 hash of the unique id for the location returned from the geocoding service.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("place_id_hash")]
        public string PlaceIdHash { get; internal set; }

        /// <summary>
        /// Gets the formatted name for the location.
        /// </summary>
        /// <remarks>
        /// If the location was found using the geocode service the formatted address will be
        /// saved in this field, otherwise it will be what the user has named the location.
        /// </remarks>
        [NoSerializeOnWrite]
        [JsonProperty("label")]
        public string Label { get; internal set; }

        /// <summary>
        /// Gets or sets the notes related to the location.
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets the geocoding status of this address.
        /// </summary>
        /// <remarks>
        /// See <see cref="GeocodingStatus"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [NoSerializeOnWrite]
        [JsonProperty("geocoding_status")]
        public GeocodingStatus? GeocodingStatus { get; internal set; }

        /// <summary>
        /// Gets the date/time when this location was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the date/time when this location was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// Gets or sets the key/value map of all the objects linked to this location and the corresponding object ids.
        /// </summary>
        [JsonProperty("linked_objects")]
        public LocationLinkedObjectIds LinkedObjects { get; set; }

        /// <summary>
        /// Gets the id of the geofence config associated with this location.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("geofence_config_id")]
        public long? GeofenceConfigId { get; internal set; }
    }
}
