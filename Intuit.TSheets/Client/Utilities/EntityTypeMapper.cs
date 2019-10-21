// *******************************************************************************
// <copyright file="EntityTypeMapper.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Utilities
{
    using System;
    using System.Collections.Generic;
    using Intuit.TSheets.Model;

    /// <summary>
    /// Internal helper class for mapping the entity name (as found in the JSON response of TSheets API method calls)
    /// to a function which creates a new instance of the corresponding entity type.
    /// </summary>
    internal static class EntityTypeMapper
    {
        private static Dictionary<string, Func<IIdentifiable>> typeCreators = new Dictionary<string, Func<IIdentifiable>>
        {
            { "calendars",        () => new ScheduleCalendar() },
            { "customfields",     () => new CustomField() },
            { "customfielditems", () => new CustomFieldItem() },
            { "files",            () => new File() },
            { "geofence_configs", () => new GeofenceConfig() },
            { "geolocations",     () => new Geolocation() },
            { "groups",           () => new Group() },
            { "jobcodes",         () => new Jobcode() },
            { "locations",        () => new Location() },
            { "schedule_events",  () => new ScheduleEvent() },
            { "timesheets",       () => new Timesheet() },
            { "users",            () => new User() }
        };

        /// <summary>
        /// Given an entity name, returns a function that instantiates the type.
        /// </summary>
        /// <param name="entityName">The name of the entity type</param>
        /// <returns>
        /// A function which creates a new instance of the entity type
        /// if the type is known, else null.
        /// </returns>
        internal static Func<IIdentifiable> GetTypeCreator(string entityName)
        {
            return typeCreators.ContainsKey(entityName)
                ? typeCreators[entityName]
                : null;
        }
    }
}
