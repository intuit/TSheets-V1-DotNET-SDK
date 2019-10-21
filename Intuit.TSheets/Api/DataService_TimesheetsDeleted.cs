// *******************************************************************************
// <copyright file="DataService_TimesheetsDeleted.cs" company="Intuit">
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
    /// This file contains operations specific to the TimesheetsDeleted endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Deleted Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all deleted timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetsDeletedFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimesheetsDeleted"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<TimesheetsDeleted>, ResultsMeta) GetTimesheetsDeleted(
            TimesheetsDeletedFilter filter)
        {
            return AsyncUtil.RunSync(() => GetTimesheetsDeletedAsync(filter));
        }

        /// <summary>
        /// Retrieve Deleted Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all deleted timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetsDeletedFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimesheetsDeleted"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<TimesheetsDeleted>, ResultsMeta) GetTimesheetsDeleted(
            TimesheetsDeletedFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetTimesheetsDeletedAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Deleted Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all deleted timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetsDeletedFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimesheetsDeleted"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimesheetsDeleted>, ResultsMeta)> GetTimesheetsDeletedAsync(
            TimesheetsDeletedFilter filter)
        {
            return await GetTimesheetsDeletedAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Deleted Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all deleted timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetsDeletedFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimesheetsDeleted"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimesheetsDeleted>, ResultsMeta)> GetTimesheetsDeletedAsync(
            TimesheetsDeletedFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetTimesheetsDeletedAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Deleted Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all deleted timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetsDeletedFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimesheetsDeleted"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimesheetsDeleted>, ResultsMeta)> GetTimesheetsDeletedAsync(
            TimesheetsDeletedFilter filter,
            RequestOptions options)
        {
            return await GetTimesheetsDeletedAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Deleted Timesheets, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all deleted timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetsDeletedFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimesheetsDeleted"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimesheetsDeleted>, ResultsMeta)> GetTimesheetsDeletedAsync(
            TimesheetsDeletedFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<TimesheetsDeleted>(EndpointName.TimesheetsDeleted, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
