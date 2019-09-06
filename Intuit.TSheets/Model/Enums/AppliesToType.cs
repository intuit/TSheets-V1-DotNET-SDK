// *******************************************************************************
// <copyright file="AppliesToType.cs" company="Intuit">
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
    /// The type of TSheets entities to which the setting applies
    /// </summary>
    public enum AppliesToType
    {
        /// <summary>
        /// Applies to Timesheet entities.
        /// </summary>
        [EnumMember(Value = "timesheet")]
        Timesheet,

        /// <summary>
        ///  Applies to User entities.
        /// </summary>
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// Applies to  Jobcode entities.
        /// </summary>
        [EnumMember(Value = "jobcode")]
        Jobcode,

        /// <summary>
        ///  Applies to All entities.
        /// </summary>
        [EnumMember(Value = "all")]
        All
    }
}
