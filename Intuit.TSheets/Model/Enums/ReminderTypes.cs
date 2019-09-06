// *******************************************************************************
// <copyright file="ReminderTypes.cs" company="Intuit">
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

    /// <summary>
    /// The supported types of <see cref="Reminder"/> objects.
    /// </summary>
    [Flags]
    public enum ReminderTypes
    {
        /// <summary>
        /// A reminder to clock in.
        /// </summary>
        [EnumMember(Value = "clock-in")]
        ClockIn = 0x1,

        /// <summary>
        /// A reminder to clock out.
        /// </summary>
        [EnumMember(Value = "clock-out")]
        ClockOut = 0x2,

        /// <summary>
        /// A shift published reminder.
        /// </summary>
        [EnumMember(Value = "shift-published")]
        ShiftPublished = 0x4,

        /// <summary>
        /// A shift-start-before reminder.
        /// </summary>
        [EnumMember(Value = "shift-start-before")]
        ShiftStartBefore = 0x8,

        /// <summary>
        /// A shift-start-after reminder.
        /// </summary>
        [EnumMember(Value = "shift-start-after")]
        ShiftStartAfter = 0x10,

        /// <summary>
        /// A shift-start-before-manager reminder.
        /// </summary>
        [EnumMember(Value = "shift-start-before-manager")]
        ShiftStartBeforeManager = 0x20,

        /// <summary>
        /// A shift-start-after-manager reminder.
        /// </summary>
        [EnumMember(Value = "shift-start-after-manager")]
        ShiftStartAfterManager = 0x40,

        /// <summary>
        /// A shift-end-before reminder.
        /// </summary>
        [EnumMember(Value = "shift-end-before")]
        ShiftEndBefore = 0x80,

        /// <summary>
        /// A shift-end-after reminder.
        /// </summary>
        [EnumMember(Value = "shift-end-after")]
        ShiftEndAfter = 0x100
    }
}
