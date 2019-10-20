// *******************************************************************************
// <copyright file="DataService_Groups.cs" company="Intuit">
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
    /// This file contains operations specific to the Groups endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Groups.
        /// </summary>
        /// <remarks>
        /// Add a single group to your company.
        /// </remarks> 
        /// <param name="group">
        /// The <see cref="Group"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Group, ResultsMeta) CreateGroup(Group group)
        {
            (IList<Group> groups, ResultsMeta resultsMeta) = CreateGroups(new[] { group });

            return (groups.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Groups.
        /// </summary>
        /// <remarks>
        /// Add one or more groups to your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Group>, ResultsMeta) CreateGroups(IEnumerable<Group> groups)
        {
            return AsyncUtil.RunSync(() => CreateGroupsAsync(groups));
        }

        /// <summary>
        /// Asynchronously Create Groups.
        /// </summary>
        /// <remarks>
        /// Add a single group to your company.
        /// </remarks>
        /// <param name="group">
        /// The <see cref="Group"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Group, ResultsMeta)> CreateGroupAsync(
            Group group)
        {
            (IList<Group> groups, ResultsMeta resultsMeta) = await CreateGroupsAsync(new[] { group }, default).ConfigureAwait(false);

            return (groups.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Groups, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single group to your company.
        /// </remarks>
        /// <param name="group">
        /// The <see cref="Group"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Group, ResultsMeta)> CreateGroupAsync(
            Group group,
            CancellationToken cancellationToken)
        {
            (IList<Group> groups, ResultsMeta resultsMeta) = await CreateGroupsAsync(new[] { group }, cancellationToken).ConfigureAwait(false);

            return (groups.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Groups.
        /// </summary>
        /// <remarks>
        /// Add one or more groups to your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Group>, ResultsMeta)> CreateGroupsAsync(
            IEnumerable<Group> groups)
        {
            return await CreateGroupsAsync(groups, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Groups, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more groups to your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Group>, ResultsMeta)> CreateGroupsAsync(
            IEnumerable<Group> groups,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<Group>(EndpointName.Groups, groups);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Group>, ResultsMeta) GetGroups()
        {
            return AsyncUtil.RunSync(() => GetGroupsAsync());
        }

        /// <summary>
        /// Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Group>, ResultsMeta) GetGroups(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetGroupsAsync(options));
        }

        /// <summary>
        /// Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GroupFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Group>, ResultsMeta) GetGroups(
            GroupFilter filter)
        {
            return AsyncUtil.RunSync(() => GetGroupsAsync(filter));
        }

        /// <summary>
        /// Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GroupFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Group>, ResultsMeta) GetGroups(
            GroupFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetGroupsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Group>, ResultsMeta)> GetGroupsAsync()
        {
            return await GetGroupsAsync(null, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Groups, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(
            CancellationToken cancellationToken)
        {
            return await GetGroupsAsync(null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(
            RequestOptions options)
        {
            return await GetGroupsAsync(null, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Groups, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            return await GetGroupsAsync(null, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GroupFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(
            GroupFilter filter)
        {
            return await GetGroupsAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Groups, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GroupFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(
            GroupFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetGroupsAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GroupFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(
            GroupFilter filter,
            RequestOptions options)
        {
            return await GetGroupsAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Groups, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GroupFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(
            GroupFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<Group>(EndpointName.Groups, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// Update Groups.
        /// </summary>
        /// <remarks>
        /// Edit a single group in your company.
        /// </remarks>
        /// <param name="group">
        /// The <see cref="Group"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Group, ResultsMeta) UpdateGroup(Group group)
        {
            (IList<Group> groups, ResultsMeta resultsMeta) = UpdateGroups(new[] { group });

            return (groups.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Groups.
        /// </summary>
        /// <remarks>
        /// Edit one or more groups in your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Group>, ResultsMeta) UpdateGroups(IEnumerable<Group> groups)
        {
            return AsyncUtil.RunSync(() => UpdateGroupsAsync(groups));
        }

        /// <summary>
        /// Asynchronously Update Groups.
        /// </summary>
        /// <remarks>
        /// Edit a single group in your company.
        /// </remarks>
        /// <param name="group">
        /// The <see cref="Group"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Group, ResultsMeta)> UpdateGroupAsync(
            Group group)
        {
            (IList<Group> groups, ResultsMeta resultsMeta) =
                await UpdateGroupsAsync(new[] { group }, default).ConfigureAwait(false);

            return (groups.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Groups, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit a single group in your company.
        /// </remarks>
        /// <param name="group">
        /// The <see cref="Group"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Group, ResultsMeta)> UpdateGroupAsync(
            Group group,
            CancellationToken cancellationToken)
        {
            (IList<Group> groups, ResultsMeta resultsMeta) =
                await UpdateGroupsAsync(new[] { group }, cancellationToken).ConfigureAwait(false);

            return (groups.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Groups.
        /// </summary>
        /// <remarks>
        /// Edit one or more groups in your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Group>, ResultsMeta)> UpdateGroupsAsync(
            IEnumerable<Group> groups)
        {
            return await UpdateGroupsAsync(groups, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update Groups, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit one or more groups in your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Group>, ResultsMeta)> UpdateGroupsAsync(
            IEnumerable<Group> groups,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<Group>(EndpointName.Groups, groups);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
