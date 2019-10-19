// *******************************************************************************
// <copyright file="DataService_CurrentUser.cs" company="Intuit">
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
    using System.Linq;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    /// <remarks>
    /// This file contains operations specific to the CurrentUser endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve the Current User.
        /// </summary>
        /// <remarks>
        /// Retrieves the user object for the currently authenticated user. This is the
        /// user that authenticated to TSheets during the OAuth2 authentication process.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="User"/> class, representing the current user, along
        /// with an output instance of the <see cref="ResultsMeta"/> class containing additional
        /// data.
        /// </returns>
        public (User, ResultsMeta) GetCurrentUser()
        {
            return AsyncUtil.RunSync(() => GetCurrentUserAsync());
        }

        /// <summary>
        /// Retrieve the Current User.
        /// </summary>
        /// <remarks>
        /// Retrieves the user object for the currently authenticated user. This is the
        /// user that authenticated to TSheets during the OAuth2 authentication process.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="User"/> class, representing the current user, along
        /// with an output instance of the <see cref="ResultsMeta"/> class containing additional
        /// data.
        /// </returns>
        public (User, ResultsMeta) GetCurrentUser(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetCurrentUserAsync(options));
        }

        /// <summary>
        /// Asynchronously Retrieve the Current User.
        /// </summary>
        /// <remarks>
        /// Retrieves the user object for the currently authenticated user. This is the
        /// user that authenticated to TSheets during the OAuth2 authentication process.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="User"/> class, representing the current user, along
        /// with an output instance of the <see cref="ResultsMeta"/> class containing additional
        /// data.
        /// </returns>
        public async Task<(User, ResultsMeta)> GetCurrentUserAsync()
        {
            return await GetCurrentUserAsync(null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve the Current User.
        /// </summary>
        /// <remarks>
        /// Retrieves the user object for the currently authenticated user. This is the
        /// user that authenticated to TSheets during the OAuth2 authentication process.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="User"/> class, representing the current user, along
        /// with an output instance of the <see cref="ResultsMeta"/> class containing additional
        /// data.
        /// </returns>
        public async Task<(User, ResultsMeta)> GetCurrentUserAsync(
            RequestOptions options)
        {
            var context = new GetContext<User>(EndpointName.CurrentUser, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items.FirstOrDefault(), context.ResultsMeta);
        }

        #endregion
    }
}
