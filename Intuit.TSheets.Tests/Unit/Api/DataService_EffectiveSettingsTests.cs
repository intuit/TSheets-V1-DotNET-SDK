// *******************************************************************************
// <copyright file="DataService_EffectiveSettingsTests.cs" company="Intuit">
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
    public class DataService_EffectiveSettingsTests : DataServiceTestBase
    {
        private static readonly EffectiveSettingsFilter DummyFilter = new EffectiveSettingsFilter
        {
            UserId = 1
        };

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetEffectiveSettings_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<EffectiveSettings>(EndpointName.EffectiveSettings, Params.None);

            VerifyResult(
                ApiService.GetEffectiveSettings());
        }


        [TestMethod, TestCategory("Unit")]
        public void GetEffectiveSettings_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<EffectiveSettings>(EndpointName.EffectiveSettings, Params.Filter);

            VerifyResult(
                ApiService.GetEffectiveSettings(DummyFilter));
        }


        [TestMethod, TestCategory("Unit")]
        public void GetEffectiveSettings_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<EffectiveSettings>(EndpointName.EffectiveSettings, Params.None);

            VerifyResult(
                ApiService.GetEffectiveSettings());
        }


        [TestMethod, TestCategory("Unit")]
        public void GetEffectiveSettings_TestWithFilterAndWithOptions()
        {
            ExpectGet<EffectiveSettings>(EndpointName.EffectiveSettings, Params.Filter);

            VerifyResult(
                ApiService.GetEffectiveSettings(DummyFilter));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetEffectiveSettings_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<EffectiveSettings>(EndpointName.EffectiveSettings, Params.None);

            VerifyResult(
                await ApiService.GetEffectiveSettingsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetEffectiveSettings_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<EffectiveSettings>(EndpointName.EffectiveSettings, Params.Filter);

            VerifyResult(
                await ApiService.GetEffectiveSettingsAsync(DummyFilter).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetEffectiveSettings_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<EffectiveSettings>(EndpointName.EffectiveSettings, Params.None);

            VerifyResult(
                await ApiService.GetEffectiveSettingsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetEffectiveSettings_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<EffectiveSettings>(EndpointName.EffectiveSettings, Params.Filter);

            VerifyResult(
                await ApiService.GetEffectiveSettingsAsync(DummyFilter).ConfigureAwait(false));
        }

        #endregion
    }
}
