// *******************************************************************************
// <copyright file="DataService_Reports.cs" company="Intuit">
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

namespace Intuit.TSheets.Api
{
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    /// <remarks>
    /// This file contains operations specific to the various Reports endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Get Current Totals Report

        /// <summary>
        /// Retrieve Current Totals Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a snapshot report for the current totals (shift and day) along with additional
        /// information provided for those who are currently on the clock.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="CurrentTotalsReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (CurrentTotalsReport, ResultsMeta) GetCurrentTotalsReport()
        {
            return GetCurrentTotalsReport(null);
        }

        /// <summary>
        /// Retrieve Current Totals Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a snapshot report for the current totals (shift and day) along with additional
        /// information provided for those who are currently on the clock.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CurrentTotalsReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="CurrentTotalsReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (CurrentTotalsReport, ResultsMeta) GetCurrentTotalsReport(CurrentTotalsReportFilter filter)
        {
            return AsyncUtil.RunSync(() => GetCurrentTotalsReportAsync(filter));
        }

        /// <summary>
        /// Asynchronously Retrieve Current Totals Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a snapshot report for the current totals (shift and day) along with additional
        /// information provided for those who are currently on the clock.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="CurrentTotalsReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CurrentTotalsReport, ResultsMeta)> GetCurrentTotalsReportAsync()
        {
            return await GetCurrentTotalsReportAsync(null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Current Totals Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a snapshot report for the current totals (shift and day) along with additional
        /// information provided for those who are currently on the clock.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CurrentTotalsReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="CurrentTotalsReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CurrentTotalsReport, ResultsMeta)> GetCurrentTotalsReportAsync(CurrentTotalsReportFilter filter)
        {
            var context = new GetReportContext<CurrentTotalsReport>(EndpointName.CurrentTotalsReports, filter);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results, context.ResultsMeta);
        }

        #endregion

        #region Get Payroll Report

        /// <summary>
        /// Retrieve Payroll Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a payroll report associated with a time frame,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="PayrollReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PayrollReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (PayrollReport, ResultsMeta) GetPayrollReport(PayrollReportFilter filter)
        {
            return AsyncUtil.RunSync(() => GetPayrollReportAsync(filter));
        }

        /// <summary>
        /// Asynchronously Retrieve Payroll Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a payroll report associated with a time frame,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="PayrollReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PayrollReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(PayrollReport, ResultsMeta)> GetPayrollReportAsync(PayrollReportFilter filter)
        {
            var context = new GetReportContext<PayrollReport>(EndpointName.PayrollReports, filter);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results, context.ResultsMeta);
        }

        #endregion

        #region Get Payroll By Jobcode Report

        /// <summary>
        /// Retrieve Payroll by Jobcode Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a payroll report, broken down by jobcode,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="PayrollByJobcodeReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PayrollByJobcodeReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (PayrollByJobcodeReport, ResultsMeta) GetPayrollByJobcodeReport(PayrollByJobcodeReportFilter filter)
        {
            return AsyncUtil.RunSync(() => GetPayrollByJobcodeReportAsync(filter));
        }

        /// <summary>
        /// Asynchronously Retrieve Payroll by Jobcode Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a payroll report, broken down by jobcode,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="PayrollByJobcodeReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PayrollByJobcodeReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(PayrollByJobcodeReport, ResultsMeta)> GetPayrollByJobcodeReportAsync(PayrollByJobcodeReportFilter filter)
        {
            var context = new GetReportContext<PayrollByJobcodeReport>(EndpointName.PayrollByJobcodeReports, filter);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results, context.ResultsMeta);
        }

        #endregion

        #region Get Project Report

        /// <summary>
        /// Retrieve Project Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a project report with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ProjectReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="ProjectReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (ProjectReport, ResultsMeta) GetProjectReport(ProjectReportFilter filter)
        {
            return AsyncUtil.RunSync(() => GetProjectReportAsync(filter));
        }

        /// <summary>
        /// Asynchronously Retrieve Project Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a project report with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ProjectReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="ProjectReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(ProjectReport, ResultsMeta)> GetProjectReportAsync(ProjectReportFilter filter)
        {
            var context = new GetReportContext<ProjectReport>(EndpointName.ProjectReports, filter);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results, context.ResultsMeta);
        }

        #endregion
    }
}
