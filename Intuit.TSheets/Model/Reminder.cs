// *******************************************************************************
// <copyright file="Reminder.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NJsonSchema;
    using NJsonSchema.Annotations;
    
    /// <summary>
    /// Reminder, for pushing Clock-In and Clock-Out reminder notifications
    /// to employees of your company.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class Reminder : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reminder"/> class.
        /// </summary>
        public Reminder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reminder"/> class,
        /// with minimal required parameters to create the new entity. 
        /// </summary>
        /// <param name="userId">
        /// Id of the user that this reminder pertains to. A value of 0 indicates that this is a company-wide reminder.
        /// </param> 
        /// <param name="reminderType">
        /// The type of this reminder object.
        /// </param>
        /// <param name="dueTime">
        /// The 24-hour time that the reminder should be sent. The time should be in even 5 minute increments. For example: '13:45:00' or '08:00:00'.
        /// </param>
        /// <param name="dueDaysOfWeek">
        /// The comma-separated list of the days of the week when the reminder should be sent. For example: 'Mon,Tue,Wed,Thu,Fri' or 'Tue,Sat'.
        /// </param>
        /// <param name="distributionMethods">
        /// The comma-separated list of the transport method(s) indicating how the reminder message should be sent.
        /// </param>
        /// <param name="active">
        /// The status of the reminder. If true, this reminder is active and will be evaluated at the
        /// <see cref="DueTime"/> and <see cref="DueDaysOfWeek"/>. If false, this reminder is inactive
        /// and will not be evaluated. If false for user-specific reminders, then the company-wide
        /// reminder of the same reminder type will apply.
        /// </param>
        /// <param name="enabled">
        /// The value indicating whether or not the reminder is enabled. If true, the reminder is enabled
        /// and will be sent at the <see cref="DueTime"/> and <see cref="DueDaysOfWeek"/>. If false, the
        /// reminder is disabled and will not be sent. A user with an active but disabled reminder will not
        /// receive that reminder type regardless of how company-wide reminders are configured.
        /// </param>
        public Reminder(
            int userId,
            ReminderTypes reminderType,
            DateTimeOffset dueTime,
            DaysOfTheWeek dueDaysOfWeek,
            ReminderDistributionMethods distributionMethods,
            bool active,
            bool enabled)
        {
            UserId = userId;
            ReminderType = reminderType;
            DueTime = dueTime;
            DueDaysOfWeek = dueDaysOfWeek;
            DistributionMethods = distributionMethods;
            Active = active;
            Enabled = enabled;
        }

        /// <summary>
        /// Gets id of the reminder.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets id of the user that this reminder pertains to.
        /// </summary>
        /// <remarks>
        /// A value of 0 indicates that this is a company-wide reminder.
        /// </remarks>
        [JsonProperty("user_id")]
        public int? UserId { get; internal set; }

        /// <summary>
        /// Gets or sets the type of this reminder object.
        /// </summary>
        /// <remarks>
        /// See <see cref="ReminderTypes"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("reminder_type")]
        public ReminderTypes? ReminderType { get; set; }

        /// <summary>
        /// Gets or sets the 24-hour time that the reminder should be sent.
        /// </summary>
        /// <remarks>
        /// The time should be in even 5 minute increments. For example: '13:45:00' or '08:00:00'.
        /// </remarks>
        [JsonConverter(typeof(TimeFormatConverter))]
        [JsonSchema(JsonObjectType.String, Format = "time")]
        [JsonProperty("due_time")]
        public DateTimeOffset? DueTime { get; set; }

        /// <summary>
        /// Gets or sets the comma-separated list of the days of the week when the reminder should be sent. 
        /// </summary>
        /// <remarks>
        /// See <see cref="DaysOfTheWeek"/> for allowable values.
        /// For example: 'Mon,Tue,Wed,Thu,Fri' or 'Tue,Sat'.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("due_days_of_week")]
        public DaysOfTheWeek? DueDaysOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the comma-separated list of the transport method(s) indicating how the reminder message should be sent.
        /// </summary>
        /// <remarks>
        /// See <see cref="ReminderDistributionMethods"/> for allowable values. The 'Push' method utilizes the
        /// TSheets mobile app to deliver the notification to a mobile device.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("distribution_methods")]
        public ReminderDistributionMethods? DistributionMethods { get; set; }

        /// <summary>
        /// Gets or sets the status of the reminder.
        /// </summary>
        /// <remarks>
        /// If true, this reminder is active and will be evaluated at the <see cref="DueTime"/> and
        /// <see cref="DueDaysOfWeek"/>. If false, this reminder is inactive and will not be evaluated.
        /// If false for user-specific reminders, then the company-wide reminder of the same reminder
        /// type will apply.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether or not the reminder is enabled.
        /// </summary>
        /// <remarks>
        /// If true, the reminder is enabled and will be sent at the <see cref="DueTime"/> and <see cref="DueDaysOfWeek"/>.
        /// If false, the reminder is disabled and will not be sent. A user with an active but disabled reminder will not
        /// receive that reminder type regardless of how company-wide reminders are configured.
        /// </remarks>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets date/time when this reminder was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets date/time when this reminder was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }
    }
}
