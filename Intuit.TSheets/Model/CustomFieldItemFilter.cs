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

namespace Intuit.TSheets.Model
{
    using System;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;

    /// <summary>
    /// CustomFieldItemFilter, used to limit the choices that should be made available for selecting
    /// custom field items for a particular custom field based on a user or selected jobcode, within
    /// the web UI. 
    /// </summary>
    /// <remarks>
    /// Not to be confused with <see cref="Filters.CustomFieldItemFilter"/>.
    /// </remarks>
    [DataEntity]
    [JsonObject]
    public class CustomFieldItemFilter : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the custom field item.
        /// </summary>
        [NoSerializeOnCreate] 
        [JsonProperty("id")]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id for the custom field that this filter belongs to.
        /// </summary>
        [JsonProperty("customfield_id")]
        public long? CustomFieldId { get; set; }

        /// <summary>
        /// Gets or sets the id for the custom field item that this filter belongs to.
        /// </summary>
        [JsonProperty("customfielditem_id")]
        public long? CustomFieldItemId { get; set; }

        /// <summary>
        /// Gets or sets the entity type this filter relates to.
        /// </summary>
        /// <remarks>
        /// See <see cref="FilterAppliesTo"/> for allowable values. Together with applies_to_id,
        /// determines what this filtered item relates to. For example: If this value were 'Jobcodes'
        /// then the AppliesToId value would indicate which jobcode this filter referred to. If
        /// requested, the supplemental data will also contain this jobcode.
        /// </remarks>
        [JsonProperty("applies_to")]
        public FilterAppliesTo? AppliesTo { get; set; }

        /// <summary>
        /// Gets or sets the id of the jobcode, user, or group that this filter relates to.
        /// </summary>
        /// <remarks>
        /// Together with <see cref="AppliesTo"/>, determines what this filtered item relates to. For example:
        /// If the value of the <see cref="AppliesToId"/> field were 'Jobcodes' this value would indicate which
        /// jobcode this filter referred to. If requested, the supplemental data will also contain this jobcode.
        /// </remarks>
        [JsonProperty("applies_to_id")]
        public long? AppliesToId { get; set; }

        /// <summary>
        /// Gets or sets the status of the item filter object.
        /// </summary>
        /// <remarks>
        /// If false, this entity is considered archived or deleted.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets the date/time when this entity was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }
    }
}
