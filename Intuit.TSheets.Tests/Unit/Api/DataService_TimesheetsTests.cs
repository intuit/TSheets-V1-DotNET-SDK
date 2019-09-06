// *******************************************************************************
// <copyright file="DataService_TimesheetsTests.cs" company="Intuit">
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
    public class DataService_TimesheetsTests : DataServiceTestBase
    {
        private static readonly TimesheetFilter DummyFilter = new TimesheetFilter
        {
            Ids = new[] { 1, 2 }
        };

        private static readonly Timesheet DummyEntity = new Timesheet();
        private static readonly List<Timesheet> DummyEntities = new List<Timesheet> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateTimesheets_TestWithoutOptions()
        {
            ExpectCreate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                ApiService.CreateTimesheets(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateTimesheets_TestWithOptions()
        {
            ExpectCreate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                ApiService.CreateTimesheets(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateTimesheet_TestWithoutOptions()
        {
            ExpectCreate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                ApiService.CreateTimesheet(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateTimesheet_TestWithOptions()
        {
            ExpectCreate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                ApiService.CreateTimesheet(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateTimesheets_TestWithoutOptionsAsync()
        {
            ExpectCreate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                await ApiService.CreateTimesheetsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateTimesheets_TestWithOptionsAsync()
        {
            ExpectCreate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                await ApiService.CreateTimesheetsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateTimesheet_TestWithoutOptionsAsync()
        {
            ExpectCreate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                await ApiService.CreateTimesheetAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateTimesheet_TestWithOptionsAsync()
        {
            ExpectCreate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                await ApiService.CreateTimesheetAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetTimesheets_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<Timesheet>(EndpointName.Timesheets, Params.Filter);

            VerifyResult(
                ApiService.GetTimesheets(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetTimesheets_TestWithFilterAndWithOptions()
        {
            ExpectGet<Timesheet>(EndpointName.Timesheets, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetTimesheets(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetTimesheets_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Timesheet>(EndpointName.Timesheets, Params.Filter);

            VerifyResult(
                await ApiService.GetTimesheetsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetTimesheets_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<Timesheet>(EndpointName.Timesheets, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetTimesheetsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateTimesheets_TestWithoutOptions()
        {
            ExpectUpdate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                ApiService.UpdateTimesheets(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateTimesheets_TestWithOptions()
        {
            ExpectUpdate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                ApiService.UpdateTimesheets(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateTimesheet_TestWithoutOptions()
        {
            ExpectUpdate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                ApiService.UpdateTimesheet(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateTimesheet_TestWithOptions()
        {
            ExpectUpdate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                ApiService.UpdateTimesheet(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateTimesheets_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                await ApiService.UpdateTimesheetsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateTimesheets_TestWithOptionsAsync()
        {
            ExpectUpdate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                await ApiService.UpdateTimesheetsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateTimesheet_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                await ApiService.UpdateTimesheetAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateTimesheet_TestWithOptionsAsync()
        {
            ExpectUpdate<Timesheet>(EndpointName.Timesheets);

            VerifyResult(
                await ApiService.UpdateTimesheetAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Delete Method Tests

        [TestMethod, TestCategory("Unit")]
        public void DeleteTimesheet_Test()
        {
            ExpectDelete<Timesheet>(EndpointName.Timesheets);

            ApiService.DeleteTimesheet(DummyEntity);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteTimesheets_Test()
        {
            ExpectDelete<Timesheet>(EndpointName.Timesheets);

            ApiService.DeleteTimesheets(DummyEntities);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteTimesheet_ById_Test()
        {
            ExpectDelete<Timesheet>(EndpointName.Timesheets);

            ApiService.DeleteTimesheet(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteTimesheets_ById_Test()
        {
            ExpectDelete<Timesheet>(EndpointName.Timesheets);

            ApiService.DeleteTimesheets(new[] { 1, 2 });
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteTimesheet_TestAsync()
        {
            ExpectDelete<Timesheet>(EndpointName.Timesheets);

            await ApiService.DeleteTimesheetAsync(DummyEntity).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteTimesheets_TestAsync()
        {
            ExpectDelete<Timesheet>(EndpointName.Timesheets);

            await ApiService.DeleteTimesheetsAsync(DummyEntities).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteTimesheet_ById_TestAsync()
        {
            ExpectDelete<Timesheet>(EndpointName.Timesheets);

            await ApiService.DeleteTimesheetAsync(1).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteTimesheets_ById_TestAsync()
        {
            ExpectDelete<Timesheet>(EndpointName.Timesheets);

            await ApiService.DeleteTimesheetsAsync(new[] { 1, 2 }).ConfigureAwait(false);
        }

        #endregion
    }
}
