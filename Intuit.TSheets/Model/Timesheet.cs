// *******************************************************************************
// <copyright file="Timesheet.cs" company="Intuit">
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
    using System.ComponentModel;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    /// <summary>
    /// Timesheet, for tracking employee time to jobcodes.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class Timesheet : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Timesheet"/> class.
        /// </summary>
        public Timesheet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Timesheet"/> class, with
        /// minimal required parameters to create a regular 'on-the-clock' timesheet.
        /// </summary>
        /// <param name="userId">User id for the user that this timesheet belongs to.</param>
        /// <param name="jobcodeId">Jobcode id for the jobcode that this timesheet is recorded against.</param>
        /// <param name="start">Date/time that represents the start time of this timesheet.</param>
        public Timesheet(long userId, long jobcodeId, DateTimeOffset start)
        {
            UserId = userId;
            JobcodeId = jobcodeId;
            Type = TimesheetType.Regular;
            Start = start;

            // special value indicates there's no end time for the timesheet yet.
            End = DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Timesheet"/> class, with
        /// minimal required parameters to create a regular completed timesheet.
        /// </summary>
        /// <param name="userId">User id for the user that this timesheet belongs to.</param>
        /// <param name="jobcodeId">Jobcode id for the jobcode that this timesheet is recorded against.</param>
        /// <param name="start">Date/time that represents the start time of this timesheet.</param>
        /// <param name="end">Date/time that represents the end time of this timesheet.</param>
        public Timesheet(long userId, long jobcodeId, DateTimeOffset start, DateTimeOffset end)
        {
            UserId = userId;
            JobcodeId = jobcodeId;
            Type = TimesheetType.Regular;
            Start = start;
            End = end;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Timesheet"/> class, with
        /// minimal required parameters to create a manual completed timesheet.
        /// </summary>
        /// <param name="userId">Id for the user that this timesheet belongs to.</param>
        /// <param name="jobcodeId">Id for the jobcode that this timesheet is recorded against.</param>
        /// <param name="duration">The total amount of time recorded for this timesheet.</param>
        /// <param name="date">The date on which time is to be recorded for this timesheet.</param>
        public Timesheet(long userId, long jobcodeId, TimeSpan duration, DateTimeOffset date)
        {
            UserId = userId;
            JobcodeId = jobcodeId;
            Type = TimesheetType.Manual;
            Duration = (int?)duration.TotalSeconds;
            Date = date;
        }

        /// <summary>
        /// Gets the id of the timesheet.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id for the user that this timesheet belongs to.
        /// </summary>
        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// Gets or sets the id for the jobcode that this timesheet is recorded against.
        /// </summary>
        [JsonProperty("jobcode_id")]
        public long? JobcodeId { get; set; }

        /// <summary>
        /// Gets the value indicating whether or not the timesheet is locked.
        /// </summary>
        /// <remarks>
        /// If greater than 0, the timesheet is locked for editing. A timesheet could be locked for various reasons,
        /// such as being exported, invoiced, etc. This setting does not reflect the approved or submitted status of
        /// time. To determine whether a timesheet falls within an approved or submitted time frame, check the
        /// <see cref="User.SubmittedTo"/> or <see cref="User.ApprovedTo"/> properties of the <see cref="User"/>
        /// object that owns the timesheet.
        /// </remarks>
        [NoSerializeOnWrite]
        [JsonProperty("locked")]
        public int? Locked { get; internal set; }

        /// <summary>
        /// Gets or sets the notes associated with this timesheet.
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CustomFieldItem"/> objects that are associated with the timesheet.
        /// </summary>
        /// <remarks>
        /// This property is present only if the Advanced Tracking Add-On is installed.
        /// </remarks>
        [JsonProperty("customfields")]
        public IDictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets the date/time when this timesheet was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets or sets the type of the timesheet.
        /// </summary>
        /// <remarks>
        /// See <see cref="Type"/> for allowable values.  Regular timesheets have a <see cref="Start"/> and
        /// <see cref="End"/> time (duration is calculated by TSheets). Manual timesheets have a <see cref="Date"/>
        /// and a <see cref="Duration"/>.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public TimesheetType? Type { get; set; }

        /// <summary>
        /// Gets the value indicating whether or not the user is currently on the clock.
        /// </summary>
        /// <remarks>
        /// If true, the user is currently on the clock (i.e. not clocked out, so end time is empty).
        /// If false the user is not currently working on this timesheet. Manual timesheets will always
        /// have this property set as false.
        /// </remarks>
        [NoSerializeOnWrite]
        [JsonProperty("on_the_clock")]
        public bool? OnTheClock { get; internal set; }

        /// <summary>
        /// Gets or sets the ids of files attached to this timesheet.
        /// </summary>
        [JsonProperty("attached_files")]
        public IList<long> AttachedFiles { get; set; }

        /// <summary>
        /// Gets the user id for the user that initially created this timesheet.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created_by_user_id")]
        public long? CreatedByUserId { get; internal set; }

        /// <summary>
        /// Gets or sets the total number of seconds recorded for this timesheet.
        /// </summary>
        [JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// Gets or sets the timesheet's date.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// Gets or sets the date/time that represents the start time of this timesheet.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("start")]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        /// Gets or sets the date/time that represents the end time of this timesheet.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("end")]
        [DefaultValue("")]
        public DateTimeOffset? End { get; set; }

        /// <summary>
        /// Gets or sets the origin hint; an extra value, for timesheet history tracking.
        /// </summary>
        /// <remarks>
        /// This string is logged as part of the timesheet history when someone is 
        /// clocked in, clocked out, or a timesheet is created (with both in/out).
        /// </remarks>
        [JsonProperty("origin_hint")]
        public string OriginHint { get; set; }
    }
}
