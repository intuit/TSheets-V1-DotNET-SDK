// *******************************************************************************
// <copyright file="DataService_GroupsTests.cs" company="Intuit">
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
    public class DataService_GroupsTests : DataServiceTestBase
    {
        private static readonly GroupFilter DummyFilter = new GroupFilter
        {
            Active = TristateChoice.Both
        };

        private static readonly Group DummyEntity = new Group();
        private static readonly List<Group> DummyEntities = new List<Group> { DummyEntity, DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateGroups_TestWithoutOptions()
        {
            ExpectCreate<Group>(EndpointName.Groups);

            VerifyResult(
                ApiService.CreateGroups(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateGroups_TestWithOptions()
        {
            ExpectCreate<Group>(EndpointName.Groups);

            VerifyResult(
                ApiService.CreateGroups(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateGroup_TestWithoutOptions()
        {
            ExpectCreate<Group>(EndpointName.Groups);

            VerifyResult(
                ApiService.CreateGroup(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateGroup_TestWithOptions()
        {
            ExpectCreate<Group>(EndpointName.Groups);

            VerifyResult(
                ApiService.CreateGroup(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateGroups_TestWithoutOptionsAsync()
        {
            ExpectCreate<Group>(EndpointName.Groups);

            VerifyResult(
                await ApiService.CreateGroupsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateGroups_TestWithOptionsAsync()
        {
            ExpectCreate<Group>(EndpointName.Groups);

            VerifyResult(
                await ApiService.CreateGroupsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateGroup_TestWithoutOptionsAsync()
        {
            ExpectCreate<Group>(EndpointName.Groups);

            VerifyResult(
                await ApiService.CreateGroupAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateGroup_TestWithOptionsAsync()
        {
            ExpectCreate<Group>(EndpointName.Groups);

            VerifyResult(
                await ApiService.CreateGroupAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetGroups_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<Group>(EndpointName.Groups, Params.None);

            VerifyResult(
                ApiService.GetGroups());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetGroups_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<Group>(EndpointName.Groups, Params.Filter);

            VerifyResult(
                ApiService.GetGroups(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetGroups_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<Group>(EndpointName.Groups, Params.RequestOptions);

            VerifyResult(
                ApiService.GetGroups(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetGroups_TestWithFilterAndWithOptions()
        {
            ExpectGet<Group>(EndpointName.Groups, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetGroups(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetGroups_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Group>(EndpointName.Groups, Params.None);

            VerifyResult(
                await ApiService.GetGroupsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetGroups_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Group>(EndpointName.Groups, Params.Filter);

            VerifyResult(
                await ApiService.GetGroupsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetGroups_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<Group>(EndpointName.Groups, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetGroupsAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetGroups_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<Group>(EndpointName.Groups, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetGroupsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateGroups_TestWithoutOptions()
        {
            ExpectUpdate<Group>(EndpointName.Groups);

            VerifyResult(
                ApiService.UpdateGroups(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateGroups_TestWithOptions()
        {
            ExpectUpdate<Group>(EndpointName.Groups);

            VerifyResult(
                ApiService.UpdateGroups(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateGroup_TestWithoutOptions()
        {
            ExpectUpdate<Group>(EndpointName.Groups);

            VerifyResult(
                ApiService.UpdateGroup(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateGroup_TestWithOptions()
        {
            ExpectUpdate<Group>(EndpointName.Groups);

            VerifyResult(
                ApiService.UpdateGroup(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateGroups_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Group>(EndpointName.Groups);

            VerifyResult(
                await ApiService.UpdateGroupsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateGroups_TestWithOptionsAsync()
        {
            ExpectUpdate<Group>(EndpointName.Groups);

            VerifyResult(
                await ApiService.UpdateGroupsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateGroup_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Group>(EndpointName.Groups);

            VerifyResult(
                await ApiService.UpdateGroupAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateGroup_TestWithOptionsAsync()
        {
            ExpectUpdate<Group>(EndpointName.Groups);

            VerifyResult(
                await ApiService.UpdateGroupAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion
    }
}
