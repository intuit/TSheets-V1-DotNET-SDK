// *******************************************************************************
// <copyright file="DataService_ScheduleEventsTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_ScheduleEventsTests : DataServiceTestBase
    {
        private static readonly ScheduleEventFilter DummyFilter = new ScheduleEventFilter
        {
            Ids = new[] { 1, 2 }
        };

        private static readonly ScheduleEvent DummyEntity = new ScheduleEvent();
        private static readonly List<ScheduleEvent> DummyEntities = new List<ScheduleEvent> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateScheduleEvents_TestWithoutOptions()
        {
            ExpectCreate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                ApiService.CreateScheduleEvents(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateScheduleEvents_TestWithOptions()
        {
            ExpectCreate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                ApiService.CreateScheduleEvents(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateScheduleEvent_TestWithoutOptions()
        {
            ExpectCreate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                ApiService.CreateScheduleEvent(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateScheduleEvent_TestWithOptions()
        {
            ExpectCreate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                ApiService.CreateScheduleEvent(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateScheduleEvents_TestWithoutOptionsAsync()
        {
            ExpectCreate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                await ApiService.CreateScheduleEventsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateScheduleEvents_TestWithOptionsAsync()
        {
            ExpectCreate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                await ApiService.CreateScheduleEventsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateScheduleEvent_TestWithoutOptionsAsync()
        {
            ExpectCreate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                await ApiService.CreateScheduleEventAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateScheduleEvent_TestWithOptionsAsync()
        {
            ExpectCreate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                await ApiService.CreateScheduleEventAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetScheduleEvents_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<ScheduleEvent>(EndpointName.ScheduleEvents, Params.Filter);

            VerifyResult(
                ApiService.GetScheduleEvents(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetScheduleEvents_TestWithFilterAndWithOptions()
        {
            ExpectGet<ScheduleEvent>(EndpointName.ScheduleEvents, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetScheduleEvents(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetScheduleEvents_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<ScheduleEvent>(EndpointName.ScheduleEvents, Params.Filter);

            VerifyResult(
                await ApiService.GetScheduleEventsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetScheduleEvents_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<ScheduleEvent>(EndpointName.ScheduleEvents, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetScheduleEventsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateScheduleEvents_TestWithoutOptions()
        {
            ExpectUpdate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                ApiService.UpdateScheduleEvents(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateScheduleEvents_TestWithOptions()
        {
            ExpectUpdate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                ApiService.UpdateScheduleEvents(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateScheduleEvent_TestWithoutOptions()
        {
            ExpectUpdate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                ApiService.UpdateScheduleEvent(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateScheduleEvent_TestWithOptions()
        {
            ExpectUpdate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                ApiService.UpdateScheduleEvent(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateScheduleEvents_TestWithoutOptionsAsync()
        {
            ExpectUpdate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                await ApiService.UpdateScheduleEventsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateScheduleEvents_TestWithOptionsAsync()
        {
            ExpectUpdate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                await ApiService.UpdateScheduleEventsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateScheduleEvent_TestWithoutOptionsAsync()
        {
            ExpectUpdate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                await ApiService.UpdateScheduleEventAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateScheduleEvent_TestWithOptionsAsync()
        {
            ExpectUpdate<ScheduleEvent>(EndpointName.ScheduleEvents);

            VerifyResult(
                await ApiService.UpdateScheduleEventAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion
    }
}
