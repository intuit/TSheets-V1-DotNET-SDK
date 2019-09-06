// *******************************************************************************
// <copyright file="DataService_GeolocationsTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_GeolocationsTests : DataServiceTestBase
    {
        private static readonly GeolocationFilter DummyFilter = new GeolocationFilter
        {
            Ids = new[] { 1, 2 }
        };

        private static readonly Geolocation DummyEntity = new Geolocation();
        private static readonly List<Geolocation> DummyEntities = new List<Geolocation> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateGeolocations_TestWithoutOptions()
        {
            ExpectCreate<Geolocation>(EndpointName.Geolocations);

            VerifyResult(
                ApiService.CreateGeolocations(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateGeolocations_TestWithOptions()
        {
            ExpectCreate<Geolocation>(EndpointName.Geolocations);

            VerifyResult(
                ApiService.CreateGeolocations(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateGeolocation_TestWithoutOptions()
        {
            ExpectCreate<Geolocation>(EndpointName.Geolocations);

            VerifyResult(
                ApiService.CreateGeolocation(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateGeolocation_TestWithOptions()
        {
            ExpectCreate<Geolocation>(EndpointName.Geolocations);

            VerifyResult(
                ApiService.CreateGeolocation(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateGeolocations_TestWithoutOptionsAsync()
        {
            ExpectCreate<Geolocation>(EndpointName.Geolocations);

            VerifyResult(
                await ApiService.CreateGeolocationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateGeolocations_TestWithOptionsAsync()
        {
            ExpectCreate<Geolocation>(EndpointName.Geolocations);

            VerifyResult(
                await ApiService.CreateGeolocationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateGeolocation_TestWithoutOptionsAsync()
        {
            ExpectCreate<Geolocation>(EndpointName.Geolocations);

            VerifyResult(
                await ApiService.CreateGeolocationAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateGeolocation_TestWithOptionsAsync()
        {
            ExpectCreate<Geolocation>(EndpointName.Geolocations);

            VerifyResult(
                await ApiService.CreateGeolocationAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetGeolocations_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<Geolocation>(EndpointName.Geolocations, Params.Filter);

            VerifyResult(
                ApiService.GetGeolocations(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetGeolocations_TestWithFilterAndWithOptions()
        {
            ExpectGet<Geolocation>(EndpointName.Geolocations, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetGeolocations(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetGeolocations_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Geolocation>(EndpointName.Geolocations, Params.Filter);

            VerifyResult(
                await ApiService.GetGeolocationsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetGeolocations_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<Geolocation>(EndpointName.Geolocations, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetGeolocationsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion
    }
}
