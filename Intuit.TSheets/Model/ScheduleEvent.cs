// *******************************************************************************
// <copyright file="ScheduleEvent.cs" company="Intuit">
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
    /// ScheduleEvent, for assigning upcoming jobs to employees on a schedule calendar.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class ScheduleEvent : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleEvent"/> class.
        /// </summary>
        public ScheduleEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleEvent"/> class,
        /// with minimal required parameters to create the new entity. 
        /// </summary>
        /// <param name="scheduleCalendarId">
        /// The id of the calendar that contains this schedule event.
        /// </param>
        /// <param name="start">
        /// The date/time that represents the start time of this schedule event.
        /// </param>
        /// <param name="end">
        /// The date/time that represents the end time of this schedule event.
        /// </param>
        /// <param name="allDay">
        /// The value indicating whether or not the event is all-day.
        /// </param>
        public ScheduleEvent(
            int scheduleCalendarId,
            DateTimeOffset start,
            DateTimeOffset end,
            bool allDay)
        {
            ScheduleCalendarId = scheduleCalendarId;
            Start = start;
            End = end;
            AllDay = allDay;
        }

        /// <summary>
        /// Gets id of the schedule event.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id of the calendar that contains this schedule event.
        /// </summary>
        [JsonProperty("schedule_calendar_id")]
        public int? ScheduleCalendarId { get; set; }

        /// <summary>
        /// Gets or sets the date/time that represents the start time of this schedule event.
        /// </summary>
        [JsonProperty("start")]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        /// Gets or sets the date/time that represents the end time of this schedule event.
        /// </summary>
        [JsonProperty("end")]
        public DateTimeOffset? End { get; set; }

        /// <summary>
        /// Gets or sets whether or not the event is all-day.
        /// </summary>
        /// <remarks>
        /// If true, the event duration is all day on the day specified in start. If false,
        /// the event duration is determined by date/time specified in end.
        /// </remarks>
        [JsonProperty("all_day")]
        public bool? AllDay { get; set; }

        /// <summary>
        /// Gets the id of the user that this event belongs to.
        /// </summary>
        /// <remarks>
        /// This field is deprecated and will be removed from a future release.
        /// New applications should use <see cref="AssignedUserIds"/>.
        /// </remarks>
        [NoSerializeOnWrite]
        [JsonProperty("user_id")]
        public int? UserId { get; internal set; }

        /// <summary>
        /// Gets the value indicating Whether or not the schedule event is assigned.
        /// </summary>
        /// <remarks>
        /// This field is deprecated and will be removed from a future release.
        /// New applications should use <see cref="AssignedUserIds"/>.
        /// </remarks>/// 
        [NoSerializeOnWrite]
        [JsonProperty("unassigned")]
        public bool? Unassigned { get; internal set; }

        /// <summary>
        /// Gets or sets the ids of the user(s) assigned to this event.
        /// </summary>
        /// <remarks>
        /// Empty if the event is unassigned. Changing the assigned user IDs of
        /// an event may result in multiple event modifications.
        /// </remarks>
        [JsonProperty("assigned_user_ids")]
        public IList<int> AssignedUserIds { get; set; }

        /// <summary>
        /// Gets or sets the id of the jobcode associated with this event.
        /// </summary>
        [JsonProperty("jobcode_id")]
        public int? JobcodeId { get; set; }

        /// <summary>
        /// Gets or sets the status of the schedule event.
        /// </summary>
        /// <remarks>
        /// If true, the event is active. If false, the event has been deleted/archived.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether or not the schedule event is in a draft state.
        /// </summary>
        /// <remarks>
        /// If true, the event is a draft. If false, the event is published. Saving a published
        /// event will send the appropriate event published notifications to the assigned users.
        /// </remarks>
        [JsonProperty("draft")]
        public bool? Draft { get; set; }

        /// <summary>
        /// Gets or sets the time zone of the schedule event. (i.e. America/Denver).
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Gets or sets the title or name of this event.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets notes associated with the event.
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the location of the event.
        /// </summary>
        /// <remarks>
        /// Location can be an address, business name, GPS coordinate, etc., so when users
        /// click on the location it will open it up in their mapping application.
        /// </remarks>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the color code assigned to this schedule event.
        /// </summary>
        /// <remarks>
        /// See <see cref="ScheduleEventColor"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("color")]
        public ScheduleEventColor? Color { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CustomField"/> items associated with this schedule event.
        /// </summary>
        /// <remarks>
        /// Only present if the Advanced Tracking Add-on is installed. This is a key/value map of
        /// <see cref="CustomField"/> ids to <see cref="CustomFieldItem"/> objects that are
        /// associated with the event.
        /// </remarks>
        [JsonProperty("customfields")]
        public IDictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets the date/time when this schedule event was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the date/time when this schedule event was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }
    }
}
