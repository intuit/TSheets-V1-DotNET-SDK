// *******************************************************************************
// <copyright file="GeofenceConfigType.cs" company="Intuit">
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
    /// The supported geofence configuration types.
    /// </summary>
    public enum GeofenceConfigType
    {
        /// <summary>
        /// The Global geofence configuration type.
        /// </summary>
        [EnumMember(Value = "global")]
        Global,

        /// <summary>
        /// A Geofence configuration type related to clients.
        /// </summary>
        [EnumMember(Value = "clients")]
        Clients,

        /// <summary>
        /// A Geofence configuration type related to jobcodes.
        /// </summary>
        [EnumMember(Value = "job_codes")]
        Jobcodes,

        /// <summary>
        /// A Geofence configuration type related to locations.
        /// </summary>
        [EnumMember(Value = "locations")]
        Locations
    }
}
