// *******************************************************************************
// <copyright file="DataService_Timesheet.cs" company="Intuit">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
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
    /// This file contains operations specific to the Timesheets endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Timesheets.
        /// </summary>
        /// <remarks>
        /// Add a single timesheet to your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Timesheet, ResultsMeta) CreateTimesheet(Timesheet timesheet)
        {
            (IList<Timesheet> timesheets, ResultsMeta resultsMeta) = CreateTimesheets(new[] { timesheet });

            return (timesheets.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Timesheets.
        /// </summary>
        /// <remarks>
        /// Add one or more timesheets to your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Timesheet>, ResultsMeta) CreateTimesheets(IEnumerable<Timesheet> timesheets)
        {
            return AsyncUtil.RunSync(() => CreateTimesheetsAsync(timesheets));
        }

        /// <summary>
        /// Asynchronously Create Timesheets.
        /// </summary>
        /// <remarks>
        /// Add a single timesheet to your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Timesheet, ResultsMeta)> CreateTimesheetAsync(
            Timesheet timesheet)
        {
            (IList<Timesheet> timesheets, ResultsMeta resultsMeta) = await CreateTimesheetsAsync(new[] { timesheet }, default).ConfigureAwait(false);

            return (timesheets.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single timesheet to your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Timesheet, ResultsMeta)> CreateTimesheetAsync(
            Timesheet timesheet,
            CancellationToken cancellationToken)
        {
            (IList<Timesheet> timesheets, ResultsMeta resultsMeta) = await CreateTimesheetsAsync(new[] { timesheet }, cancellationToken).ConfigureAwait(false);

            return (timesheets.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Timesheets.
        /// </summary>
        /// <remarks>
        /// Add one or more timesheets to your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Timesheet>, ResultsMeta)> CreateTimesheetsAsync(
            IEnumerable<Timesheet> timesheets)
        {
            return await CreateTimesheetsAsync(timesheets, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more timesheets to your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Timesheet>, ResultsMeta)> CreateTimesheetsAsync(
            IEnumerable<Timesheet> timesheets,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<Timesheet>(EndpointName.Timesheets, timesheets);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Timesheet"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Timesheet>, ResultsMeta) GetTimesheets(
            TimesheetFilter filter)
        {
            return AsyncUtil.RunSync(() => GetTimesheetsAsync(filter));
        }

        /// <summary>
        /// Retrieve Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Timesheet"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Timesheet>, ResultsMeta) GetTimesheets(
            TimesheetFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetTimesheetsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Timesheet"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Timesheet>, ResultsMeta)> GetTimesheetsAsync(
            TimesheetFilter filter)
        {
            return await GetTimesheetsAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Timesheet"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Timesheet>, ResultsMeta)> GetTimesheetsAsync(
            TimesheetFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetTimesheetsAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Timesheet"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Timesheet>, ResultsMeta)> GetTimesheetsAsync(
            TimesheetFilter filter,
            RequestOptions options)
        {
            return await GetTimesheetsAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Timesheet"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Timesheet>, ResultsMeta)> GetTimesheetsAsync(
            TimesheetFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<Timesheet>(EndpointName.Timesheets, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update Timesheets.
        /// </summary>
        /// <remarks>
        /// Edit a single timesheet in your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Timesheet, ResultsMeta) UpdateTimesheet(
            Timesheet timesheet)
        {
            (IList<Timesheet> timesheets, ResultsMeta resultsMeta) =
                UpdateTimesheets(new[] { timesheet });

            return (timesheets.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Timesheets.
        /// </summary>
        /// <remarks>
        /// Edit one or more timesheets in your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Timesheet>, ResultsMeta) UpdateTimesheets(IEnumerable<Timesheet> timesheets)
        {
            return AsyncUtil.RunSync(() => UpdateTimesheetsAsync(timesheets));
        }

        /// <summary>
        /// Asynchronously Update Timesheets.
        /// </summary>
        /// <remarks>
        /// Edit a single timesheet in your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Timesheet, ResultsMeta)> UpdateTimesheetAsync(
            Timesheet timesheet)
        {
            (IList<Timesheet> timesheets, ResultsMeta resultsMeta) =
                await UpdateTimesheetsAsync(new[] { timesheet }, default).ConfigureAwait(false);

            return (timesheets.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit a single timesheet in your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Timesheet, ResultsMeta)> UpdateTimesheetAsync(
            Timesheet timesheet,
            CancellationToken cancellationToken)
        {
            (IList<Timesheet> timesheets, ResultsMeta resultsMeta) =
                await UpdateTimesheetsAsync(new[] { timesheet }, cancellationToken).ConfigureAwait(false);

            return (timesheets.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Timesheets.
        /// </summary>
        /// <remarks>
        /// Edit one or more timesheets in your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Timesheet>, ResultsMeta)> UpdateTimesheetsAsync(
            IEnumerable<Timesheet> timesheets)
        {
            return await UpdateTimesheetsAsync(timesheets, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit one or more timesheets in your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Timesheet>, ResultsMeta)> UpdateTimesheetsAsync(
            IEnumerable<Timesheet> timesheets,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<Timesheet>(EndpointName.Timesheets, timesheets);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be deleted.
        /// </param>
        public void DeleteTimesheet(Timesheet timesheet)
        {
            AsyncUtil.RunSync(() => DeleteTimesheetAsync(timesheet));
        }

        /// <summary>
        /// Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Timesheet"/> object to be deleted.
        /// </param>
        public void DeleteTimesheet(int id)
        {
            AsyncUtil.RunSync(() => DeleteTimesheetAsync(id));
        }

        /// <summary>
        /// Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        public void DeleteTimesheets(IEnumerable<Timesheet> timesheets)
        {
            AsyncUtil.RunSync(() => DeleteTimesheetsAsync(timesheets));
        }

        /// <summary>
        /// Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        public void DeleteTimesheets(IEnumerable<int> ids)
        {
            AsyncUtil.RunSync(() => DeleteTimesheetsAsync(ids));
        }

        /// <summary>
        /// Asynchronously Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteTimesheetAsync(
            Timesheet timesheet)
        {
            await DeleteTimesheetsAsync(new[] { timesheet.Id }, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteTimesheetAsync(
            Timesheet timesheet,
            CancellationToken cancellationToken)
        {
            await DeleteTimesheetsAsync(new[] { timesheet.Id }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Timesheet"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteTimesheetAsync(
            int id)
        {
            await DeleteTimesheetsAsync(new[] { id }, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Timesheet"/> object to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteTimesheetAsync(
            int id,
            CancellationToken cancellationToken)
        {
            await DeleteTimesheetsAsync(new[] { id }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteTimesheetsAsync(
            IEnumerable<Timesheet> timesheets)
        {
            IEnumerable<int> ids = timesheets.Select(t => t.Id);

            await DeleteTimesheetsAsync(ids, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteTimesheetsAsync(
            IEnumerable<Timesheet> timesheets,
            CancellationToken cancellationToken)
        {
            IEnumerable<int> ids = timesheets.Select(t => t.Id);

            await DeleteTimesheetsAsync(ids, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteTimesheetsAsync(
            IEnumerable<int> ids)
        {
            await DeleteTimesheetsAsync(ids, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteTimesheetsAsync(
            IEnumerable<int> ids,
            CancellationToken cancellationToken)
        {
            var context = new DeleteContext<Timesheet>(EndpointName.Timesheets, ids);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
