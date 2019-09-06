// *******************************************************************************
// <copyright file="DataService_CurrentUserTests.cs" company="Intuit">
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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_CurrentUserTests : DataServiceTestBase
    {
        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetCurrentUser_TestWithoutOptions()
        {
            ExpectGet<User>(EndpointName.CurrentUser, Params.None);

            VerifyResult(
                ApiService.GetCurrentUser());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetCurrentUser_TestWithOptions()
        {
            ExpectGet<User>(EndpointName.CurrentUser, Params.RequestOptions);

            VerifyResult(
                ApiService.GetCurrentUser(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetCurrentUser_TestWithoutOptionsAsync()
        {
            ExpectGet<User>(EndpointName.CurrentUser, Params.None);

            VerifyResult(
                await ApiService.GetCurrentUserAsync().ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetCurrentUser_TestWithOptionsAsync()
        {
            ExpectGet<User>(EndpointName.CurrentUser, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetCurrentUserAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion
    }
}
