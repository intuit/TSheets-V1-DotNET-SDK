// *******************************************************************************
// <copyright file="DataService_CustomFieldItemFilters.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Filters;
    using CustomFieldItemFilter = Intuit.TSheets.Model.CustomFieldItemFilter;

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    /// <remarks>
    /// This file contains operations specific to the CustomFieldItemFilters endpoint.
    /// </remarks> 
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <returns>
        /// The set of the <see cref="Model.CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemFilter>, ResultsMeta) GetCustomFieldItemFilters()
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemFiltersAsync());
        }

        /// <summary>
        /// Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Model.CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemFilter>, ResultsMeta) GetCustomFieldItemFilters(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemFiltersAsync(options));
        }

        /// <summary>
        /// Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemFilter>, ResultsMeta) GetCustomFieldItemFilters(
            CustomFieldItemFilterFilter filter)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemFiltersAsync(filter));
        }

        /// <summary>
        /// Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemFilter>, ResultsMeta) GetCustomFieldItemFilters(
            CustomFieldItemFilterFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemFiltersAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemFilter>, ResultsMeta)> GetCustomFieldItemFiltersAsync()
        {
            return await GetCustomFieldItemFiltersAsync(null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemFilter>, ResultsMeta)> GetCustomFieldItemFiltersAsync(
            RequestOptions options)
        {
            return await GetCustomFieldItemFiltersAsync(null, options).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemFilter>, ResultsMeta)> GetCustomFieldItemFiltersAsync(
            CustomFieldItemFilterFilter filter)
        {
            return await GetCustomFieldItemFiltersAsync(filter, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemFilter>, ResultsMeta)> GetCustomFieldItemFiltersAsync(
            CustomFieldItemFilterFilter filter,
            RequestOptions options)
        {
            var context = new GetContext<CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
