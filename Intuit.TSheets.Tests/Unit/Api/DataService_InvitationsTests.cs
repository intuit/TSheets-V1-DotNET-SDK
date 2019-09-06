// *******************************************************************************
// <copyright file="DataService_InvitationsTests.cs" company="Intuit">
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
    public class DataService_InvitationsTests : DataServiceTestBase
    {
        private static readonly Invitation DummyEntity = new Invitation();
        private static readonly List<Invitation> DummyEntities = new List<Invitation> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateInvitations_TestWithoutOptions()
        {
            ExpectCreate<Invitation>(EndpointName.Invitations);

            VerifyResult(
                ApiService.CreateInvitations(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateInvitations_TestWithOptions()
        {
            ExpectCreate<Invitation>(EndpointName.Invitations);

            VerifyResult(
                ApiService.CreateInvitations(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateInvitation_TestWithoutOptions()
        {
            ExpectCreate<Invitation>(EndpointName.Invitations);

            VerifyResult(
                ApiService.CreateInvitation(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateInvitation_TestWithOptions()
        {
            ExpectCreate<Invitation>(EndpointName.Invitations);

            VerifyResult(
                ApiService.CreateInvitation(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateInvitations_TestWithoutOptionsAsync()
        {
            ExpectCreate<Invitation>(EndpointName.Invitations);

            VerifyResult(
                await ApiService.CreateInvitationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateInvitations_TestWithOptionsAsync()
        {
            ExpectCreate<Invitation>(EndpointName.Invitations);

            VerifyResult(
                await ApiService.CreateInvitationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateInvitation_TestWithoutOptionsAsync()
        {
            ExpectCreate<Invitation>(EndpointName.Invitations);

            VerifyResult(
                await ApiService.CreateInvitationAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateInvitation_TestWithOptionsAsync()
        {
            ExpectCreate<Invitation>(EndpointName.Invitations);

            VerifyResult(
                await ApiService.CreateInvitationAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion
    }
}
