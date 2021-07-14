// *******************************************************************************
// <copyright file="ReminderFilter.cs" company="Intuit">
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
    /// Filter for narrowing down the results of a call to retrieve <see cref="Reminder"/> entities.
    /// </summary>
    [JsonObject]
    public class ReminderFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the user ids you'd like to filter on.
        /// </summary>
        /// <remarks>
        /// Include a user_id of 0 to retrieve company-wide reminders.
        /// </remarks>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<long> UserIds { get; set; }

        /// <summary>
        /// Gets or sets the reminder types you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("reminder_types")]
        public ReminderTypes? ReminderTypes { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those reminders modified after this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }
    }
}
