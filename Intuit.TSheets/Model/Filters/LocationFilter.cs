// *******************************************************************************
// <copyright file="LocationFilter.cs" company="Intuit">
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
    /// Filter for narrowing down the results of a call to retrieve <see cref="Location"/> entities.
    /// </summary>
    [JsonObject]
    public class LocationFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the location ids you'd like to filter on.
        /// </summary>
        /// <remarks>
        /// If omitted, all locations matching other specified filters are returned.
        /// </remarks>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<int> Ids { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering by active or inactive state, or both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("active")]
        public TristateChoice? Active { get; set; }

        /// <summary>
        /// Gets or sets the geocoding statuses you'd like to filter on.
        /// </summary>
        /// <remarks>
        /// If omitted, all locations matching other specified filters are returned.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("geocoding_status")]
        public GeocodingStatus? GeocodingStatus { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those locations modified before this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those locations modified after this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to filter by jobcode assignment.
        /// </summary>
        /// <remarks>
        /// If specified, only locations mapped to a jobcode the user is assigned to will be returned.
        /// </remarks>
        [JsonProperty("by_jobcode_assignment")]
        public bool? ByJobcodeAssignment { get; set; }
    }
}
