// *******************************************************************************
// <copyright file="DataService_CustomFieldItemUserFilters.cs" company="Intuit">
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
    /// This file contains operations specific to the CustomFieldItemUserFilters endpoint.
    /// </remarks>  
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemUserFilter>, ResultsMeta) GetCustomFieldItemUserFilters()
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemUserFiltersAsync());
        }

        /// <summary>
        /// Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemUserFilter>, ResultsMeta) GetCustomFieldItemUserFilters(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemUserFiltersAsync(options));
        }

        /// <summary>
        /// Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemUserFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemUserFilter>, ResultsMeta) GetCustomFieldItemUserFilters(
            CustomFieldItemUserFilterFilter filter)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemUserFiltersAsync(filter));
        }

        /// <summary>
        /// Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemUserFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItemUserFilter>, ResultsMeta) GetCustomFieldItemUserFilters(
            CustomFieldItemUserFilterFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemUserFiltersAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemUserFilter>, ResultsMeta)> GetCustomFieldItemUserFiltersAsync()
        {
            return await GetCustomFieldItemUserFiltersAsync(null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemUserFilter>, ResultsMeta)> GetCustomFieldItemUserFiltersAsync(
            RequestOptions options)
        {
            return await GetCustomFieldItemUserFiltersAsync(null, options).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemUserFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemUserFilter>, ResultsMeta)> GetCustomFieldItemUserFiltersAsync(
            CustomFieldItemUserFilterFilter filter)
        {
            return await GetCustomFieldItemUserFiltersAsync(filter, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemUserFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItemUserFilter>, ResultsMeta)> GetCustomFieldItemUserFiltersAsync(
            CustomFieldItemUserFilterFilter filter,
            RequestOptions options)
        {
            var context = new GetContext<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
