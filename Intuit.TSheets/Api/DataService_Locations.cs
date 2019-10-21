// *******************************************************************************
// <copyright file="DataService_Locations.cs" company="Intuit">
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
    /// This file contains operations specific to the Locations endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Locations.
        /// </summary>
        /// <remarks>
        /// Add a single location to your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Location, ResultsMeta) CreateLocation(Location location)
        {
            (IList<Location> locations, ResultsMeta resultsMeta) = CreateLocations(new[] { location });

            return (locations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Locations.
        /// </summary>
        /// <remarks>
        /// Add one or more locations to your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Location>, ResultsMeta) CreateLocations(IEnumerable<Location> locations)
        {
            return AsyncUtil.RunSync(() => CreateLocationsAsync(locations));
        }

        /// <summary>
        /// Asynchronously Create Locations.
        /// </summary>
        /// <remarks>
        /// Add a single location to your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Location, ResultsMeta)> CreateLocationAsync(
            Location location)
        {
            (IList<Location> locations, ResultsMeta resultsMeta) = await CreateLocationsAsync(new[] { location }, default).ConfigureAwait(false);

            return (locations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Locations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single location to your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Location, ResultsMeta)> CreateLocationAsync(
            Location location,
            CancellationToken cancellationToken)
        {
            (IList<Location> locations, ResultsMeta resultsMeta) = await CreateLocationsAsync(new[] { location }, cancellationToken).ConfigureAwait(false);

            return (locations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Locations.
        /// </summary>
        /// <remarks>
        /// Add one or more locations to your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Location>, ResultsMeta)> CreateLocationsAsync(
            IEnumerable<Location> locations)
        {
            return await CreateLocationsAsync(locations, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Locations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more locations to your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Location>, ResultsMeta)> CreateLocationsAsync(
            IEnumerable<Location> locations,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<Location>(EndpointName.Locations, locations);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Location>, ResultsMeta) GetLocations()
        {
            return AsyncUtil.RunSync(() => GetLocationsAsync());
        }

        /// <summary>
        /// Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Location>, ResultsMeta) GetLocations(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetLocationsAsync(options));
        }

        /// <summary>
        /// Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Location>, ResultsMeta) GetLocations(
            LocationFilter filter)
        {
            return AsyncUtil.RunSync(() => GetLocationsAsync(filter));
        }

        /// <summary>
        /// Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
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
        public (IList<Location>, ResultsMeta) GetLocations(
            LocationFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetLocationsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Location>, ResultsMeta)> GetLocationsAsync()
        {
            return await GetLocationsAsync(null, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Locations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(
            CancellationToken cancellationToken)
        {
            return await GetLocationsAsync(null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(
            RequestOptions options)
        {
            return await GetLocationsAsync(null, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Locations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
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
        public async Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            return await GetLocationsAsync(null, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(
            LocationFilter filter)
        {
            return await GetLocationsAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Locations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
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
        public async Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(
            LocationFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetLocationsAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
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
        public async Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(
            LocationFilter filter,
            RequestOptions options)
        {
            return await GetLocationsAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Locations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
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
        public async Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(
            LocationFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<Location>(EndpointName.Locations, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update Locations.
        /// </summary>
        /// <remarks>
        /// Edit a single location in your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Location, ResultsMeta) UpdateLocation(Location location)
        {
            (IList<Location> locations, ResultsMeta resultsMeta) =
                UpdateLocations(new[] { location });

            return (locations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Locations.
        /// </summary>
        /// <remarks>
        /// Edit one or more locations in your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Location>, ResultsMeta) UpdateLocations(IEnumerable<Location> locations)
        {
            return AsyncUtil.RunSync(() => UpdateLocationsAsync(locations));
        }

        /// <summary>
        /// Asynchronously Update Locations.
        /// </summary>
        /// <remarks>
        /// Edit a single location in your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Location, ResultsMeta)> UpdateLocationAsync(
            Location location)
        {
            (IList<Location> locations, ResultsMeta resultsMeta) =
                await UpdateLocationsAsync(new[] { location }, default).ConfigureAwait(false);

            return (locations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Locations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit a single location in your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Location, ResultsMeta)> UpdateLocationAsync(
            Location location,
            CancellationToken cancellationToken)
        {
            (IList<Location> locations, ResultsMeta resultsMeta) =
               await UpdateLocationsAsync(new[] { location }, cancellationToken).ConfigureAwait(false);

            return (locations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Locations.
        /// </summary>
        /// <remarks>
        /// Edit one or more locations in your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Location>, ResultsMeta)> UpdateLocationsAsync(
            IEnumerable<Location> locations)
        {
            return await UpdateLocationsAsync(locations, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update Locations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit one or more locations in your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Location>, ResultsMeta)> UpdateLocationsAsync(
            IEnumerable<Location> locations,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<Location>(EndpointName.Locations, locations);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
