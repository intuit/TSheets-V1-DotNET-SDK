// *******************************************************************************
// <copyright file="GeolocationFilter.cs" company="Intuit">
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
    using Newtonsoft.Json;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="Geolocation"/> entities.
    /// </summary>
    [JsonObject]
    public class GeolocationFilter : EntityFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeolocationFilter"/> class.
        /// </summary>
        public GeolocationFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeolocationFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="ids">
        /// The geolocation ids you'd like to filter on.
        /// </param>
        public GeolocationFilter(IEnumerable<int> ids)
        {
            Ids = ids;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeolocationFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="modifiedSince">
        /// The filter for returning only those geolocations modified after this date/time.
        /// </param>
        /// <param name="modifiedBefore">
        /// The filter for returning only those geolocations modified before this date/time.
        /// </param>
        public GeolocationFilter(DateTimeOffset modifiedSince, DateTimeOffset modifiedBefore)
        {
            ModifiedSince = modifiedSince;
            ModifiedBefore = modifiedBefore;
        }

        /// <summary>
        /// Gets or sets the geolocation ids you'd like to filter on. Only geolocations with an id set to one of these values will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<int> Ids { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those geolocations modified before this date/time.
        /// </summary>
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those geolocations modified after this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }

        /// <summary>
        /// Gets or sets the users ids to which only those linked geolocations will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<int> UserIds { get; set; }

        /// <summary>
        /// Gets or sets the group ids to which only those linked geolocations will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("group_ids")]
        public IEnumerable<int> GroupIds { get; set; }
    }
}
