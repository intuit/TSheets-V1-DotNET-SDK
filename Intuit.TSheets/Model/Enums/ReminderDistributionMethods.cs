// *******************************************************************************
// <copyright file="ReminderDistributionMethods.cs" company="Intuit">
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
    /// The supported methods by which a <see cref="Reminder"/> may be sent.
    /// </summary>
    [Flags]
    public enum ReminderDistributionMethods
    {
        /// <summary>
        /// A reminder that is pushed to a mobile device.
        /// </summary>
        [EnumMember(Value = "Push")]
        Push = 0x1,

        /// <summary>
        /// A reminder that is sent via text message (sms).
        /// </summary>
        [EnumMember(Value = "SMS")]
        Sms = 0x2,

        /// <summary>
        /// A reminder that is sent via email.
        /// </summary>
        [EnumMember(Value = "Email")]
        Email = 0x4
    }
}
