// *******************************************************************************
// <copyright file="DataService_CustomFields.cs" company="Intuit">
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
    using System;
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
    /// This file contains operations specific to the CustomFields endpoint.
    /// </remarks>  
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Custom Fields.
        /// </summary>
        /// <remarks>
        /// Create a single <see cref="CustomField"/> object.
        /// </remarks>
        /// <param name="customField">
        /// The <see cref="CustomField"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="CustomField"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (CustomField, ResultsMeta) CreateCustomField(
            CustomField customField)
        {
            (IList<CustomField> customFields, ResultsMeta resultsMeta) =
                CreateCustomFields(new[] { customField });

            return (customFields.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Custom Fields.
        /// </summary>
        /// <remarks>
        /// Create one or more <see cref="CustomField"/> objects.
        /// </remarks>
        /// <param name="customFields">
        /// The set of <see cref="CustomField"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomField"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomField>, ResultsMeta resultsMeta) CreateCustomFields(
            IEnumerable<CustomField> customFields)
        {
            return AsyncUtil.RunSync(() => CreateCustomFieldsAsync(customFields));
        }

        /// <summary>
        /// Asynchronously Create Custom Fields.
        /// </summary>
        /// <remarks>
        /// Create a single <see cref="CustomField"/> object.
        /// </remarks>
        /// <param name="customField">
        /// The <see cref="CustomField"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="CustomField"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CustomField, ResultsMeta)> CreateCustomFieldAsync(
            CustomField customField)
        {
            (IList<CustomField> customFields, ResultsMeta resultsMeta) =
                await CreateCustomFieldsAsync(new[] { customField }, default).ConfigureAwait(false);

            return (customFields.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Custom Fields, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Create a single <see cref="CustomField"/> object.
        /// </remarks>
        /// <param name="customField">
        /// The <see cref="CustomField"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="CustomField"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CustomField, ResultsMeta)> CreateCustomFieldAsync(
            CustomField customField,
            CancellationToken cancellationToken)
        {
            (IList<CustomField> customFields, ResultsMeta resultsMeta) =
                await CreateCustomFieldsAsync(new[] { customField }, cancellationToken).ConfigureAwait(false);

            return (customFields.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Custom Fields.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="CustomField"/> objects.
        /// </remarks>
        /// <param name="customFields">
        /// The set of <see cref="CustomField"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomField"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomField>, ResultsMeta resultsMeta)> CreateCustomFieldsAsync(
            IEnumerable<CustomField> customFields)
        {
            return await CreateCustomFieldsAsync(customFields, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Custom Fields, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="CustomField"/> objects.
        /// </remarks>
        /// <param name="customFields">
        /// The set of <see cref="CustomField"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomField"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomField>, ResultsMeta resultsMeta)> CreateCustomFieldsAsync(
            IEnumerable<CustomField> customFields,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<CustomField>(EndpointName.CustomFields, customFields);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<CustomField>, ResultsMeta) GetCustomFields()
        {
            return AsyncUtil.RunSync(() => GetCustomFieldsAsync());
        }

        /// <summary>
        /// Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<CustomField>, ResultsMeta) GetCustomFields(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldsAsync(options));
        }

        /// <summary>
        /// Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<CustomField>, ResultsMeta) GetCustomFields(
            CustomFieldFilter filter)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldsAsync(filter));
        }

        /// <summary>
        /// Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<CustomField>, ResultsMeta) GetCustomFields(
            CustomFieldFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCustomFieldsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync()
        {
            return await GetCustomFieldsAsync(null, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Fields, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            CancellationToken cancellationToken)
        {
            return await GetCustomFieldsAsync(null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            RequestOptions options)
        {
            return await GetCustomFieldsAsync(null, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Fields, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            return await GetCustomFieldsAsync(null, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            CustomFieldFilter filter)
        {
            return await GetCustomFieldsAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Fields, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            CustomFieldFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetCustomFieldsAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            CustomFieldFilter filter,
            RequestOptions options)
        {
            return await GetCustomFieldsAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Custom Fields, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            CustomFieldFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<CustomField>(EndpointName.CustomFields, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update Custom Fields.
        /// </summary>
        /// <remarks>
        /// Update a single <see cref="CustomField"/> object.
        /// </remarks>
        /// <param name="customField">
        /// The <see cref="CustomField"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="CustomField"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (CustomField, ResultsMeta) UpdateCustomField(
            CustomField customField)
        {
            (IList<CustomField> customFields, ResultsMeta resultsMeta) =
                UpdateCustomFields(new[] { customField });

            return (customFields.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Custom Fields.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="CustomField"/> objects.
        /// </remarks>
        /// <param name="customFields">
        /// The set of <see cref="CustomField"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomField"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<CustomField>, ResultsMeta resultsMeta) UpdateCustomFields(
            IEnumerable<CustomField> customFields)
        {
            return AsyncUtil.RunSync(() => UpdateCustomFieldsAsync(customFields));
        }

        /// <summary>
        /// Asynchronously Update Custom Fields.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomField"/> object.
        /// </remarks>
        /// <param name="customField">
        /// The <see cref="CustomField"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="CustomField"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CustomField, ResultsMeta)> UpdateCustomFieldAsync(
            CustomField customField)
        {
            (IList<CustomField> customFields, ResultsMeta resultsMeta) =
                await UpdateCustomFieldsAsync(new[] { customField }, default).ConfigureAwait(false);

            return (customFields.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Custom Fields, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomField"/> object.
        /// </remarks>
        /// <param name="customField">
        /// The <see cref="CustomField"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="CustomField"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(CustomField, ResultsMeta)> UpdateCustomFieldAsync(
            CustomField customField,
            CancellationToken cancellationToken)
        {
            (IList<CustomField> customFields, ResultsMeta resultsMeta) =
                await UpdateCustomFieldsAsync(new[] { customField }, cancellationToken).ConfigureAwait(false);

            return (customFields.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Custom Fields.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="CustomField"/> objects.
        /// </remarks>
        /// <param name="customFields">
        /// The set of <see cref="CustomField"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomField"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomField>, ResultsMeta resultsMeta)> UpdateCustomFieldsAsync(
            IEnumerable<CustomField> customFields)
        {
            return await UpdateCustomFieldsAsync(customFields, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update Custom Fields, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="CustomField"/> objects.
        /// </remarks>
        /// <param name="customFields">
        /// The set of <see cref="CustomField"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomField"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<CustomField>, ResultsMeta resultsMeta)> UpdateCustomFieldsAsync(
            IEnumerable<CustomField> customFields,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<CustomField>(EndpointName.CustomFields, customFields);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
