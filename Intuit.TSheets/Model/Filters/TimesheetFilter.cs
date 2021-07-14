// *******************************************************************************
// <copyright file="TimesheetFilter.cs" company="Intuit">
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
    /// Filter for narrowing down the results of a call to retrieve <see cref="Timesheet"/> entities.
    /// </summary>
    [JsonObject]
    public class TimesheetFilter : EntityFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimesheetFilter"/> class.
        /// </summary>
        public TimesheetFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimesheetFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="ids">
        /// The timesheet ids you'd like to filter on.
        /// </param>
        public TimesheetFilter(IEnumerable<long> ids)
        {
            Ids = ids;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimesheetFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="modifiedSince">
        /// The filter for returning only those timesheets modified after this date/time.
        /// </param>
        /// <param name="modifiedBefore">
        /// The filter for returning only those timesheets modified before this date/time.
        /// </param>
        public TimesheetFilter(DateTimeOffset modifiedSince, DateTimeOffset modifiedBefore)
        {
            ModifiedSince = modifiedSince;
            ModifiedBefore = modifiedBefore;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimesheetFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="startDate">
        /// The value for filtering timesheets to a date range start.
        /// </param>
        /// <param name="endDate">
        /// The value for filtering timesheets to a date range end.
        /// </param>
        /// <param name="onTheClock">
        /// The value indicating filtering by users who are on or off the clock, or both.
        /// </param>
        public TimesheetFilter(DateTimeOffset startDate, DateTimeOffset endDate, TristateChoice onTheClock)
        {
            StartDate = startDate;
            EndDate = endDate;
            OnTheClock = onTheClock;
        }

        /// <summary>
        /// Gets or sets the timesheet ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<long> Ids { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering timesheets to a date range start.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("start_date")]
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering timesheets to a date range end.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("end_date")]
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the jobcode ids you'd like to filter on. Only time recorded against these jobcodes or one of their children will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("jobcode_ids")]
        public IEnumerable<long> JobcodeIds { get; set; }

        /// <summary>
        /// Gets or sets the payroll ids you'd like to filter on. Only time recorded against users with these payroll ids will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("payroll_ids")]
        public IEnumerable<long> PayrollIds { get; set; }

        /// <summary>
        /// Gets or sets the user ids you'd like to filter on. Only timesheets linked to these users will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<long> UserIds { get; set; }

        /// <summary>
        /// Gets or sets the group ids you'd like to filter on. Only timesheets linked to users from these groups will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("group_ids")]
        public IEnumerable<long> GroupIds { get; set; }

        /// <summary>
        /// Gets or sets the value indicating filtering by users who are on or off the clock, or both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("on_the_clock")]
        public TristateChoice? OnTheClock { get; set; }

        /// <summary>
        /// Gets or sets the jobcode type you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("jobcode_type")]
        public JobcodeType? JobcodeType { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those timesheets modified before this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those timesheets modified before this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }
    }
}
