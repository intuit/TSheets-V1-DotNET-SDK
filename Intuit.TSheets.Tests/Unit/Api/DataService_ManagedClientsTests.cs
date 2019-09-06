// *******************************************************************************
// <copyright file="DataService_ManagedClientsTests.cs" company="Intuit">
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
    public class DataService_ManagedClientsTests : DataServiceTestBase
    {
        private static readonly ManagedClientFilter DummyFilter = new ManagedClientFilter
        {
            Active = TristateChoice.Both
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetManagedClients_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<ManagedClient>(EndpointName.ManagedClients, Params.None);

            VerifyResult(
                ApiService.GetManagedClients());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetManagedClients_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<ManagedClient>(EndpointName.ManagedClients, Params.Filter);

            VerifyResult(
                ApiService.GetManagedClients(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetManagedClients_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<ManagedClient>(EndpointName.ManagedClients, Params.RequestOptions);

            VerifyResult(
                ApiService.GetManagedClients(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetManagedClients_TestWithFilterAndWithOptions()
        {
            ExpectGet<ManagedClient>(EndpointName.ManagedClients, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetManagedClients(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetManagedClients_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<ManagedClient>(EndpointName.ManagedClients, Params.None);

            VerifyResult(
                await ApiService.GetManagedClientsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetManagedClients_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<ManagedClient>(EndpointName.ManagedClients, Params.Filter);

            VerifyResult(
                await ApiService.GetManagedClientsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetManagedClients_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<ManagedClient>(EndpointName.ManagedClients, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetManagedClientsAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetManagedClients_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<ManagedClient>(EndpointName.ManagedClients, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetManagedClientsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

    }
}
