// *******************************************************************************
// <copyright file="CustomFieldItemFilter.cs" company="Intuit">
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
    /// Filter for narrowing down the results of a call to retrieve <see cref="CustomFieldItem"/> entities.
    /// </summary>
    [JsonObject]
    public class CustomFieldItemFilter : EntityFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldItemFilter"/> class.
        /// </summary>
        public CustomFieldItemFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldItemFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="customFieldId">
        /// Id of the custom field whose items you'd like to list.
        /// </param>
        public CustomFieldItemFilter(long customFieldId)
        {
            CustomFieldId = customFieldId;
        }

        /// <summary>
        /// Gets or sets the id of the custom field whose items you'd like to filter on.
        /// </summary>
        [JsonProperty("customfield_id")]
        public long? CustomFieldId { get; set; }

        /// <summary>
        /// Gets or sets the ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<long> Ids { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to filter by active or inactive state, or both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("active")]
        public TristateChoice? Active { get; set; }

        /// <summary>
        /// Gets or sets the filter by modified before date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter by modified since date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }
    }
}
