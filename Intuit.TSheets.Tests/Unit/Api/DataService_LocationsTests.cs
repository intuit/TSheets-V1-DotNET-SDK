// *******************************************************************************
// <copyright file="DataService_LocationsTests.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Enums;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_LocationsTests : DataServiceTestBase
    {
        private static readonly LocationFilter DummyFilter = new LocationFilter
        {
            Active = TristateChoice.Both
        };

        private static readonly Location DummyEntity = new Location();
        private static readonly List<Location> DummyEntities = new List<Location> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateLocations_TestWithoutOptions()
        {
            ExpectCreate<Location>(EndpointName.Locations);

            VerifyResult(
                ApiService.CreateLocations(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateLocations_TestWithOptions()
        {
            ExpectCreate<Location>(EndpointName.Locations);

            VerifyResult(
                ApiService.CreateLocations(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateLocation_TestWithoutOptions()
        {
            ExpectCreate<Location>(EndpointName.Locations);

            VerifyResult(
                ApiService.CreateLocation(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateLocation_TestWithOptions()
        {
            ExpectCreate<Location>(EndpointName.Locations);

            VerifyResult(
                ApiService.CreateLocation(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateLocations_TestWithoutOptionsAsync()
        {
            ExpectCreate<Location>(EndpointName.Locations);

            VerifyResult(
                await ApiService.CreateLocationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateLocations_TestWithOptionsAsync()
        {
            ExpectCreate<Location>(EndpointName.Locations);

            VerifyResult(
                await ApiService.CreateLocationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateLocation_TestWithoutOptionsAsync()
        {
            ExpectCreate<Location>(EndpointName.Locations);

            VerifyResult(
                await ApiService.CreateLocationAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateLocation_TestWithOptionsAsync()
        {
            ExpectCreate<Location>(EndpointName.Locations);

            VerifyResult(
                await ApiService.CreateLocationAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetLocations_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<Location>(EndpointName.Locations, Params.None);

            VerifyResult(
                ApiService.GetLocations());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLocations_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<Location>(EndpointName.Locations, Params.Filter);

            VerifyResult(
                ApiService.GetLocations(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLocations_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<Location>(EndpointName.Locations, Params.RequestOptions);

            VerifyResult(
                ApiService.GetLocations(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLocations_TestWithFilterAndWithOptions()
        {
            ExpectGet<Location>(EndpointName.Locations, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetLocations(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLocations_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Location>(EndpointName.Locations, Params.None);

            VerifyResult(
                await ApiService.GetLocationsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetLocations_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Location>(EndpointName.Locations, Params.Filter);

            VerifyResult(
                await ApiService.GetLocationsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLocations_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<Location>(EndpointName.Locations, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetLocationsAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLocations_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<Location>(EndpointName.Locations, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetLocationsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateLocations_TestWithoutOptions()
        {
            ExpectUpdate<Location>(EndpointName.Locations);

            VerifyResult(
                ApiService.UpdateLocations(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateLocations_TestWithOptions()
        {
            ExpectUpdate<Location>(EndpointName.Locations);

            VerifyResult(
                ApiService.UpdateLocations(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateLocation_TestWithoutOptions()
        {
            ExpectUpdate<Location>(EndpointName.Locations);

            VerifyResult(
                ApiService.UpdateLocation(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateLocation_TestWithOptions()
        {
            ExpectUpdate<Location>(EndpointName.Locations);

            VerifyResult(
                ApiService.UpdateLocation(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateLocations_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Location>(EndpointName.Locations);

            VerifyResult(
                await ApiService.UpdateLocationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateLocations_TestWithOptionsAsync()
        {
            ExpectUpdate<Location>(EndpointName.Locations);

            VerifyResult(
                await ApiService.UpdateLocationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateLocation_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Location>(EndpointName.Locations);

            VerifyResult(
                await ApiService.UpdateLocationAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateLocation_TestWithOptionsAsync()
        {
            ExpectUpdate<Location>(EndpointName.Locations);

            VerifyResult(
                await ApiService.UpdateLocationAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion
    }
}
