// *******************************************************************************
// <copyright file="DataService_NotificationsTests.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_NotificationsTests : DataServiceTestBase
    {
        private static readonly NotificationFilter DummyFilter = new NotificationFilter
        {
            Ids = new long[] { 1, 2}
        };

        private static readonly Notification DummyEntity = new Notification();
        private static readonly List<Notification> DummyEntities = new List<Notification> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateNotifications_TestWithoutOptions()
        {
            ExpectCreate<Notification>(EndpointName.Notifications);

            VerifyResult(
                ApiService.CreateNotifications(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateNotifications_TestWithOptions()
        {
            ExpectCreate<Notification>(EndpointName.Notifications);

            VerifyResult(
                ApiService.CreateNotifications(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateNotification_TestWithoutOptions()
        {
            ExpectCreate<Notification>(EndpointName.Notifications);

            VerifyResult(
                ApiService.CreateNotification(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateNotification_TestWithOptions()
        {
            ExpectCreate<Notification>(EndpointName.Notifications);

            VerifyResult(
                ApiService.CreateNotification(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateNotifications_TestWithoutOptionsAsync()
        {
            ExpectCreate<Notification>(EndpointName.Notifications);

            VerifyResult(
                await ApiService.CreateNotificationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateNotifications_TestWithOptionsAsync()
        {
            ExpectCreate<Notification>(EndpointName.Notifications);

            VerifyResult(
                await ApiService.CreateNotificationsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateNotification_TestWithoutOptionsAsync()
        {
            ExpectCreate<Notification>(EndpointName.Notifications);

            VerifyResult(
                await ApiService.CreateNotificationAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateNotification_TestWithOptionsAsync()
        {
            ExpectCreate<Notification>(EndpointName.Notifications);

            VerifyResult(
                await ApiService.CreateNotificationAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetNotifications_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<Notification>(EndpointName.Notifications, Params.None);

            VerifyResult(
                ApiService.GetNotifications());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetNotifications_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<Notification>(EndpointName.Notifications, Params.Filter);

            VerifyResult(
                ApiService.GetNotifications(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetNotifications_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<Notification>(EndpointName.Notifications, Params.RequestOptions);

            VerifyResult(
                ApiService.GetNotifications(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetNotifications_TestWithFilterAndWithOptions()
        {
            ExpectGet<Notification>(EndpointName.Notifications, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetNotifications(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetNotifications_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Notification>(EndpointName.Notifications, Params.None);

            VerifyResult(
                await ApiService.GetNotificationsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetNotifications_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Notification>(EndpointName.Notifications, Params.Filter);

            VerifyResult(
                await ApiService.GetNotificationsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetNotifications_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<Notification>(EndpointName.Notifications, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetNotificationsAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetNotifications_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<Notification>(EndpointName.Notifications, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetNotificationsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Delete Method Tests

        [TestMethod, TestCategory("Unit")]
        public void DeleteNotification_Test()
        {
            ExpectDelete<Notification>(EndpointName.Notifications);

            ApiService.DeleteNotification(DummyEntity);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteNotifications_Test()
        {
            ExpectDelete<Notification>(EndpointName.Notifications);

            ApiService.DeleteNotifications(DummyEntities);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteNotification_ById_Test()
        {
            ExpectDelete<Notification>(EndpointName.Notifications);

            ApiService.DeleteNotification(1);
        }


        [TestMethod, TestCategory("Unit")]
        public void DeleteNotifications_ById_Test()
        {
            ExpectDelete<Notification>(EndpointName.Notifications);

            ApiService.DeleteNotifications(new long[] { 1, 2 });
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteNotification_TestAsync()
        {
            ExpectDelete<Notification>(EndpointName.Notifications);

            await ApiService.DeleteNotificationAsync(DummyEntity).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteNotifications_TestAsync()
        {
            ExpectDelete<Notification>(EndpointName.Notifications);

            await ApiService.DeleteNotificationsAsync(DummyEntities).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteNotification_ById_TestAsync()
        {
            ExpectDelete<Notification>(EndpointName.Notifications);

            await ApiService.DeleteNotificationAsync(1).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteNotifications_ById_TestAsync()
        {
            ExpectDelete<Notification>(EndpointName.Notifications);

            await ApiService.DeleteNotificationsAsync(new long[] { 1, 2 }).ConfigureAwait(false);
        }

        #endregion
    }
}
