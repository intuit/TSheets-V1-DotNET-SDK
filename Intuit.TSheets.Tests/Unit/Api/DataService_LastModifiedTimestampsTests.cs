// *******************************************************************************
// <copyright file="DataService_LastModifiedTimestampsTests.cs" company="Intuit">
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
    public class DataService_LastModifiedTimestampsTests : DataServiceTestBase
    {
        private static readonly LastModifiedTimestampsFilter DummyFilter = new LastModifiedTimestampsFilter
        {
            Endpoints = Endpoints.Timesheets | Endpoints.Users 
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetLastModifiedTimestamps_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, Params.None);

            VerifyResult(
                ApiService.GetLastModifiedTimestamps());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLastModifiedTimestamps_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, Params.Filter);

            VerifyResult(
                ApiService.GetLastModifiedTimestamps(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLastModifiedTimestamps_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, Params.None);

            VerifyResult(
                ApiService.GetLastModifiedTimestamps());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetLastModifiedTimestamps_TestWithFilterAndWithOptions()
        {
            ExpectGet<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, Params.Filter);

            VerifyResult(
                ApiService.GetLastModifiedTimestamps(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLastModifiedTimestamps_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, Params.None);

            VerifyResult(
                await ApiService.GetLastModifiedTimestampsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetLastModifiedTimestamps_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, Params.Filter);

            VerifyResult(
                await ApiService.GetLastModifiedTimestampsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLastModifiedTimestamps_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, Params.None);

            VerifyResult(
                await ApiService.GetLastModifiedTimestampsAsync().ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetLastModifiedTimestamps_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, Params.Filter);

            VerifyResult(
                await ApiService.GetLastModifiedTimestampsAsync(DummyFilter).ConfigureAwait(false));
        }

        #endregion

    }
}
