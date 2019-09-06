// *******************************************************************************
// <copyright file="ReportOrder.cs" company="Intuit">
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
    using System.Runtime.Serialization;

    /// <summary>
    /// The supported sort orders for reports.
    /// </summary>
    public enum ReportOrder
    {
        /// <summary>
        /// Report ordered by user name.
        /// </summary>
        [EnumMember(Value = "username")]
        UserName,

        /// <summary>
        /// Report ordered by user first name.
        /// </summary>
        [EnumMember(Value = "first_name")]
        FirstName,

        /// <summary>
        /// Report ordered by user first name.
        /// </summary>
        [EnumMember(Value = "last_name")]
        LastName,

        /// <summary>
        /// Report ordered by group name.
        /// </summary>
        [EnumMember(Value = "group_name")]
        GroupName,

        /// <summary>
        /// Report ordered by group id.
        /// </summary>
        [EnumMember(Value = "group_id")]
        GroupId,

        /// <summary>
        /// Report ordered by shift time.
        /// </summary>
        [EnumMember(Value = "shift_seconds")]
        ShiftSeconds,

        /// <summary>
        /// Report ordered by day seconds.
        /// </summary>
        [EnumMember(Value = "day_seconds")]
        DaySeconds
    }
}
