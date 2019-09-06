// *******************************************************************************
// <copyright file="EntityTypeMapperTests.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class EntityTypeMapperTests
    {
        [TestMethod, TestCategory("Unit")]
        public void EntityTypeMapper_MapsEntityTypesAsExpected()
        {
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("calendars")(), typeof(ScheduleCalendar));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("customfields")(), typeof(CustomField));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("customfielditems")(), typeof(CustomFieldItem));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("files")(), typeof(File));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("geolocations")(), typeof(Geolocation));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("groups")(), typeof(Group));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("jobcodes")(), typeof(Jobcode));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("locations")(), typeof(Location));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("schedule_events")(), typeof(ScheduleEvent));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("timesheets")(), typeof(Timesheet));
            Assert.IsInstanceOfType(EntityTypeMapper.GetTypeCreator("users")(), typeof(User));
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EntityTypeMapper_ThrowsWhenProvidedInvalidEntityName()
        {
            EntityTypeMapper.GetTypeCreator("notexists");
        }
    }
}
