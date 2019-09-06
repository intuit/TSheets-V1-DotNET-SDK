// *******************************************************************************
// <copyright file="CustomField.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Custom Fields provides a means to extend the data that is tracked on employee time cards to capture custom
    /// activities beyond time tracking, e.g. mileage, equipment, expenses, etc. The API provides a Read method.
    /// Use the web UI to Create or Update custom fields.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class CustomField : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the custom field.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets the status of the custom field.
        /// </summary>
        /// <remarks>
        /// If 'true', this custom field is active. If 'false', this custom field is archived.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; internal set; }

        /// <summary>
        /// Gets the name of the custom field.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the abbreviated alias for the custom field.
        /// </summary>
        /// <remarks>
        /// A shortened code or alias that consists
        /// only of letters and numbers.
        /// </remarks>
        [JsonProperty("short_code")]
        public string ShortCode { get; internal set; }

        /// <summary>
        /// Gets the value indicating whether or not the custom field is required on the timesheet.
        /// </summary>
        [JsonProperty("required")]
        public bool? Required { get; internal set; }

        /// <summary>
        /// Gets the type of object this custom field applies to.
        /// </summary>
        /// <remarks>
        /// See <see cref="AppliesToType"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("applies_to")]
        public AppliesToType? AppliesTo { get; internal set; }

        /// <summary>
        /// Gets the type of custom field.
        /// </summary>
        /// <remarks>
        /// See <see cref="CustomFieldValueType"/> for allowable values.  If 'FreeFor', then it should
        /// be displayed in a UI as a text box, where users can enter values for this custom field and
        /// they'll get added automatically to the custom field if they don't already exist. If
        /// 'ManagedList', then it should be displayed as a select-box and users can only choose an
        /// existing value.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public CustomFieldValueType? CustomFieldType { get; internal set; }

        /// <summary>
        /// Gets the preferred user interface type.
        /// </summary>
        /// <remarks>
        /// See <see cref="CustomFieldUiPreferenceType"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("ui_preference")]
        public CustomFieldUiPreferenceType? UiPreference { get; internal set; }

        /// <summary>
        /// Gets the regular expression to be applied.
        /// </summary>
        /// <remarks>
        /// Expression is applied to any new items as they're added to the custom field.
        /// If they do not match the regex filter, they will not be added.
        /// </remarks> 
        [JsonProperty("regex_filter")]
        public string RegexFilter { get; internal set; }

        /// <summary>
        /// Gets the date/time when this custom field was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the date/time when this custom field was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// Gets the ids of custom fields that should be displayed when this custom field is visible on a timesheet.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("required_customfields")]
        public IReadOnlyList<int> RequiredCustomFields { get; internal set; }
    }
}
