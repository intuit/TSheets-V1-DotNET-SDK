// *******************************************************************************
// <copyright file="DataService_CurrentTotalsReportsTests.cs" company="Intuit">
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
    using System;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_CurrentTotalsReportsTests : DataServiceTestBase
    {
        private static readonly CurrentTotalsReportFilter DummyCurrentTotalsReportFilter = new CurrentTotalsReportFilter
        {
            UserIds = new[]{ 1, 2 }
        };

        private static readonly PayrollReportFilter DummyPayrollReportFilter = new PayrollReportFilter(
            DateTimeOffset.Now.AddDays(-7),
            DateTimeOffset.Now);

        private static readonly PayrollByJobcodeReportFilter DummyPayrollByJobcodeReportFilter = new PayrollByJobcodeReportFilter(
            DateTimeOffset.Now.AddDays(-7),
            DateTimeOffset.Now);

        private static readonly ProjectReportFilter DummyProjectReportFilter = new ProjectReportFilter(
            DateTimeOffset.Now.AddDays(-7),
            DateTimeOffset.Now);

        #region Get Current Totals Report Tests

        [TestMethod, TestCategory("Unit")]
        public void GetCurrentTotalsReport_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGetReport<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, Params.None);

            VerifyResult(
                ApiService.GetCurrentTotalsReport());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetCurrentTotalsReport_TestWithFilterAndWithoutOptions()
        {
            ExpectGetReport<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, Params.Filter);

            VerifyResult(
                ApiService.GetCurrentTotalsReport(DummyCurrentTotalsReportFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetCurrentTotalsReport_TestWithoutFilterAndWithOptions()
        {
            ExpectGetReport<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, Params.None);

            VerifyResult(
                ApiService.GetCurrentTotalsReport());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetCurrentTotalsReport_TestWithFilterAndWithOptions()
        {
            ExpectGetReport<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, Params.Filter);

            VerifyResult(
                ApiService.GetCurrentTotalsReport(DummyCurrentTotalsReportFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetCurrentTotalsReport_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGetReport<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, Params.None);

            VerifyResult(
                await ApiService.GetCurrentTotalsReportAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetCurrentTotalsReport_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGetReport<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, Params.Filter);

            VerifyResult(
                await ApiService.GetCurrentTotalsReportAsync(DummyCurrentTotalsReportFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetCurrentTotalsReport_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGetReport<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, Params.None);

            VerifyResult(
                await ApiService.GetCurrentTotalsReportAsync().ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetCurrentTotalsReport_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGetReport<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, Params.Filter);

            VerifyResult(
                await ApiService.GetCurrentTotalsReportAsync(DummyCurrentTotalsReportFilter).ConfigureAwait(false));
        }

        #endregion

        #region Get Payroll Report Tests

        [TestMethod, TestCategory("Unit")]
        public void GetPayrollReport_TestWithFilterAndWithoutOptions()
        {
            ExpectGetReport<PayrollReport>(EndpointName.PayrollReports, Params.Filter);

            VerifyResult(
                ApiService.GetPayrollReport(DummyPayrollReportFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetPayrollReport_TestWithFilterAndWithOptions()
        {
            ExpectGetReport<PayrollReport>(EndpointName.PayrollReports, Params.Filter);

            VerifyResult(
                ApiService.GetPayrollReport(DummyPayrollReportFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetPayrollReport_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGetReport<PayrollReport>(EndpointName.PayrollReports, Params.Filter);

            VerifyResult(
                await ApiService.GetPayrollReportAsync(DummyPayrollReportFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetPayrollReport_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGetReport<PayrollReport>(EndpointName.PayrollReports, Params.Filter);

            VerifyResult(
                await ApiService.GetPayrollReportAsync(DummyPayrollReportFilter).ConfigureAwait(false));
        }

        #endregion

        #region Get Payroll by Jobcode Report Tests

        [TestMethod, TestCategory("Unit")]
        public void GetPayrollByJobcodeReport_TestWithFilterAndWithoutOptions()
        {
            ExpectGetReport<PayrollByJobcodeReport>(EndpointName.PayrollByJobcodeReports, Params.Filter);

            VerifyResult(
                ApiService.GetPayrollByJobcodeReport(DummyPayrollByJobcodeReportFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetPayrollByJobcodeReport_TestWithFilterAndWithOptions()
        {
            ExpectGetReport<PayrollByJobcodeReport>(EndpointName.PayrollByJobcodeReports, Params.Filter);

            VerifyResult(
                ApiService.GetPayrollByJobcodeReport(DummyPayrollByJobcodeReportFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetPayrollByJobcodeReport_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGetReport<PayrollByJobcodeReport>(EndpointName.PayrollByJobcodeReports, Params.Filter);

            VerifyResult(
                await ApiService.GetPayrollByJobcodeReportAsync(DummyPayrollByJobcodeReportFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetPayrollByJobcodeReport_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGetReport<PayrollByJobcodeReport>(EndpointName.PayrollByJobcodeReports, Params.Filter);

            VerifyResult(
                await ApiService.GetPayrollByJobcodeReportAsync(DummyPayrollByJobcodeReportFilter).ConfigureAwait(false));
        }

        #endregion

        #region Get Project Report Tests

        [TestMethod, TestCategory("Unit")]
        public void GetProjectReport_TestWithFilterAndWithoutOptions()
        {
            ExpectGetReport<ProjectReport>(EndpointName.ProjectReports, Params.Filter);

            VerifyResult(
                ApiService.GetProjectReport(DummyProjectReportFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetProjectReport_TestWithFilterAndWithOptions()
        {
            ExpectGetReport<ProjectReport>(EndpointName.ProjectReports, Params.Filter);

            VerifyResult(
                ApiService.GetProjectReport(DummyProjectReportFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetProjectReport_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGetReport<ProjectReport>(EndpointName.ProjectReports, Params.Filter);

            VerifyResult(
                await ApiService.GetProjectReportAsync(DummyProjectReportFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetProjectReport_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGetReport<ProjectReport>(EndpointName.ProjectReports, Params.Filter);

            VerifyResult(
                await ApiService.GetProjectReportAsync(DummyProjectReportFilter).ConfigureAwait(false));
        }

        #endregion

    }
}
