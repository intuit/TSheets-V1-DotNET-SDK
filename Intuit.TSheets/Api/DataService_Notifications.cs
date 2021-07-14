// *******************************************************************************
// <copyright file="DataService_Notifications.cs" company="Intuit">
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
    /// This file contains operations specific to the Notifications endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Notifications.
        /// </summary>
        /// <remarks>
        /// Add a single notification.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Notification"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Notification, ResultsMeta) CreateNotification(Notification notification)
        {
            (IList<Notification> notifications, ResultsMeta resultsMeta) = CreateNotifications(new[] { notification });

            return (notifications.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Notifications.
        /// </summary>
        /// <remarks>
        /// Add one or more notifications.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Notification"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Notification>, ResultsMeta) CreateNotifications(IEnumerable<Notification> notifications)
        {
            return AsyncUtil.RunSync(() => CreateNotificationsAsync(notifications));
        }

        /// <summary>
        /// Asynchronously Create Notifications.
        /// </summary>
        /// <remarks>
        /// Add a single notification.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Notification"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Notification, ResultsMeta)> CreateNotificationAsync(
            Notification notification)
        {
            (IList<Notification> notifications, ResultsMeta resultsMeta) = await CreateNotificationsAsync(new[] { notification }, default).ConfigureAwait(false);

            return (notifications.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single notification.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Notification"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Notification, ResultsMeta)> CreateNotificationAsync(
            Notification notification,
            CancellationToken cancellationToken)
        {
            (IList<Notification> notifications, ResultsMeta resultsMeta) = await CreateNotificationsAsync(new[] { notification }, cancellationToken).ConfigureAwait(false);

            return (notifications.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Notifications.
        /// </summary>
        /// <remarks>
        /// Add one or more notifications.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Notification"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Notification>, ResultsMeta)> CreateNotificationsAsync(
            IEnumerable<Notification> notifications)
        {
            return await CreateNotificationsAsync(notifications, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more notifications.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Notification"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Notification>, ResultsMeta)> CreateNotificationsAsync(
            IEnumerable<Notification> notifications,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<Notification>(EndpointName.Notifications, notifications);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Notification>, ResultsMeta) GetNotifications()
        {
            return AsyncUtil.RunSync(() => GetNotificationsAsync());
        }

        /// <summary>
        /// Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Notification>, ResultsMeta) GetNotifications(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetNotificationsAsync(options));
        }

        /// <summary>
        /// Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="NotificationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Notification>, ResultsMeta) GetNotifications(
            NotificationFilter filter)
        {
            return AsyncUtil.RunSync(() => GetNotificationsAsync(filter));
        }

        /// <summary>
        /// Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="NotificationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Notification>, ResultsMeta) GetNotifications(
            NotificationFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetNotificationsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync()
        {
            return await GetNotificationsAsync(null, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(
            CancellationToken cancellationToken)
        {
            return await GetNotificationsAsync(null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(
            RequestOptions options)
        {
            return await GetNotificationsAsync(null, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            return await GetNotificationsAsync(null, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="NotificationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(
            NotificationFilter filter)
        {
            return await GetNotificationsAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="NotificationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(
            NotificationFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetNotificationsAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="NotificationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(
            NotificationFilter filter,
            RequestOptions options)
        {
            return await GetNotificationsAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="NotificationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(
            NotificationFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<Notification>(EndpointName.Notifications, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be deleted.
        /// </param>
        public void DeleteNotification(Notification notification)
        {
            AsyncUtil.RunSync(() => DeleteNotificationAsync(notification));
        }

        /// <summary>
        /// Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Notification"/> object to be deleted.
        /// </param>
        public void DeleteNotification(long id)
        {
            AsyncUtil.RunSync(() => DeleteNotificationAsync(id));
        }

        /// <summary>
        /// Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be deleted.
        /// </param>
        public void DeleteNotifications(IEnumerable<Notification> notifications)
        {
            AsyncUtil.RunSync(() => DeleteNotificationsAsync(notifications));
        }

        /// <summary>
        /// Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Notification"/> objects to be deleted.
        /// </param>
        public void DeleteNotifications(IEnumerable<long> ids)
        {
            AsyncUtil.RunSync(() => DeleteNotificationsAsync(ids));
        }

        /// <summary>
        /// Asynchronously Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteNotificationAsync(
            Notification notification)
        {
            await DeleteNotificationsAsync(new[] { notification.Id }, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteNotificationAsync(
            Notification notification,
            CancellationToken cancellationToken)
        {
            await DeleteNotificationsAsync(new[] { notification.Id }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Notification"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteNotificationAsync(
            long id)
        {
            await DeleteNotificationsAsync(new[] { id }, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Notification"/> object to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteNotificationAsync(
            long id,
            CancellationToken cancellationToken)
        {
            await DeleteNotificationsAsync(new[] { id }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteNotificationsAsync(
            IEnumerable<Notification> notifications)
        {
            IEnumerable<long> ids = notifications.Select(t => t.Id);

            await DeleteNotificationsAsync(ids, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteNotificationsAsync(
            IEnumerable<Notification> notifications,
            CancellationToken cancellationToken)
        {
            IEnumerable<long> ids = notifications.Select(t => t.Id);

            await DeleteNotificationsAsync(ids, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Notification"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteNotificationsAsync(
            IEnumerable<long> ids)
        {
            await DeleteNotificationsAsync(ids, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Notifications, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Notification"/> objects to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteNotificationsAsync(
            IEnumerable<long> ids,
            CancellationToken cancellationToken)
        {
            var context = new DeleteContext<Notification>(EndpointName.Notifications, ids);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
