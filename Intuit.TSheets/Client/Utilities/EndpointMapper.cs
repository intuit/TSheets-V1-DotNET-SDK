// *******************************************************************************
// <copyright file="EndpointMapper.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Core;

    /// <summary>
    /// Internal helper class for mapping each endpoint name to its corresponding URI segment path.
    /// </summary>
    internal static class EndpointMapper
    {
        private static readonly Dictionary<EndpointName, string> EndpointMappings = new Dictionary<EndpointName, string>
        {
            { EndpointName.CurrentTotalsReports, "reports/current_totals" },
            { EndpointName.CurrentUser, "current_user" },
            { EndpointName.CustomFields, "customfields" },
            { EndpointName.CustomFieldItems, "customfielditems" },
            { EndpointName.CustomFieldItemFilters, "customfielditem_filters" },
            { EndpointName.CustomFieldItemJobcodeFilters, "customfielditem_jobcode_filters" },
            { EndpointName.CustomFieldItemUserFilters, "customfielditem_user_filters" },
            { EndpointName.EffectiveSettings, "effective_settings" },
            { EndpointName.Files, "files" },
            { EndpointName.FilesRaw, "files/raw" },
            { EndpointName.GeofenceConfigs, "geofence_configs" },
            { EndpointName.Geolocations, "geolocations" },
            { EndpointName.Groups, "groups" },
            { EndpointName.Invitations, "invitations" },
            { EndpointName.Jobcodes, "jobcodes" },
            { EndpointName.JobcodeAssignments, "jobcode_assignments" },
            { EndpointName.LastModifiedTimestamps, "last_modified_timestamps" },
            { EndpointName.Locations, "locations" },
            { EndpointName.LocationsMaps, "locations_map" },
            { EndpointName.ManagedClients, "managed_clients" },
            { EndpointName.Notifications, "notifications" },
            { EndpointName.PayrollReports, "reports/payroll" },
            { EndpointName.PayrollByJobcodeReports, "reports/payroll_by_jobcode" },
            { EndpointName.ProjectReports, "reports/project" },
            { EndpointName.Reminders, "reminders" },
            { EndpointName.ScheduleCalendars, "schedule_calendars" },
            { EndpointName.ScheduleEvents, "schedule_events" },
            { EndpointName.Timesheets, "timesheets" },
            { EndpointName.TimesheetsDeleted, "timesheets_deleted" },
            { EndpointName.Users, "users" },

            // For testing purposes, not a real endpoint.
            { EndpointName.Tests, "tests" }
        };

        /// <summary>
        /// Helper to return the API endpoint for the given object type
        /// </summary>
        /// <param name="endpointName">The endpoint name</param>
        /// <returns>The associated endpoint</returns>
        internal static string GetEndpoint(EndpointName endpointName)
        {
            if (!EndpointMappings.ContainsKey(endpointName))
            {
                throw new NotImplementedException($"Unknown {nameof(EndpointName)}: {endpointName}");
            }

            return EndpointMappings[endpointName];
        }
    }
}
