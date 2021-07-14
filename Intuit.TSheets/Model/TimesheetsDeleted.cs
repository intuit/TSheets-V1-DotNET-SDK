// *******************************************************************************
// <copyright file="TimesheetsDeleted.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// TimesheetsDeleted, a deleted instance of a <see cref="Timesheet"/>.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class TimesheetsDeleted : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the timesheet.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets the user id for the user that this timesheet belongs to.
        /// </summary>
        [JsonProperty("user_id")]
        public long? UserId { get; internal set; }

        /// <summary>
        /// Gets the id for the jobcode that this timesheet is recorded against.
        /// </summary>
        [JsonProperty("jobcode_id")]
        public long? JobcodeId { get; internal set; }

        /// <summary>
        /// Gets the date/time that represents the start time of this timesheet.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("start")]
        public DateTimeOffset? Start { get; internal set; }

        /// <summary>
        /// Gets the date/time that represents the end time of this timesheet.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("end")]
        public DateTimeOffset? End { get; internal set; }

        /// <summary>
        /// Gets the timesheet's date.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("date")]
        public DateTimeOffset? Date { get; internal set; }

        /// <summary>
        /// Gets the total number of seconds recorded for this timesheet.
        /// </summary>
        [JsonProperty("duration")]
        public int? Duration { get; internal set; }

        /// <summary>
        /// Gets the value indication whether or not the timesheet is locked.
        /// </summary>
        /// <remarks>
        /// If greater than 0, the timesheet is locked for editing. A timesheet could be locked for various reasons,
        /// such as being exported, invoiced, etc. This setting does not reflect the approved or submitted status of
        /// time. To determine whether a timesheet falls within an approved or submitted time frame, check the
        /// <see cref="User.SubmittedTo"/> or <see cref="User.ApprovedTo"/> properties of the <see cref="User"/>
        /// object that owns the timesheet.
        /// </remarks>
        [JsonProperty("locked")]
        public int? Locked { get; internal set; }

        /// <summary>
        /// Gets notes associated with this timesheet.
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; internal set; }

        /// <summary>
        /// Gets the <see cref="CustomFieldItem"/> objects that are associated with the timesheet.
        /// </summary>
        /// <remarks>
        /// This property is present only if the Advanced Tracking Add-On is installed.
        /// </remarks>
        [JsonProperty("customfields")]
        public IDictionary<string, string> CustomFields { get; internal set; }

        /// <summary>
        /// Gets the date/time when this timesheet was created.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// Gets the date/time when this timesheet was last modified.
        /// </summary>
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the type of the timesheet.
        /// </summary>
        /// <remarks>
        /// See <see cref="TimesheetType"/> for allowable values.  Regular timesheets have a <see cref="Start"/> and
        /// <see cref="End"/> time (duration is calculated by TSheets). Manual timesheets have a <see cref="Date"/>
        /// and a <see cref="Duration"/>.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public TimesheetType? TimesheetType { get; internal set; }
    }
}
