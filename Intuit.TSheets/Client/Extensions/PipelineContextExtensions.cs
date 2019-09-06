// *******************************************************************************
// <copyright file="PipelineContextExtensions.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Extensions
{
    using System;
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;

    /// <summary>
    /// For internal use, extension methods for PipelineContext&lt;T&gt; object.
    /// </summary>
    internal static class PipelineContextExtensions
    {
        private static readonly Dictionary<EndpointName, string> JsonPaths = new Dictionary<EndpointName, string>
        {
            { EndpointName.CurrentUser, "results.users.*" },
            { EndpointName.CustomFieldItemFilters, "results.customfielditem_filters.*" },
            { EndpointName.CustomFieldItemJobcodeFilters, "results.customfielditem_jobcode_filters.*" },
            { EndpointName.CustomFieldItemUserFilters, "results.customfielditem_user_filters.*" },
            { EndpointName.CustomFieldItems, "results.customfielditems.*" },
            { EndpointName.CustomFields, "results.customfields.*" },
            { EndpointName.EffectiveSettings, "results" },
            { EndpointName.Files, "results.files.*" },
            { EndpointName.GeofenceConfigs, "results.geofence_configs.*" },
            { EndpointName.Geolocations, "results.geolocations.*" },
            { EndpointName.Groups, "results.groups.*" },
            { EndpointName.JobcodeAssignments, "results.jobcode_assignments.*" },
            { EndpointName.Jobcodes, "results.jobcodes.*" },
            { EndpointName.LastModifiedTimestamps, "results.last_modified_timestamps" },
            { EndpointName.Locations, "results.locations.*" },
            { EndpointName.LocationsMaps, "results.locations_map.*" },
            { EndpointName.ManagedClients, "results.managed_clients.*" },
            { EndpointName.Notifications, "results.notifications.*" },
            { EndpointName.Reminders, "results.reminders.*" },
            { EndpointName.ScheduleCalendars, "results.schedule_calendars.*" },
            { EndpointName.ScheduleEvents, "results.schedule_events.*" },
            { EndpointName.Timesheets, "results.timesheets.*" },
            { EndpointName.TimesheetsDeleted, "results.timesheets_deleted.*" },
            { EndpointName.Tests, "results.tests.*" },
            { EndpointName.Users, "results.users.*" }
        };

        /// <summary>
        /// Returns the JSON path at which results for entities associated with the given endpoint
        /// can be found in the response body content from the rest call.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="context">Contextual information for the method call.</param>
        /// <returns>The JSON path string.</returns>
        internal static string JsonPath<T>(this PipelineContext<T> context)
        {
            if (!JsonPaths.ContainsKey(context.Endpoint))
            {
                throw new InvalidOperationException($"Endpoint '{context.Endpoint.ToString()}' is not supported.");
            }

            return JsonPaths[context.Endpoint];
        }
    }
}