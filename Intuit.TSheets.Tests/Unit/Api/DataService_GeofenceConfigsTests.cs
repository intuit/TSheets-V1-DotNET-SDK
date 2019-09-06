// *******************************************************************************
// <copyright file="DataService_GeofenceConfigsTests.cs" company="Intuit">
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
    public class DataService_GeofenceConfigsTests : DataServiceTestBase
    {
        private static readonly GeofenceConfigFilter DummyFilter = new GeofenceConfigFilter
        {
            Active = TristateChoice.Both
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetGeofenceConfigs_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<GeofenceConfig>(EndpointName.GeofenceConfigs, Params.None);

            VerifyResult(
                ApiService.GetGeofenceConfigs());
        }


        [TestMethod, TestCategory("Unit")]
        public void GetGeofenceConfigs_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<GeofenceConfig>(EndpointName.GeofenceConfigs, Params.Filter);

            VerifyResult(
                ApiService.GetGeofenceConfigs(DummyFilter));
        }


        [TestMethod, TestCategory("Unit")]
        public void GetGeofenceConfigs_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<GeofenceConfig>(EndpointName.GeofenceConfigs, Params.RequestOptions);

            VerifyResult(
                ApiService.GetGeofenceConfigs(DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public void GetGeofenceConfigs_TestWithFilterAndWithOptions()
        {
            ExpectGet<GeofenceConfig>(EndpointName.GeofenceConfigs, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetGeofenceConfigs(DummyFilter, DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetGeofenceConfigs_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<GeofenceConfig>(EndpointName.GeofenceConfigs, Params.None);

            VerifyResult(
                await ApiService.GetGeofenceConfigsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetGeofenceConfigs_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<GeofenceConfig>(EndpointName.GeofenceConfigs, Params.Filter);

            VerifyResult(
                await ApiService.GetGeofenceConfigsAsync(DummyFilter).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetGeofenceConfigs_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<GeofenceConfig>(EndpointName.GeofenceConfigs, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetGeofenceConfigsAsync(DummyRequestOptions).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetGeofenceConfigs_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<GeofenceConfig>(EndpointName.GeofenceConfigs, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetGeofenceConfigsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

    }
}
