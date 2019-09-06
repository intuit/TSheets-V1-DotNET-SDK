// *******************************************************************************
// <copyright file="DaysOfTheWeek.cs" company="Intuit">
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
    /// The days of the week.
    /// </summary>
    /// <remarks>
    /// Used with <see cref="Reminder"/> objects to specify
    /// the days on which the reminders should be sent.
    /// </remarks>
    [Flags]
    public enum DaysOfTheWeek
    {
        /// <summary>
        /// Sunday
        /// </summary>
        [EnumMember(Value = "Sun")]
        Sunday = 0x1,

        /// <summary>
        /// Monday
        /// </summary>
        [EnumMember(Value = "Mon")]
        Monday = 0x2,

        /// <summary>
        /// Tuesday
        /// </summary>
        [EnumMember(Value = "Tue")]
        Tuesday = 0x4,

        /// <summary>
        /// Wednesday
        /// </summary>
        [EnumMember(Value = "Wed")]
        Wednesday = 0x8,

        /// <summary>
        /// Thursday
        /// </summary>
        [EnumMember(Value = "Thu")]
        Thursday = 0x10,

        /// <summary>
        /// Friday
        /// </summary>
        [EnumMember(Value = "Fri")]
        Friday = 0x20,

        /// <summary>
        /// Saturday
        /// </summary>
        [EnumMember(Value = "Sat")]
        Saturday = 0x40
    }
}
