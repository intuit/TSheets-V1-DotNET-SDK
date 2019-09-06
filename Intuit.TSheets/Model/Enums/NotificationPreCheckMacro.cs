// *******************************************************************************
// <copyright file="NotificationPrecheckMacro.cs" company="Intuit">
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
    /// The types of checks the may be performed prior to
    /// the sending of a <see cref="Notification"/>
    /// </summary>
    public enum NotificationPrecheckMacro
    {
        /// <summary>
        /// A precheck that requires the user to be on-the-clock in order for the notification to be sent.
        /// </summary>
        [EnumMember(Value = "on_the_clock")]
        OnTheClock,

        /// <summary>
        /// A precheck that requires the user to be off-the-clock in order for the notification to be sent.
        /// </summary>
        [EnumMember(Value = "off_the_clock")]
        OffTheClock,

        /// <summary>
        /// A precheck specifying no conditions must be met in order for the notification to be sent.
        /// </summary>
        [EnumMember(Value = "none")]
        None
    }
}
