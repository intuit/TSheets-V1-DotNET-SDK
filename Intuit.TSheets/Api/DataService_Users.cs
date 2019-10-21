// *******************************************************************************
// <copyright file="DataService_Users.cs" company="Intuit">
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
    /// This file contains operations specific to the Users endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Users.
        /// </summary>
        /// <remarks>
        /// Add a single user to your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (User, ResultsMeta) CreateUser(User user)
        {
            (IList<User> users, ResultsMeta resultsMeta) = CreateUsers(new[] { user });

            return (users.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Users.
        /// </summary>
        /// <remarks>
        /// Add one or more users to your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<User>, ResultsMeta) CreateUsers(IEnumerable<User> users)
        {
            return AsyncUtil.RunSync(() => CreateUsersAsync(users));
        }

        /// <summary>
        /// Asynchronously Create Users.
        /// </summary>
        /// <remarks>
        /// Add a single user to your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(User, ResultsMeta)> CreateUserAsync(
            User user)
        {
            (IList<User> users, ResultsMeta resultsMeta) = await CreateUsersAsync(new[] { user }, default).ConfigureAwait(false);

            return (users.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Users, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single user to your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(User, ResultsMeta)> CreateUserAsync(
            User user,
            CancellationToken cancellationToken)
        {
            (IList<User> users, ResultsMeta resultsMeta) = await CreateUsersAsync(new[] { user }, cancellationToken).ConfigureAwait(false);

            return (users.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Users.
        /// </summary>
        /// <remarks>
        /// Add one or more users to your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<User>, ResultsMeta)> CreateUsersAsync(
            IEnumerable<User> users)
        {
            return await CreateUsersAsync(users, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Users, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more users to your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<User>, ResultsMeta)> CreateUsersAsync(
            IEnumerable<User> users,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<User>(EndpointName.Users, users);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<User>, ResultsMeta) GetUsers()
        {
            return AsyncUtil.RunSync(() => GetUsersAsync());
        }

        /// <summary>
        /// Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<User>, ResultsMeta) GetUsers(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetUsersAsync(options));
        }

        /// <summary>
        /// Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="UserFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<User>, ResultsMeta) GetUsers(
            UserFilter filter)
        {
            return AsyncUtil.RunSync(() => GetUsersAsync(filter));
        }

        /// <summary>
        /// Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="UserFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<User>, ResultsMeta) GetUsers(
            UserFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetUsersAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<User>, ResultsMeta)> GetUsersAsync()
        {
            return await GetUsersAsync(null, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Users, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<User>, ResultsMeta)> GetUsersAsync(
            CancellationToken cancellationToken)
        {
            return await GetUsersAsync(null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<User>, ResultsMeta)> GetUsersAsync(
            RequestOptions options)
        {
            return await GetUsersAsync(null, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Users, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<User>, ResultsMeta)> GetUsersAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            return await GetUsersAsync(null, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="UserFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<User>, ResultsMeta)> GetUsersAsync(
            UserFilter filter)
        {
            return await GetUsersAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Users, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="UserFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<User>, ResultsMeta)> GetUsersAsync(
            UserFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetUsersAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="UserFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<User>, ResultsMeta)> GetUsersAsync(
            UserFilter filter,
            RequestOptions options)
        {
            return await GetUsersAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Users, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="UserFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<User>, ResultsMeta)> GetUsersAsync(
            UserFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<User>(EndpointName.Users, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update Users.
        /// </summary>
        /// <remarks>
        /// Edit a single user in your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (User, ResultsMeta) UpdateUser(User user)
        {
            (IList<User> users, ResultsMeta resultsMeta) = UpdateUsers(new[] { user });

            return (users.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Users.
        /// </summary>
        /// <remarks>
        /// Edit one or more users in your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<User>, ResultsMeta) UpdateUsers(IEnumerable<User> users)
        {
            return AsyncUtil.RunSync(() => UpdateUsersAsync(users));
        }

        /// <summary>
        /// Asynchronously Update Users.
        /// </summary>
        /// <remarks>
        /// Edit a single user in your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(User, ResultsMeta)> UpdateUserAsync(
            User user)
        {
            (IList<User> users, ResultsMeta resultsMeta) = await UpdateUsersAsync(new[] { user }, default).ConfigureAwait(false);

            return (users.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Users, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit a single user in your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(User, ResultsMeta)> UpdateUserAsync(
            User user,
            CancellationToken cancellationToken)
        {
            (IList<User> users, ResultsMeta resultsMeta) = await UpdateUsersAsync(new[] { user }, cancellationToken).ConfigureAwait(false);

            return (users.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Users.
        /// </summary>
        /// <remarks>
        /// Edit one or more users in your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<User>, ResultsMeta)> UpdateUsersAsync(
            IEnumerable<User> users)
        {
            return await UpdateUsersAsync(users, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update Users, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit one or more users in your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<User>, ResultsMeta)> UpdateUsersAsync(
            IEnumerable<User> users,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<User>(EndpointName.Users, users);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
