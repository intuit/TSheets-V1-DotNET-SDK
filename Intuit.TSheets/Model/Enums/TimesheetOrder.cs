// *******************************************************************************
// <copyright file="TimesheetOrder.cs" company="Intuit">
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
    /// Supported sort orders for <see cref="Timesheet"/> objects.
    /// </summary>
    public enum TimesheetOrder
    {
        /// <summary>
        /// Timesheet ordered by first name.
        /// </summary>
        [EnumMember(Value = "fname")]
        FirstName,

        /// <summary>
        /// Timesheet ordered by last name.
        /// </summary>
        [EnumMember(Value = "lname")]
        LastName,

        /// <summary>
        /// Timesheet ordered by user name.
        /// </summary>
        [EnumMember(Value = "username")]
        UserName,

        /// <summary>
        /// Timesheet ordered by date.
        /// </summary>
        [EnumMember(Value = "date")]
        Date
    }
}
