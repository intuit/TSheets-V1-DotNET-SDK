// *******************************************************************************
// <copyright file="CustomFieldItemFilterFilter.cs" company="Intuit">
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
    /// Filter for narrowing down the results of a call to retrieve <see cref="Model.CustomFieldItemFilter"/> entities.
    /// </summary>
    [JsonObject]
    public class CustomFieldItemFilterFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the value to filter results to only those with given jobcode id.
        /// </summary>
        [JsonProperty("jobcode_id")]
        public long? JobcodeId { get; set; }

        /// <summary>
        /// Gets or sets the value to filter results to only those with given user id.
        /// </summary>
        /// <remarks>
        /// You can also include items for this user's group automatically if you
        /// include the 'IncludeUserGroup' parameter.
        /// </remarks>
        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// Gets or sets the value to filter results to only those with given group id.
        /// </summary>
        /// <remarks>
        /// You can also include items for this user's group automatically if you
        /// include the <see cref="IncludeUserGroup"/> parameter.
        /// </remarks>
        [JsonProperty("group_id")]
        public long? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to filter by the user's group.
        /// </summary>
        /// <remarks>
        /// If true, and a UserId is supplied, will return filters for that user's group as well.
        /// </remarks>
        [JsonProperty("include_user_group")]
        public bool? IncludeUserGroup { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to additionally return jobcode filters.
        /// </summary>
        [JsonProperty("include_jobcode_filters")]
        public bool? IncludeJobcodeFilters { get; set; }

        /// <summary>
        /// Gets or sets the state value on which to filter.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("active")]
        public TristateChoice? Active { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Model.CustomFieldItemFilter"/> ids on which to filter.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<long> Ids { get; set; }

        /// <summary>
        /// Gets or sets the date/time for which only results modified before it will be returned.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the date/time for which only results modified after it will be returned.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }
    }
}
