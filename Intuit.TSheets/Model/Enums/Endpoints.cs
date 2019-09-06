// *******************************************************************************
// <copyright file="Endpoints.cs" company="Intuit">
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

namespace Intuit.TSheets.Model.Enums
{
    using System;
    using System.Runtime.Serialization;
    using Intuit.TSheets.Model.Filters;

    /// <summary>
    /// The TSheets API endpoints.
    /// </summary>
    /// <remarks>
    /// Used with <see cref="LastModifiedTimestampsFilter"/> object to specify
    /// for which endpoints the timestamp values are to be returned.
    /// </remarks>
    [Flags]
    public enum Endpoints
    {
        /// <summary>
        /// The CurrentUser endpoint.
        /// </summary>
        [EnumMember(Value = "current_user")]
        CurrentUser = 0x1,

        /// <summary>
        ///  The CustomFields endpoint.
        /// </summary>
        [EnumMember(Value = "customfields")]
        CustomFields = 0x2,

        /// <summary>
        ///  The CustomFieldItems endpoint.
        /// </summary>
        [EnumMember(Value = "customfielditems")]
        CustomFieldItems = 0x4,

        /// <summary>
        /// The EffectiveSettings endpoint.
        /// </summary>
        [EnumMember(Value = "effective_settings")]
        EffectiveSettings = 0x8,

        /// <summary>
        ///  The Geolocations endpoint.
        /// </summary>
        [EnumMember(Value = "geolocations")]
        Geolocations = 0x10,

        /// <summary>
        ///  The Jobcodes endpoint.
        /// </summary>
        [EnumMember(Value = "jobcodes")]
        Jobcodes = 0x20,

        /// <summary>
        ///  The JobcodeAssignments endpoint.
        /// </summary>
        [EnumMember(Value = "jobcode_assignments")]
        JobcodeAssignments = 0x40,

        /// <summary>
        ///  The Timesheets endpoint.
        /// </summary>
        [EnumMember(Value = "timesheets")]
        Timesheets = 0x80,

        /// <summary>
        ///  The TimesheetsDeleted endpoint.
        /// </summary>
        [EnumMember(Value = "timesheets_deleted")]
        TimesheetsDeleted = 0x100,

        /// <summary>
        ///  The Users endpoint.
        /// </summary>
        [EnumMember(Value = "users")]
        Users = 0x200,

        /// <summary>
        ///  The Reminders endpoint.
        /// </summary>
        [EnumMember(Value = "reminders")]
        Reminders = 0x400,

        /// <summary>
        ///  The Locations endpoint.
        /// </summary>
        [EnumMember(Value = "locations")]
        Locations = 0x800,

        /// <summary>
        ///  The GeofenceConfigs endpoint.
        /// </summary>
        [EnumMember(Value = "geofence_configs")]
        GeofenceConfigs = 0x1000
    }
}
