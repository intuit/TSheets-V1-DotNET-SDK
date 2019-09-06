// *******************************************************************************
// <copyright file="JobcodeType.cs" company="Intuit">
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
    /// The supported jobcode types.
    /// </summary>
    public enum JobcodeType
    {
        /// <summary>
        /// A regular jobcode type.
        /// </summary>
        [EnumMember(Value = "regular")]
        Regular,

        /// <summary>
        /// A PTO (paid time off) jobcode type.
        /// </summary>
        [EnumMember(Value = "pto")]
        Pto,

        /// <summary>
        /// A jobcode for an unpaid break.
        /// </summary>
        [EnumMember(Value = "unpaid_break")]
        UnpaidBreak,

        /// <summary>
        /// A jobcode for a paid break.
        /// </summary>
        [EnumMember(Value = "paid_break")]
        PaidBreak,

        /// <summary>
        /// A jobcode for unpaid time off.
        /// </summary>
        [EnumMember(Value = "unpaid_time_off")]
        UnpaidTimeOff,

        /// <summary>
        /// A value indicating any (or all) types of jobcodes.
        /// </summary>
        [EnumMember(Value = "all")]
        All
    }
}
