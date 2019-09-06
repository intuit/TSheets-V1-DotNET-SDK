// *******************************************************************************
// <copyright file="SupplementalDataDeserializerTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.RequestFlow.PipelineElements
{
    using System;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SupplementalDataDeserializerTests : UnitTestBase
    {
        private SupplementalDataDeserializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = SupplementalDataDeserializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public async Task SupplementalDataDeserializerTests_HandlesCaseInWhichSupplementalDataSectionDoesNotExistAsync()
        {
            var context = new GetContext<TestEntity>(EndpointName.Tests, filter: null, options: null)
            {
                ResponseContent = @"
                {
                  ""results"": {
                  }
                }"
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            const int expectedCount = 0;
            Assert.AreEqual(expectedCount, context.ResultsMeta.SupplementalData.GetAll<TestEntity>().Count,
                $"Expected {expectedCount} SupplementalData Items.");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task SupplementalDataDeserializerTests_HandlesCaseInWhichSupplementalDataSectionIsEmptyAsync()
        {
            var context = new GetContext<BasicTestEntity>(EndpointName.Tests, filter: null, options: null)
            {
                ResponseContent = @"
                {
                  ""results"": {
                  },
                  ""supplemental_data"": {
                  }
                }"
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            const int expectedCount = 0;
            Assert.AreEqual(expectedCount, context.ResultsMeta.SupplementalData.GetAll<TestEntity>().Count,
                $"Expected {expectedCount} SupplementalData Items.");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task SupplementalDataDeserializerTests_CorrectlyDeserializesSupplementalDataAsync()
        {
            var context = new GetContext<TestEntity>(EndpointName.Tests, filter: null, options: null)
            {
                ResponseContent = ResponseContent
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            const int expectedGroupItemCount = 2;
            Assert.AreEqual(expectedGroupItemCount, context.ResultsMeta.SupplementalData.GetAll<Group>().Count,
                $"Expected {expectedGroupItemCount} SupplementalData Group Items.");

            const int expectedJobcodeItemCount = 1;
            Assert.AreEqual(expectedJobcodeItemCount, context.ResultsMeta.SupplementalData.GetAll<Jobcode>().Count,
                $"Expected {expectedJobcodeItemCount} SupplementalData Jobcode Item.");
        }

        [TestMethod, TestCategory("Unit")]
        public void SupplementalDataDeserializerTests_GetTypeCreatorReturnsFunc()
        {
            Func<IIdentifiable> createScheduleCalendar = EntityTypeMapper.GetTypeCreator("calendars");
            Assert.IsInstanceOfType(createScheduleCalendar(), typeof(ScheduleCalendar), $"Expected instance of {nameof(ScheduleCalendar)}");

            Func<IIdentifiable> createCustomField = EntityTypeMapper.GetTypeCreator("customfields");
            Assert.IsInstanceOfType(createCustomField(), typeof(CustomField), $"Expected instance of {nameof(CustomField)}");

            Func<IIdentifiable> createCustomFieldItem = EntityTypeMapper.GetTypeCreator("customfielditems");
            Assert.IsInstanceOfType(createCustomFieldItem(), typeof(CustomFieldItem), $"Expected instance of {nameof(CustomFieldItem)}");

            Func<IIdentifiable> createGeolocation = EntityTypeMapper.GetTypeCreator("geolocations");
            Assert.IsInstanceOfType(createGeolocation(), typeof(Geolocation), $"Expected instance of {nameof(Geolocation)}");

            Func<IIdentifiable> createGroup = EntityTypeMapper.GetTypeCreator("groups");
            Assert.IsInstanceOfType(createGroup(), typeof(Group), $"Expected instance of {nameof(Group)}");

            Func<IIdentifiable> createJobcode = EntityTypeMapper.GetTypeCreator("jobcodes");
            Assert.IsInstanceOfType(createJobcode(), typeof(Jobcode), $"Expected instance of {nameof(Jobcode)}");

            Func<IIdentifiable> createLocation = EntityTypeMapper.GetTypeCreator("locations");
            Assert.IsInstanceOfType(createLocation(), typeof(Location), $"Expected instance of {nameof(Location)}");

            Func<IIdentifiable> createScheduleEvent = EntityTypeMapper.GetTypeCreator("schedule_events");
            Assert.IsInstanceOfType(createScheduleEvent(), typeof(ScheduleEvent), $"Expected instance of {nameof(ScheduleEvent)}");

            Func<IIdentifiable> createTimesheet = EntityTypeMapper.GetTypeCreator("timesheets");
            Assert.IsInstanceOfType(createTimesheet(), typeof(Timesheet), $"Expected instance of {nameof(Timesheet)}");

            Func<IIdentifiable> createUser = EntityTypeMapper.GetTypeCreator("users");
            Assert.IsInstanceOfType(createUser(), typeof(User), $"Expected instance of {nameof(User)}");

            try
            {
                EntityTypeMapper.GetTypeCreator("none");
                Assert.Fail("Expected InvalidOperationException to be thrown.");
            }
            catch (InvalidOperationException)
            { }
        }

        private static string ResponseContent => @"
        {
            ""results"": {
            },
            ""supplemental_data"": {
            ""groups"": {
                ""1"" : {
                ""id"": 1,
                ""active"": true,
                ""name"": ""Group 1"",
                ""last_modified"": ""2018-08-19T16:29:28+00:00"",
                ""created"": ""2018-08-19T16:29:28+00:00"",
                ""manager_ids"": [
                    ""300"",
                    ""316""
                ]
                },
                ""2"" : {
                ""id"": 2,
                ""active"": true,
                ""name"": ""Group 2"",
                ""last_modified"": ""2018-08-19T16:29:28+01:00"",
                ""created"": ""2018-08-19T16:29:28+01:00"",
                ""manager_ids"": [ ]
                }
            },
            ""jobcodes"": {
                ""123"" : {
                ""id"": 123,
                ""parent_id"": 0,
                ""assigned_to_all"": false,
                ""billable"": false,
                ""active"": true,
                ""type"": ""regular"",
                ""has_children"": true,
                ""billable_rate"": 0,
                ""short_code"": ""asm"",
                ""name"": ""Assembly Line"",
                ""last_modified"": ""2018-07-24T19:05:46+00:00"",
                ""created"": ""2018-05-28T20:18:17+00:00""
                }
            }
            }
        }";


    }

}
