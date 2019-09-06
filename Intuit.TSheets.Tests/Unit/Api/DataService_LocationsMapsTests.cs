// *******************************************************************************
// <copyright file="DataService_LocationsMapsTests.cs" company="Intuit">
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
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Enums;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_LocationsMapsTests : DataServiceTestBase
    {
        private static readonly LocationsMapFilter DummyFilter = new LocationsMapFilter
        {
            Active = TristateChoice.Both
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetLocationsMaps_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<LocationsMap>(EndpointName.LocationsMaps, Params.None);

            VerifyResult(
                ApiService.GetLocationsMaps());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLocationsMaps_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<LocationsMap>(EndpointName.LocationsMaps, Params.Filter);

            VerifyResult(
                ApiService.GetLocationsMaps(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLocationsMaps_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<LocationsMap>(EndpointName.LocationsMaps, Params.RequestOptions);

            VerifyResult(
                ApiService.GetLocationsMaps(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLocationsMaps_TestWithFilterAndWithOptions()
        {
            ExpectGet<LocationsMap>(EndpointName.LocationsMaps, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetLocationsMaps(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLocationsMaps_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<LocationsMap>(EndpointName.LocationsMaps, Params.None);

            VerifyResult(
                await ApiService.GetLocationsMapsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetLocationsMaps_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<LocationsMap>(EndpointName.LocationsMaps, Params.Filter);

            VerifyResult(
                await ApiService.GetLocationsMapsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLocationsMaps_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<LocationsMap>(EndpointName.LocationsMaps, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetLocationsMapsAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLocationsMaps_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<LocationsMap>(EndpointName.LocationsMaps, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetLocationsMapsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion
    }
}
