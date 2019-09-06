// *******************************************************************************
// <copyright file="DataService_ScheduleCalendarsTests.cs" company="Intuit">
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
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_ScheduleCalendarsTests : DataServiceTestBase
    {
        private static readonly ScheduleCalendarFilter DummyFilter = new ScheduleCalendarFilter
        {
            Ids = new[]{ 1, 2 }
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetScheduleCalendars_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<ScheduleCalendar>(EndpointName.ScheduleCalendars, Params.None);

            VerifyResult(
                ApiService.GetScheduleCalendars());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetScheduleCalendars_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<ScheduleCalendar>(EndpointName.ScheduleCalendars, Params.Filter);

            VerifyResult(
                ApiService.GetScheduleCalendars(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetScheduleCalendars_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<ScheduleCalendar>(EndpointName.ScheduleCalendars, Params.RequestOptions);

            VerifyResult(
                ApiService.GetScheduleCalendars(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetScheduleCalendars_TestWithFilterAndWithOptions()
        {
            ExpectGet<ScheduleCalendar>(EndpointName.ScheduleCalendars, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetScheduleCalendars(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetScheduleCalendars_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<ScheduleCalendar>(EndpointName.ScheduleCalendars, Params.None);

            VerifyResult(
                await ApiService.GetScheduleCalendarsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetScheduleCalendars_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<ScheduleCalendar>(EndpointName.ScheduleCalendars, Params.Filter);

            VerifyResult(
                await ApiService.GetScheduleCalendarsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetScheduleCalendars_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<ScheduleCalendar>(EndpointName.ScheduleCalendars, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetScheduleCalendarsAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetScheduleCalendars_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<ScheduleCalendar>(EndpointName.ScheduleCalendars, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetScheduleCalendarsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion
    }
}
