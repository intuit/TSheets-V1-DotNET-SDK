// *******************************************************************************
// <copyright file="DataService_RemindersTests.cs" company="Intuit">
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
    public class DataService_RemindersTests : DataServiceTestBase
    {
        private static readonly ReminderFilter DummyFilter = new ReminderFilter
        {
            UserIds = new long[] { 1, 2 }
        };

        private static readonly Reminder DummyEntity = new Reminder();
        private static readonly List<Reminder> DummyEntities = new List<Reminder> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateReminders_TestWithoutOptions()
        {
            ExpectCreate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                ApiService.CreateReminders(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateReminders_TestWithOptions()
        {
            ExpectCreate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                ApiService.CreateReminders(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateReminder_TestWithoutOptions()
        {
            ExpectCreate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                ApiService.CreateReminder(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateReminder_TestWithOptions()
        {
            ExpectCreate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                ApiService.CreateReminder(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateReminders_TestWithoutOptionsAsync()
        {
            ExpectCreate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                await ApiService.CreateRemindersAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateReminders_TestWithOptionsAsync()
        {
            ExpectCreate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                await ApiService.CreateRemindersAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateReminder_TestWithoutOptionsAsync()
        {
            ExpectCreate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                await ApiService.CreateReminderAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateReminder_TestWithOptionsAsync()
        {
            ExpectCreate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                await ApiService.CreateReminderAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetReminders_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<Reminder>(EndpointName.Reminders, Params.Filter);

            VerifyResult(
                ApiService.GetReminders(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetReminders_TestWithFilterAndWithOptions()
        {
            ExpectGet<Reminder>(EndpointName.Reminders, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetReminders(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetReminders_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Reminder>(EndpointName.Reminders, Params.Filter);

            VerifyResult(
                await ApiService.GetRemindersAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetReminders_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<Reminder>(EndpointName.Reminders, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetRemindersAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateReminders_TestWithoutOptions()
        {
            ExpectUpdate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                ApiService.UpdateReminders(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateReminders_TestWithOptions()
        {
            ExpectUpdate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                ApiService.UpdateReminders(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateReminder_TestWithoutOptions()
        {
            ExpectUpdate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                ApiService.UpdateReminder(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateReminder_TestWithOptions()
        {
            ExpectUpdate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                ApiService.UpdateReminder(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateReminders_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                await ApiService.UpdateRemindersAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateReminders_TestWithOptionsAsync()
        {
            ExpectUpdate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                await ApiService.UpdateRemindersAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateReminder_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                await ApiService.UpdateReminderAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateReminder_TestWithOptionsAsync()
        {
            ExpectUpdate<Reminder>(EndpointName.Reminders);

            VerifyResult(
                await ApiService.UpdateReminderAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion
    }
}
