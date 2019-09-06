// *******************************************************************************
// <copyright file="DataService_CustomFieldItemFiltersTests.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Enums;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_CustomFieldItemFiltersTests : DataServiceTestBase
    {
        private static readonly CustomFieldItemFilterFilter DummyFilter = new CustomFieldItemFilterFilter
        {
            Active = TristateChoice.Both
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemFilters_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<TSheets.Model.CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, Params.None);

            VerifyResult(
                ApiService.GetCustomFieldItemFilters());
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemFilters_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<TSheets.Model.CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, Params.Filter);

            VerifyResult(
                ApiService.GetCustomFieldItemFilters(DummyFilter));
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemFilters_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<TSheets.Model.CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFieldItemFilters(DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public void CustomFieldItemFilters_TestWithFilterAndWithOptions()
        {
            ExpectGet<TSheets.Model.CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFieldItemFilters(DummyFilter, DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemFilters_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<TSheets.Model.CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, Params.None);

            VerifyResult(
                await ApiService.GetCustomFieldItemFiltersAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemFilters_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<TSheets.Model.CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, Params.Filter);

            VerifyResult(
                await ApiService.GetCustomFieldItemFiltersAsync(DummyFilter).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemFilters_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<TSheets.Model.CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldItemFiltersAsync(DummyRequestOptions).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task CustomFieldItemFilters_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<TSheets.Model.CustomFieldItemFilter>(EndpointName.CustomFieldItemFilters, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldItemFiltersAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion
    }
}
