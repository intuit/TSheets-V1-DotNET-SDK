// *******************************************************************************
// <copyright file="DataService_UsersTests.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Enums;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_UsersTests : DataServiceTestBase
    {
        private static readonly UserFilter DummyFilter = new UserFilter
        {
            Active = TristateChoice.Both
        };

        private static readonly User DummyEntity = new User();
        private static readonly List<User> DummyEntities = new List<User> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateUsers_TestWithoutOptions()
        {
            ExpectCreate<User>(EndpointName.Users);

            VerifyResult(
                ApiService.CreateUsers(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateUsers_TestWithOptions()
        {
            ExpectCreate<User>(EndpointName.Users);

            VerifyResult(
                ApiService.CreateUsers(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateUser_TestWithoutOptions()
        {
            ExpectCreate<User>(EndpointName.Users);

            VerifyResult(
                ApiService.CreateUser(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateUser_TestWithOptions()
        {
            ExpectCreate<User>(EndpointName.Users);

            VerifyResult(
                ApiService.CreateUser(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateUsers_TestWithoutOptionsAsync()
        {
            ExpectCreate<User>(EndpointName.Users);

            VerifyResult(
                await ApiService.CreateUsersAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateUsers_TestWithOptionsAsync()
        {
            ExpectCreate<User>(EndpointName.Users);

            VerifyResult(
                await ApiService.CreateUsersAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateUser_TestWithoutOptionsAsync()
        {
            ExpectCreate<User>(EndpointName.Users);

            VerifyResult(
                await ApiService.CreateUserAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateUser_TestWithOptionsAsync()
        {
            ExpectCreate<User>(EndpointName.Users);

            VerifyResult(
                await ApiService.CreateUserAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetUsers_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<User>(EndpointName.Users, Params.None);

            VerifyResult(
                ApiService.GetUsers());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetUsers_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<User>(EndpointName.Users, Params.Filter);

            VerifyResult(
                ApiService.GetUsers(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetUsers_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<User>(EndpointName.Users, Params.RequestOptions);

            VerifyResult(
                ApiService.GetUsers(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetUsers_TestWithFilterAndWithOptions()
        {
            ExpectGet<User>(EndpointName.Users, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetUsers(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetUsers_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<User>(EndpointName.Users, Params.None);

            VerifyResult(
                await ApiService.GetUsersAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetUsers_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<User>(EndpointName.Users, Params.Filter);

            VerifyResult(
                await ApiService.GetUsersAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetUsers_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<User>(EndpointName.Users, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetUsersAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetUsers_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<User>(EndpointName.Users, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetUsersAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateUsers_TestWithoutOptions()
        {
            ExpectUpdate<User>(EndpointName.Users);

            VerifyResult(
                ApiService.UpdateUsers(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateUsers_TestWithOptions()
        {
            ExpectUpdate<User>(EndpointName.Users);

            VerifyResult(
                ApiService.UpdateUsers(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateUser_TestWithoutOptions()
        {
            ExpectUpdate<User>(EndpointName.Users);

            VerifyResult(
                ApiService.UpdateUser(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateUser_TestWithOptions()
        {
            ExpectUpdate<User>(EndpointName.Users);

            VerifyResult(
                ApiService.UpdateUser(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateUsers_TestWithoutOptionsAsync()
        {
            ExpectUpdate<User>(EndpointName.Users);

            VerifyResult(
                await ApiService.UpdateUsersAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateUsers_TestWithOptionsAsync()
        {
            ExpectUpdate<User>(EndpointName.Users);

            VerifyResult(
                await ApiService.UpdateUsersAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateUser_TestWithoutOptionsAsync()
        {
            ExpectUpdate<User>(EndpointName.Users);

            VerifyResult(
                await ApiService.UpdateUserAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateUser_TestWithOptionsAsync()
        {
            ExpectUpdate<User>(EndpointName.Users);

            VerifyResult(
                await ApiService.UpdateUserAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion
    }
}
