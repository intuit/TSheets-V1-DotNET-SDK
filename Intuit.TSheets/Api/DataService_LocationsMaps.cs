// *******************************************************************************
// <copyright file="DataService_LocationsMaps.cs" company="Intuit">
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
    /// This file contains operations specific to the LocationsMaps endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Locations Maps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations maps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="LocationsMap"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<LocationsMap>, ResultsMeta) GetLocationsMaps()
        {
            return AsyncUtil.RunSync(() => GetLocationsMapsAsync());
        }

        /// <summary>
        /// Retrieve Locations Maps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations maps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="LocationsMap"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<LocationsMap>, ResultsMeta) GetLocationsMaps(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetLocationsMapsAsync(options));
        }

        /// <summary>
        /// Retrieve Locations Maps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations maps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationsMapFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="LocationsMap"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<LocationsMap>, ResultsMeta) GetLocationsMaps(
            LocationsMapFilter filter)
        {
            return AsyncUtil.RunSync(() => GetLocationsMapsAsync(filter));
        }

        /// <summary>
        /// Retrieve Locations Maps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations maps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationsMapFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="LocationsMap"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<LocationsMap>, ResultsMeta) GetLocationsMaps(
            LocationsMapFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetLocationsMapsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync()
        {
            return await GetLocationsMapsAsync(null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(
            RequestOptions options)
        {
            return await GetLocationsMapsAsync(null, options).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(
            LocationsMapFilter filter)
        {
            return await GetLocationsMapsAsync(filter, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(
            LocationsMapFilter filter,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(
            LocationsMapFilter filter,
            RequestOptions options)
        {
            var context = new GetContext<LocationsMap>(EndpointName.LocationsMaps, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(
            LocationsMapFilter filter,
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
