// *******************************************************************************
// <copyright file="DataService_CustomFieldItemJobcodeFilters.cs" company="Intuit">
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
    /// This file contains operations specific to the CustomFieldItemJobcodeFilters endpoint.
    /// </remarks> 
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemJobcodeFilter>, ResultsMeta) GetCustomFieldItemJobcodeFilters()
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemJobcodeFiltersAsync());
        }

        /// <summary>
        /// Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemJobcodeFilter>, ResultsMeta) GetCustomFieldItemJobcodeFilters(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemJobcodeFiltersAsync(options));
        }

        /// <summary>
        /// Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemJobcodeFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemJobcodeFilter>, ResultsMeta) GetCustomFieldItemJobcodeFilters(
            CustomFieldItemJobcodeFilterFilter filter)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemJobcodeFiltersAsync(filter));
        }

        /// <summary>
        /// Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemJobcodeFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemJobcodeFilter>, ResultsMeta) GetCustomFieldItemJobcodeFilters(
            CustomFieldItemJobcodeFilterFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemJobcodeFiltersAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemJobcodeFilter>, ResultsMeta)> GetCustomFieldItemJobcodeFiltersAsync()
        {
            return await GetCustomFieldItemJobcodeFiltersAsync(null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemJobcodeFilter>, ResultsMeta)> GetCustomFieldItemJobcodeFiltersAsync(
            RequestOptions options)
        {
            return await GetCustomFieldItemJobcodeFiltersAsync(null, options).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemJobcodeFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemJobcodeFilter>, ResultsMeta)> GetCustomFieldItemJobcodeFiltersAsync(
            CustomFieldItemJobcodeFilterFilter filter)
        {
            return await GetCustomFieldItemJobcodeFiltersAsync(filter, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemJobcodeFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemJobcodeFilter>, ResultsMeta)> GetCustomFieldItemJobcodeFiltersAsync(
            CustomFieldItemJobcodeFilterFilter filter,
            RequestOptions options)
        {
            var context = new GetContext<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
