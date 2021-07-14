// *******************************************************************************
// <copyright file="DataService_TimesheetsDeletedTests.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_TimesheetsDeletedTests : DataServiceTestBase
    {
        private static readonly TimesheetsDeletedFilter DummyFilter = new TimesheetsDeletedFilter
        {
            Ids = new long[] { 1, 2 }
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetTimesheetsDeleted_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<TimesheetsDeleted>(EndpointName.TimesheetsDeleted, Params.Filter);

            VerifyResult(
                ApiService.GetTimesheetsDeleted(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetTimesheetsDeleted_TestWithFilterAndWithOptions()
        {
            ExpectGet<TimesheetsDeleted>(EndpointName.TimesheetsDeleted, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetTimesheetsDeleted(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetTimesheetsDeleted_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<TimesheetsDeleted>(EndpointName.TimesheetsDeleted, Params.Filter);

            VerifyResult(
                await ApiService.GetTimesheetsDeletedAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetTimesheetsDeleted_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<TimesheetsDeleted>(EndpointName.TimesheetsDeleted, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetTimesheetsDeletedAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

    }
}
