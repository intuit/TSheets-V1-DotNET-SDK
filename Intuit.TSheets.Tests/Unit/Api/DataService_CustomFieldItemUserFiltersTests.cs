// *******************************************************************************
// <copyright file="DataService_CustomFieldItemUserFiltersTests.cs" company="Intuit">
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
    public class DataService_CustomFieldItemUserFiltersTests : DataServiceTestBase
    {
        private static readonly CustomFieldItemUserFilterFilter DummyFilter = new CustomFieldItemUserFilterFilter
        {
            UserId = 1
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemUserFilters_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, Params.None);

            VerifyResult(
                ApiService.GetCustomFieldItemUserFilters());
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemUserFilters_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, Params.Filter);

            VerifyResult(
                ApiService.GetCustomFieldItemUserFilters(DummyFilter));
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemUserFilters_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFieldItemUserFilters(DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemUserFilters_TestWithFilterAndWithOptions()
        {
            ExpectGet<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFieldItemUserFilters(DummyFilter, DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemUserFilters_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, Params.None);

            VerifyResult(
                await ApiService.GetCustomFieldItemUserFiltersAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemUserFilters_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, Params.Filter);

            VerifyResult(
                await ApiService.GetCustomFieldItemUserFiltersAsync(DummyFilter).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemUserFilters_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldItemUserFiltersAsync(DummyRequestOptions).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemUserFilters_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<CustomFieldItemUserFilter>(EndpointName.CustomFieldItemUserFilters, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldItemUserFiltersAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion
    }
}
