// *******************************************************************************
// <copyright file="ScheduleEventFilter.cs" company="Intuit">
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
    /// Filter for narrowing down the results of a call to retrieve <see cref="ScheduleEvent"/> entities.
    /// </summary>
    [JsonObject]
    public class ScheduleEventFilter : EntityFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleEventFilter"/> class.
        /// </summary>
        public ScheduleEventFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleEventFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="ids">
        /// The schedule event ids you'd like to filter on.
        /// </param>
        /// <param name="scheduleCalendarIds">
        /// The schedule calendar ids you'd like to filter on.
        /// </param>
        public ScheduleEventFilter(IEnumerable<long> ids, IEnumerable<long> scheduleCalendarIds)
        {
            Ids = ids;
            ScheduleCalendarIds = scheduleCalendarIds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleEventFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="modifiedSince">
        /// The filter for returning only those schedule events modified after this date/time.
        /// </param>
        /// <param name="modifiedBefore">
        /// The filter for returning only those schedule events modified before this date/time.
        /// </param>
        /// <param name="scheduleCalendarIds">
        /// The schedule calendar ids you'd like to filter on.
        /// </param>
        public ScheduleEventFilter(DateTimeOffset modifiedSince, DateTimeOffset modifiedBefore, IEnumerable<long> scheduleCalendarIds)
        {
            ModifiedSince = modifiedSince;
            ModifiedBefore = modifiedBefore;
            ScheduleCalendarIds = scheduleCalendarIds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleEventFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="start">
        /// The value for filtering schedule events to a date range start.
        /// </param>
        /// <param name="scheduleCalendarIds">
        /// The schedule calendar ids you'd like to filter on.
        /// </param>
        public ScheduleEventFilter(DateTimeOffset start, IEnumerable<long> scheduleCalendarIds)
        {
            Start = start;
            ScheduleCalendarIds = scheduleCalendarIds;
        }

        /// <summary>
        /// Gets or sets the schedule event ids you'd like to filter on. Only schedule events with an id set to one of these values will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<long> Ids { get; set; }

        /// <summary>
        /// Gets or sets the user ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<long> UserIds { get; set; }

        /// <summary>
        /// Gets or sets the schedule calendar ids you'd like to filter on.
        /// </summary>
        /// <remarks>
        /// Only schedule events with a schedule calendar id set to one of these values will be returned.
        /// </remarks>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("schedule_calendar_ids")]
        public IEnumerable<long> ScheduleCalendarIds { get; set; }

        /// <summary>
        /// Gets or sets the jobcode ids you'd like to filter on. Only schedule events with these jobcodes will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("jobcode_ids")]
        public IEnumerable<long> JobcodeIds { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering schedule events to a date range start.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("start")]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering schedule events to a date range end.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("end")]
        public DateTimeOffset? End { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering by active or inactive state, or both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("active")]
        public TristateChoice? Active { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering by draft state.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("draft")]
        public TristateChoice? Draft { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering by the per-user instancing of the events returned.
        /// </summary>
        /// <remarks>
        /// If 'Instance' is specified, events that are assigned to multiple users will be returned as individual single events for each assigned user.
        /// If 'Base' is specified, events that are assigned to multiple users will be returned as one combined event for all assignees.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("team_events")]
        public TeamEvent? TeamEvents { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those schedule events modified before this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those schedule events modified after this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }
    }
}
