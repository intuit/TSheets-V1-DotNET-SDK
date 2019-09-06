// *******************************************************************************
// <copyright file="CustomFieldItem.cs" company="Intuit">
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
    /// A Custom Field Item represents an allowable value for a Custom Field Object of managed-list type.
    /// Each item represents a single drop-down choice displayed to the user in the web UI. The API
    /// provides methods to Create, Read, and Update custom field items. Set the active property false
    /// to archive (i.e. soft delete) a custom field item.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class CustomFieldItem : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldItem"/> class.
        /// </summary>
        public CustomFieldItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldItem"/> class,
        /// with minimal required parameters to create the new entity.
        /// </summary>
        /// <param name="name">
        /// The name of the custom field item.
        /// </param>
        /// <param name="customFieldId">
        /// The id for the custom field that this item belongs to.
        /// </param>
        public CustomFieldItem(string name, int customFieldId)
        {
            Name = name;
            CustomFieldId = customFieldId;
        }

        /// <summary>
        /// Gets the id of the custom field item.
        /// </summary>
        [NoSerializeOnCreate] 
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id for the custom field that this item belongs to.
        /// </summary>
        [JsonProperty("customfield_id")]
        public int? CustomFieldId { get; set; }

        /// <summary>
        /// Gets or sets the name of the custom field item.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviated alias for the custom field item.
        /// </summary>
        /// <remarks>
        /// A shortened code or alias that consists
        /// only of letters and numbers.
        /// </remarks>
        [JsonProperty("short_code")]
        public string ShortCode { get; set; }

        /// <summary>
        /// Gets or sets the status of the custom field item.
        /// </summary>
        /// <remarks>
        /// If 'true', this custom field item is active. If 'false', this custom field is archived.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets the date/time when this custom field item was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the ids of the <see cref="CustomField"/> objects that should be displayed when this custom field item is selected on a timesheet.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("required_customfields")]
        public IReadOnlyList<int> RequiredCustomFields { get; internal set; }
    }
}
