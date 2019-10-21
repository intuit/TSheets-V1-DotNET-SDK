// *******************************************************************************
// <copyright file="DataService_CustomFieldItems.cs" company="Intuit">
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

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    /// <remarks>
    /// This file contains operations specific to the CustomFieldItems endpoint.
    /// </remarks>  
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomFieldItem"/> object to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (CustomFieldItem, ResultsMeta) CreateCustomFieldItem(CustomFieldItem customFieldItem)
        {
            (IList<CustomFieldItem> customFieldItems, ResultsMeta resultsMeta) =
                CreateCustomFieldItems(new[] { customFieldItem });

            return (customFieldItems.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="CustomFieldItem"/> objects to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItem>, ResultsMeta resultsMeta) CreateCustomFieldItems(
            IEnumerable<CustomFieldItem> customFieldItems)
        {
            return AsyncUtil.RunSync(() => CreateCustomFieldItemsAsync(customFieldItems));
        }

        /// <summary>
        /// Asynchronously Create Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomFieldItem"/> object to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CustomFieldItem, ResultsMeta)> CreateCustomFieldItemAsync(
            CustomFieldItem customFieldItem)
        {
            (IList<CustomFieldItem> customFieldItems, ResultsMeta resultsMeta) =
                await CreateCustomFieldItemsAsync(new[] { customFieldItem }, default).ConfigureAwait(false);

            return (customFieldItems.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Custom Field Items, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomFieldItem"/> object to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CustomFieldItem, ResultsMeta)> CreateCustomFieldItemAsync(
            CustomFieldItem customFieldItem,
            CancellationToken cancellationToken)
        {
            (IList<CustomFieldItem> customFieldItems, ResultsMeta resultsMeta) =
                await CreateCustomFieldItemsAsync(new[] { customFieldItem }, cancellationToken).ConfigureAwait(false);

            return (customFieldItems.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="CustomFieldItem"/> objects to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItem>, ResultsMeta resultsMeta)> CreateCustomFieldItemsAsync(
            IEnumerable<CustomFieldItem> customFieldItems)
        {
            return await CreateCustomFieldItemsAsync(customFieldItems, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Custom Field Items, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="CustomFieldItem"/> objects to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItem>, ResultsMeta resultsMeta)> CreateCustomFieldItemsAsync(
            IEnumerable<CustomFieldItem> customFieldItems,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<CustomFieldItem>(EndpointName.CustomFieldItems, customFieldItems);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field items associated with a custom field,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="Model.Filters.CustomFieldItemFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItem>, ResultsMeta) GetCustomFieldItems(
            Model.Filters.CustomFieldItemFilter filter)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemsAsync(filter));
        }

        /// <summary>
        /// Retrieve Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field items associated with a custom field,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="Model.Filters.CustomFieldItemFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItem>, ResultsMeta) GetCustomFieldItems(
            Model.Filters.CustomFieldItemFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldItemsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field items associated with a custom field,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="Model.Filters.CustomFieldItemFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItem>, ResultsMeta)> GetCustomFieldItemsAsync(
            Model.Filters.CustomFieldItemFilter filter)
        {
            return await GetCustomFieldItemsAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Items, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field items associated with a custom field,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="Model.Filters.CustomFieldItemFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItem>, ResultsMeta)> GetCustomFieldItemsAsync(
            Model.Filters.CustomFieldItemFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetCustomFieldItemsAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field items associated with a custom field,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="Model.Filters.CustomFieldItemFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItem>, ResultsMeta)> GetCustomFieldItemsAsync(
            Model.Filters.CustomFieldItemFilter filter,
            RequestOptions options)
        {
            return await GetCustomFieldItemsAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Field Items, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field items associated with a custom field,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="Model.Filters.CustomFieldItemFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItem>, ResultsMeta)> GetCustomFieldItemsAsync(
            Model.Filters.CustomFieldItemFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<CustomFieldItem>(EndpointName.CustomFieldItems, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// Update Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Update a single <see cref="CustomFieldItem"/> object on a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (CustomFieldItem, ResultsMeta) UpdateCustomFieldItem(
            CustomFieldItem customFieldItem)
        {
            (IList<CustomFieldItem> customFieldItems, ResultsMeta resultsMeta) =
                UpdateCustomFieldItems(new[] { customFieldItem });

            return (customFieldItems.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="CustomFieldItem"/> objects on a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomFieldItem>, ResultsMeta resultsMeta) UpdateCustomFieldItems(
            IEnumerable<CustomFieldItem> customFieldItems)
        {
            return AsyncUtil.RunSync(() => UpdateCustomFieldItemsAsync(customFieldItems));
        }

        /// <summary>
        /// Asynchronously Update Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomFieldItem"/> object to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CustomFieldItem, ResultsMeta)> UpdateCustomFieldItemAsync(
            CustomFieldItem customFieldItem)
        {
            (IList<CustomFieldItem> customFieldItems, ResultsMeta resultsMeta) =
                await UpdateCustomFieldItemsAsync(new[] { customFieldItem }, default).ConfigureAwait(false);

            return (customFieldItems.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Custom Field Items, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomFieldItem"/> object to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CustomFieldItem, ResultsMeta)> UpdateCustomFieldItemAsync(
            CustomFieldItem customFieldItem,
            CancellationToken cancellationToken)
        {
            (IList<CustomFieldItem> customFieldItems, ResultsMeta resultsMeta) =
                await UpdateCustomFieldItemsAsync(new[] { customFieldItem }, cancellationToken).ConfigureAwait(false);

            return (customFieldItems.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="CustomFieldItem"/> objects on a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItem>, ResultsMeta resultsMeta)> UpdateCustomFieldItemsAsync(
            IEnumerable<CustomFieldItem> customFieldItems)
        {
            return await UpdateCustomFieldItemsAsync(customFieldItems, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update Custom Field Items, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="CustomFieldItem"/> objects on a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomFieldItem>, ResultsMeta resultsMeta)> UpdateCustomFieldItemsAsync(
            IEnumerable<CustomFieldItem> customFieldItems,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<CustomFieldItem>(EndpointName.CustomFieldItems, customFieldItems);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
