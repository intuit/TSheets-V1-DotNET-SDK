// *******************************************************************************
// <copyright file="DataService_Geolocations.cs" company="Intuit">
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
    /// This file contains operations specific to the Geolocations endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Geolocations.
        /// </summary>
        /// <param name="geolocations">
        /// The set of <see cref="Geolocation"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Geolocation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Geolocation>, ResultsMeta) CreateGeolocations(IEnumerable<Geolocation> geolocations)
        {
            return AsyncUtil.RunSync(() => CreateGeolocationsAsync(geolocations));
        }

        /// <summary>
        /// Create Geolocations.
        /// </summary>
        /// <param name="geolocation">
        /// The <see cref="Geolocation"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Geolocation"/> object that was created, along with as output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Geolocation, ResultsMeta) CreateGeolocation(Geolocation geolocation)
        {
            (IList<Geolocation> geolocations, ResultsMeta resultsMeta) = CreateGeolocations(new[] { geolocation });

            return (geolocations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Geolocations.
        /// </summary>
        /// <param name="geolocations">
        /// The set of <see cref="Geolocation"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Geolocation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Geolocation>, ResultsMeta)> CreateGeolocationsAsync(IEnumerable<Geolocation> geolocations)
        {
            var context = new CreateContext<Geolocation>(EndpointName.Geolocations, geolocations);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Geolocations.
        /// </summary>
        /// <param name="geolocation">
        /// The <see cref="Geolocation"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Geolocation"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Geolocation, ResultsMeta)> CreateGeolocationAsync(Geolocation geolocation)
        {
            (IList<Geolocation> geolocations, ResultsMeta resultsMeta) = await CreateGeolocationsAsync(new[] { geolocation }).ConfigureAwait(false);

            return (geolocations.FirstOrDefault(), resultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Geolocations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of geolocations associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GeolocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Geolocation"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Geolocation>, ResultsMeta) GetGeolocations(
            GeolocationFilter filter,
            RequestOptions options = null)
        {
            return AsyncUtil.RunSync(() => GetGeolocationsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Geolocations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of geolocations associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GeolocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Geolocation"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Geolocation>, ResultsMeta)> GetGeolocationsAsync(
            GeolocationFilter filter,
            RequestOptions options = null)
        {
            var context = new GetContext<Geolocation>(EndpointName.Geolocations, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
