// *******************************************************************************
// <copyright file="TristateChoice.cs" company="Intuit">
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
    /// A value for filtering results on 'yes', 'no', or 'both'.
    /// </summary>
    public enum TristateChoice
    {
        /// <summary>
        /// Yes
        /// </summary>
        [EnumMember(Value = "yes")]
        Yes,

        /// <summary>
        /// No
        /// </summary>
        [EnumMember(Value = "no")]
        No,

        /// <summary>
        /// Both/either
        /// </summary>
        [EnumMember(Value = "both")]
        Both
    }
}
