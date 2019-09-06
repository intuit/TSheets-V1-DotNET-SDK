// *******************************************************************************
// <copyright file="EndpointMapperTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Utilities
{
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EndpointMapperTests
    {
        [TestMethod, TestCategory("Unit")]
        public void EndpointMapper_MapsEndpointsAsExpected()
        {
            Assert.AreEqual("reports/current_totals", EndpointMapper.GetEndpoint(EndpointName.CurrentTotalsReports));
            Assert.AreEqual("current_user", EndpointMapper.GetEndpoint(EndpointName.CurrentUser));
            Assert.AreEqual("customfields", EndpointMapper.GetEndpoint(EndpointName.CustomFields));
            Assert.AreEqual("customfielditems", EndpointMapper.GetEndpoint(EndpointName.CustomFieldItems));
            Assert.AreEqual("customfielditem_filters", EndpointMapper.GetEndpoint(EndpointName.CustomFieldItemFilters));
            Assert.AreEqual("customfielditem_jobcode_filters", EndpointMapper.GetEndpoint(EndpointName.CustomFieldItemJobcodeFilters));
            Assert.AreEqual("customfielditem_user_filters", EndpointMapper.GetEndpoint(EndpointName.CustomFieldItemUserFilters));
            Assert.AreEqual("effective_settings", EndpointMapper.GetEndpoint(EndpointName.EffectiveSettings));
            Assert.AreEqual("files", EndpointMapper.GetEndpoint(EndpointName.Files));
            Assert.AreEqual("files/raw", EndpointMapper.GetEndpoint(EndpointName.FilesRaw));
            Assert.AreEqual("geofence_configs", EndpointMapper.GetEndpoint(EndpointName.GeofenceConfigs));
            Assert.AreEqual("geolocations", EndpointMapper.GetEndpoint(EndpointName.Geolocations));
            Assert.AreEqual("groups", EndpointMapper.GetEndpoint(EndpointName.Groups));
            Assert.AreEqual("invitations", EndpointMapper.GetEndpoint(EndpointName.Invitations));
            Assert.AreEqual("jobcodes", EndpointMapper.GetEndpoint(EndpointName.Jobcodes));
            Assert.AreEqual("jobcode_assignments", EndpointMapper.GetEndpoint(EndpointName.JobcodeAssignments));
            Assert.AreEqual("last_modified_timestamps", EndpointMapper.GetEndpoint(EndpointName.LastModifiedTimestamps));
            Assert.AreEqual("locations", EndpointMapper.GetEndpoint(EndpointName.Locations));
            Assert.AreEqual("locations_map", EndpointMapper.GetEndpoint(EndpointName.LocationsMaps));
            Assert.AreEqual("managed_clients", EndpointMapper.GetEndpoint(EndpointName.ManagedClients));
            Assert.AreEqual("notifications", EndpointMapper.GetEndpoint(EndpointName.Notifications));
            Assert.AreEqual("reports/payroll", EndpointMapper.GetEndpoint(EndpointName.PayrollReports));
            Assert.AreEqual("reports/payroll_by_jobcode", EndpointMapper.GetEndpoint(EndpointName.PayrollByJobcodeReports));
            Assert.AreEqual("reports/project", EndpointMapper.GetEndpoint(EndpointName.ProjectReports));
            Assert.AreEqual("reminders", EndpointMapper.GetEndpoint(EndpointName.Reminders));
            Assert.AreEqual("schedule_calendars", EndpointMapper.GetEndpoint(EndpointName.ScheduleCalendars));
            Assert.AreEqual("schedule_events", EndpointMapper.GetEndpoint(EndpointName.ScheduleEvents));
            Assert.AreEqual("timesheets", EndpointMapper.GetEndpoint(EndpointName.Timesheets));
            Assert.AreEqual("timesheets_deleted", EndpointMapper.GetEndpoint(EndpointName.TimesheetsDeleted));
            Assert.AreEqual("users", EndpointMapper.GetEndpoint(EndpointName.Users));
        }
    }
}
