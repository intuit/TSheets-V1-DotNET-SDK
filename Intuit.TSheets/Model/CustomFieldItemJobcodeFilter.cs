// *******************************************************************************
// <copyright file="CustomFieldItemJobcodeFilter.cs" company="Intuit">
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
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// CustomFieldItemJobcodeFilter, used to limit the choices that should be made available for selecting
    /// custom field items for a particular custom field based on a user or group, within the web UI. 
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class CustomFieldItemJobcodeFilter : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the filter item.
        /// </summary>
        [NoSerializeOnCreate] 
        [JsonProperty("id")]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets the date/time when last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the filtered custom field items.
        /// </summary>
        /// <remarks>
        /// Each entity represents a custom field's active filters where the key is the custom field id
        /// and the value is an array of item ids to which the jobcode is assigned.
        /// </remarks>
        [JsonProperty("filtered_customfielditems")]
        public IDictionary<string, IList<long>> FilteredCustomFieldItems { get; internal set; }
    }
}
