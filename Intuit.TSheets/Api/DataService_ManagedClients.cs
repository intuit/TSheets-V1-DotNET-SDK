// *******************************************************************************
// <copyright file="DataService_ManagedClients.cs" company="Intuit">
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
    /// This file contains operations specific to the ManagedClients endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ManagedClient>, ResultsMeta) GetManagedClients()
        {
            return AsyncUtil.RunSync(() => GetManagedClientsAsync());
        }

        /// <summary>
        /// Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ManagedClient>, ResultsMeta) GetManagedClients(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetManagedClientsAsync(options));
        }

        /// <summary>
        /// Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ManagedClientFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ManagedClient>, ResultsMeta) GetManagedClients(
            ManagedClientFilter filter)
        {
            return AsyncUtil.RunSync(() => GetManagedClientsAsync(filter));
        }

        /// <summary>
        /// Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ManagedClientFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ManagedClient>, ResultsMeta) GetManagedClients(
            ManagedClientFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetManagedClientsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync()
        {
            return await GetManagedClientsAsync(null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Managed Clients, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(
            RequestOptions options)
        {
            return await GetManagedClientsAsync(null, options).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Managed Clients, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ManagedClientFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(
            ManagedClientFilter filter)
        {
            return await GetManagedClientsAsync(filter, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Managed Clients, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ManagedClientFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(
            ManagedClientFilter filter,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ManagedClientFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(
            ManagedClientFilter filter,
            RequestOptions options)
        {
            var context = new GetContext<ManagedClient>(EndpointName.ManagedClients, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        /// <summary>
        /// Asynchronously Retrieve Managed Clients, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ManagedClientFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(
            ManagedClientFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
