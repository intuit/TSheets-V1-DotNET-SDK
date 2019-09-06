// *******************************************************************************
// <copyright file="DataService_CustomFieldItemJobcodeFiltersTests.cs" company="Intuit">
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
    public class DataService_CustomFieldItemJobcodeFiltersTests : DataServiceTestBase
    {
        private static readonly CustomFieldItemJobcodeFilterFilter DummyFilter = new CustomFieldItemJobcodeFilterFilter
        {
            JobcodeId = 1
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemJobcodeFilters_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, Params.None);

            VerifyResult(
                ApiService.GetCustomFieldItemJobcodeFilters());
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemJobcodeFilters_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, Params.Filter);

            VerifyResult(
                ApiService.GetCustomFieldItemJobcodeFilters(DummyFilter));
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemJobcodeFilters_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFieldItemJobcodeFilters(DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemJobcodeFilters_TestWithFilterAndWithOptions()
        {
            ExpectGet<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFieldItemJobcodeFilters(DummyFilter, DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemJobcodeFilters_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, Params.None);

            VerifyResult(
                await ApiService.GetCustomFieldItemJobcodeFiltersAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemJobcodeFilters_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, Params.Filter);

            VerifyResult(
                await ApiService.GetCustomFieldItemJobcodeFiltersAsync(DummyFilter).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemJobcodeFilters_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldItemJobcodeFiltersAsync(DummyRequestOptions).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemJobcodeFilters_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<CustomFieldItemJobcodeFilter>(EndpointName.CustomFieldItemJobcodeFilters, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldItemJobcodeFiltersAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion
    }
}
