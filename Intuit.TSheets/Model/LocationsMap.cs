// *******************************************************************************
// <copyright file="LocationsMap.cs" company="Intuit">
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
    /// LocationsMap, for mapping <see cref="Location"/> objects to <see cref="Jobcode"/> objects.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class LocationsMap : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the locations map.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets the name of the entity the location is mapped to.
        /// </summary>
        /// <remarks>
        /// See <see cref="LocationsMapXTableType"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("x_table")]
        public LocationsMapXTableType? XTable { get; internal set; }

        /// <summary>
        /// Gets the id of the entity the location is mapped to.
        /// </summary>
        [JsonProperty("x_id")]
        public int? XId { get; internal set; }

        /// <summary>
        /// Gets the id of the location that is mapped to the entity.
        /// </summary>
        [JsonProperty("location_id")]
        public int? LocationId { get; internal set; }

        /// <summary>
        /// Gets the date/time when this locations map was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the date/time when this locations map was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }
    }
}
