﻿// *******************************************************************************
// <copyright file="DataService_Reminders.cs" company="Intuit">
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

namespace Intuit.TSheets.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    /// <remarks>
    /// This file contains operations specific to the Reminders endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Reminders.
        /// </summary>
        /// <remarks>
        /// Add a single user-specific or company-wide reminder.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Reminder, ResultsMeta) CreateReminder(Reminder reminder)
        {
            (IList<Reminder> reminders, ResultsMeta resultsMeta) = CreateReminders(new[] { reminder });

            return (reminders.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Reminders.
        /// </summary>
        /// <remarks>
        /// Add one or more user-specific or company-wide reminders.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Reminder>, ResultsMeta) CreateReminders(IEnumerable<Reminder> reminders)
        {
            return AsyncUtil.RunSync(() => CreateRemindersAsync(reminders));
        }

        /// <summary>
        /// Asynchronously Create Reminders.
        /// </summary>
        /// <remarks>
        /// Add a single user-specific or company-wide reminder.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Reminder, ResultsMeta)> CreateReminderAsync(
            Reminder reminder)
        {
            (IList<Reminder> reminders, ResultsMeta resultsMeta) = await CreateRemindersAsync(new[] { reminder }, default).ConfigureAwait(false);

            return (reminders.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Reminders, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single user-specific or company-wide reminder.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Reminder, ResultsMeta)> CreateReminderAsync(
            Reminder reminder,
            CancellationToken cancellationToken)
        {
            (IList<Reminder> reminders, ResultsMeta resultsMeta) = await CreateRemindersAsync(new[] { reminder }, cancellationToken).ConfigureAwait(false);

            return (reminders.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Reminders.
        /// </summary>
        /// <remarks>
        /// Add one or more user-specific or company-wide reminders.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Reminder>, ResultsMeta)> CreateRemindersAsync(
            IEnumerable<Reminder> reminders)
        {
            return await CreateRemindersAsync(reminders, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Reminders, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more user-specific or company-wide reminders.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Reminder>, ResultsMeta)> CreateRemindersAsync(
            IEnumerable<Reminder> reminders,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<Reminder>(EndpointName.Reminders, reminders);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Reminders.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all reminders associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ReminderFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Reminder"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Reminder>, ResultsMeta) GetReminders(
            ReminderFilter filter)
        {
            return AsyncUtil.RunSync(() => GetRemindersAsync(filter));
        }

        /// <summary>
        /// Retrieve Reminders.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all reminders associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ReminderFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Reminder"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Reminder>, ResultsMeta) GetReminders(
            ReminderFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetRemindersAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Reminders.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all reminders associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ReminderFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Reminder"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Reminder>, ResultsMeta)> GetRemindersAsync(
            ReminderFilter filter)
        {
            return await GetRemindersAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Reminders, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all reminders associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ReminderFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Reminder"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Reminder>, ResultsMeta)> GetRemindersAsync(
            ReminderFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetRemindersAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Reminders.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all reminders associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ReminderFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Reminder"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Reminder>, ResultsMeta)> GetRemindersAsync(
            ReminderFilter filter,
            RequestOptions options)
        {
            return await GetRemindersAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Reminders, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all reminders associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ReminderFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Reminder"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Reminder>, ResultsMeta)> GetRemindersAsync(
            ReminderFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<Reminder>(EndpointName.Reminders, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update Reminders.
        /// </summary>
        /// <remarks>
        /// Edit a single reminder for employees within your company.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Reminder, ResultsMeta) UpdateReminder(Reminder reminder)
        {
            (IList<Reminder> reminders, ResultsMeta resultsMeta) =
                UpdateReminders(new[] { reminder });

            return (reminders.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Reminders.
        /// </summary>
        /// <remarks>
        /// Edit one or more reminders for employees within your company.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Reminder>, ResultsMeta) UpdateReminders(IEnumerable<Reminder> reminders)
        {
            return AsyncUtil.RunSync(() => UpdateRemindersAsync(reminders));
        }

        /// <summary>
        /// Asynchronously Update Reminders.
        /// </summary>
        /// <remarks>
        /// Edit a single reminder for employees within your company.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Reminder, ResultsMeta)> UpdateReminderAsync(
            Reminder reminder)
        {
            (IList<Reminder> reminders, ResultsMeta resultsMeta) =
                await UpdateRemindersAsync(new[] { reminder }, default).ConfigureAwait(false);

            return (reminders.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Reminders, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit a single reminder for employees within your company.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Reminder, ResultsMeta)> UpdateReminderAsync(
            Reminder reminder,
            CancellationToken cancellationToken)
        {
            (IList<Reminder> reminders, ResultsMeta resultsMeta) =
                await UpdateRemindersAsync(new[] { reminder }, cancellationToken).ConfigureAwait(false);

            return (reminders.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Reminders.
        /// </summary>
        /// <remarks>
        /// Edit one or more reminders for employees within your company.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Reminder>, ResultsMeta)> UpdateRemindersAsync(
            IEnumerable<Reminder> reminders)
        {
            return await UpdateRemindersAsync(reminders, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update Reminders, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit one or more reminders for employees within your company.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Reminder>, ResultsMeta)> UpdateRemindersAsync(
            IEnumerable<Reminder> reminders,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<Reminder>(EndpointName.Reminders, reminders);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
