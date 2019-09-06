// *******************************************************************************
// <copyright file="DataService_CustomFieldsTests.cs" company="Intuit">
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
    public class DataService_CustomFieldsTests : DataServiceTestBase
    {
        private static readonly CustomFieldFilter DummyFilter = new CustomFieldFilter
        {
            Active = TristateChoice.Both
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetCustomFields_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<CustomField>(EndpointName.CustomFields, Params.None);

            VerifyResult(
                ApiService.GetCustomFields());
        }


        [TestMethod, TestCategory("Unit")]
        public void GetCustomFields_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<CustomField>(EndpointName.CustomFields, Params.Filter);

            VerifyResult(
                ApiService.GetCustomFields(DummyFilter));
        }


        [TestMethod, TestCategory("Unit")]
        public void GetCustomFields_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<CustomField>(EndpointName.CustomFields, Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFields(DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public void GetCustomFields_TestWithFilterAndWithOptions()
        {
            ExpectGet<CustomField>(EndpointName.CustomFields, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFields(DummyFilter, DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetCustomFields_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<CustomField>(EndpointName.CustomFields, Params.None);

            VerifyResult(
                await ApiService.GetCustomFieldsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetCustomFields_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<CustomField>(EndpointName.CustomFields, Params.Filter);

            VerifyResult(
                await ApiService.GetCustomFieldsAsync(DummyFilter).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetCustomFields_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<CustomField>(EndpointName.CustomFields, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldsAsync(DummyRequestOptions).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetCustomFields_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<CustomField>(EndpointName.CustomFields, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion
    }
}
