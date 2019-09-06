// *******************************************************************************
// <copyright file="DataService_CustomFieldItemsTests.cs" company="Intuit">
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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_CustomFieldItemsTests : DataServiceTestBase
    {
        private static readonly TSheets.Model.Filters.CustomFieldItemFilter DummyFilter
            = new TSheets.Model.Filters.CustomFieldItemFilter { CustomFieldId = 1 };

        private static readonly CustomFieldItem DummyEntity = new CustomFieldItem();
        private static readonly List<CustomFieldItem> DummyEntities = new List<CustomFieldItem>{DummyEntity};

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateCustomFieldItems_TestWithoutOptions()
        {
            ExpectCreate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                ApiService.CreateCustomFieldItems(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateCustomFieldItems_TestWithOptions()
        {
            ExpectCreate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                ApiService.CreateCustomFieldItems(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateCustomFieldItem_TestWithoutOptions()
        {
            ExpectCreate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                ApiService.CreateCustomFieldItem(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateCustomFieldItem_TestWithOptions()
        {
            ExpectCreate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                ApiService.CreateCustomFieldItem(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateCustomFieldItems_TestWithoutOptionsAsync()
        {
            ExpectCreate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                await ApiService.CreateCustomFieldItemsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateCustomFieldItems_TestWithOptionsAsync()
        {
            ExpectCreate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                await ApiService.CreateCustomFieldItemsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateCustomFieldItem_TestWithoutOptionsAsync()
        {
            ExpectCreate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                await ApiService.CreateCustomFieldItemAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateCustomFieldItem_TestWithOptionsAsync()
        {
            ExpectCreate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                await ApiService.CreateCustomFieldItemAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetCustomFieldItems_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<CustomFieldItem>(EndpointName.CustomFieldItems, Params.Filter);

            VerifyResult(
                ApiService.GetCustomFieldItems(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetCustomFieldItems_TestWithFilterAndWithOptions()
        {
            ExpectGet<CustomFieldItem>(EndpointName.CustomFieldItems, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetCustomFieldItems(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetCustomFieldItems_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<CustomFieldItem>(EndpointName.CustomFieldItems, Params.Filter);

            VerifyResult(
                await ApiService.GetCustomFieldItemsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetCustomFieldItems_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<CustomFieldItem>(EndpointName.CustomFieldItems, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCustomFieldItemsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateCustomFieldItems_TestWithoutOptions()
        {
            ExpectUpdate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                ApiService.UpdateCustomFieldItems(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateCustomFieldItems_TestWithOptions()
        {
            ExpectUpdate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                ApiService.UpdateCustomFieldItems(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateCustomFieldItem_TestWithoutOptions()
        {
            ExpectUpdate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                ApiService.UpdateCustomFieldItem(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateCustomFieldItem_TestWithOptions()
        {
            ExpectUpdate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                ApiService.UpdateCustomFieldItem(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateCustomFieldItems_TestWithoutOptionsAsync()
        {
            ExpectUpdate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                await ApiService.UpdateCustomFieldItemsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateCustomFieldItems_TestWithOptionsAsync()
        {
            ExpectUpdate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                await ApiService.UpdateCustomFieldItemsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateCustomFieldItem_TestWithoutOptionsAsync()
        {
            ExpectUpdate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                await ApiService.UpdateCustomFieldItemAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateCustomFieldItem_TestWithOptionsAsync()
        {
            ExpectUpdate<CustomFieldItem>(EndpointName.CustomFieldItems);

            VerifyResult(
                await ApiService.UpdateCustomFieldItemAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion
    }
}
