// *******************************************************************************
// <copyright file="DataService_ScheduleEvents.cs" company="Intuit">
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
    /// This file contains operations specific to the ScheduleEvents endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Add a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (ScheduleEvent, ResultsMeta) CreateScheduleEvent(ScheduleEvent scheduleEvent)
        {
            (IList<ScheduleEvent> scheduleEvents, ResultsMeta resultsMeta) = CreateScheduleEvents(new[] { scheduleEvent });

            return (scheduleEvents.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Schedule Events.
        /// </summary>
        /// <remarks>
        /// Add one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<ScheduleEvent>, ResultsMeta) CreateScheduleEvents(IEnumerable<ScheduleEvent> scheduleEvents)
        {
            return AsyncUtil.RunSync(() => CreateScheduleEventsAsync(scheduleEvents));
        }

        /// <summary>
        /// Asynchronously Create ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Add a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(ScheduleEvent, ResultsMeta)> CreateScheduleEventAsync(
            ScheduleEvent scheduleEvent)
        {
            (IList<ScheduleEvent> scheduleEvents, ResultsMeta resultsMeta) = await CreateScheduleEventsAsync(new[] { scheduleEvent }, default).ConfigureAwait(false);

            return (scheduleEvents.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create ScheduleEvents, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(ScheduleEvent, ResultsMeta)> CreateScheduleEventAsync(
            ScheduleEvent scheduleEvent,
            CancellationToken cancellationToken)
        {
            (IList<ScheduleEvent> scheduleEvents, ResultsMeta resultsMeta) = await CreateScheduleEventsAsync(new[] { scheduleEvent }, cancellationToken).ConfigureAwait(false);

            return (scheduleEvents.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Schedule Events.
        /// </summary>
        /// <remarks>
        /// Add one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<ScheduleEvent>, ResultsMeta)> CreateScheduleEventsAsync(
            IEnumerable<ScheduleEvent> scheduleEvents)
        {
            return await CreateScheduleEventsAsync(scheduleEvents, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Schedule Events.
        /// </summary>
        /// <remarks>
        /// Add one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<ScheduleEvent>, ResultsMeta)> CreateScheduleEventsAsync(
            IEnumerable<ScheduleEvent> scheduleEvents,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<ScheduleEvent>(EndpointName.ScheduleEvents, scheduleEvents);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Schedule Events.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule events associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleEventFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleEvent"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ScheduleEvent>, ResultsMeta) GetScheduleEvents(
            ScheduleEventFilter filter)
        {
            return AsyncUtil.RunSync(() => GetScheduleEventsAsync(filter));
        }

        /// <summary>
        /// Retrieve Schedule Events.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule events associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleEventFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleEvent"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ScheduleEvent>, ResultsMeta) GetScheduleEvents(
            ScheduleEventFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetScheduleEventsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Schedule Events.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule events associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleEventFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleEvent"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ScheduleEvent>, ResultsMeta)> GetScheduleEventsAsync(
            ScheduleEventFilter filter)
        {
            return await GetScheduleEventsAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Schedule Events, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule events associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleEventFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleEvent"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ScheduleEvent>, ResultsMeta)> GetScheduleEventsAsync(
            ScheduleEventFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetScheduleEventsAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Schedule Events.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule events associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleEventFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleEvent"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ScheduleEvent>, ResultsMeta)> GetScheduleEventsAsync(
            ScheduleEventFilter filter,
            RequestOptions options)
        {
            return await GetScheduleEventsAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Schedule Events, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule events associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleEventFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleEvent"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ScheduleEvent>, ResultsMeta)> GetScheduleEventsAsync(
            ScheduleEventFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<ScheduleEvent>(EndpointName.ScheduleEvents, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Edit a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (ScheduleEvent, ResultsMeta) UpdateScheduleEvent(
            ScheduleEvent scheduleEvent)
        {
            (IList<ScheduleEvent> scheduleEvents, ResultsMeta resultsMeta) =
                UpdateScheduleEvents(new[] { scheduleEvent });

            return (scheduleEvents.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Schedule Events.
        /// </summary>
        /// <remarks>
        /// Edit one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<ScheduleEvent>, ResultsMeta) UpdateScheduleEvents(IEnumerable<ScheduleEvent> scheduleEvents)
        {
            return AsyncUtil.RunSync(() => UpdateScheduleEventsAsync(scheduleEvents));
        }

        /// <summary>
        /// Asynchronously Update ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Edit a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(ScheduleEvent, ResultsMeta)> UpdateScheduleEventAsync(
            ScheduleEvent scheduleEvent)
        {
            (IList<ScheduleEvent> scheduleEvents, ResultsMeta resultsMeta) =
                await UpdateScheduleEventsAsync(new[] { scheduleEvent }, default).ConfigureAwait(false);

            return (scheduleEvents.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update ScheduleEvents, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(ScheduleEvent, ResultsMeta)> UpdateScheduleEventAsync(
            ScheduleEvent scheduleEvent,
            CancellationToken cancellationToken)
        {
            (IList<ScheduleEvent> scheduleEvents, ResultsMeta resultsMeta) =
                await UpdateScheduleEventsAsync(new[] { scheduleEvent }, cancellationToken).ConfigureAwait(false);

            return (scheduleEvents.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Edit one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<ScheduleEvent>, ResultsMeta)> UpdateScheduleEventsAsync(
            IEnumerable<ScheduleEvent> scheduleEvents)
        {
            return await UpdateScheduleEventsAsync(scheduleEvents, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update ScheduleEvents, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<ScheduleEvent>, ResultsMeta)> UpdateScheduleEventsAsync(
            IEnumerable<ScheduleEvent> scheduleEvents,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<ScheduleEvent>(EndpointName.ScheduleEvents, scheduleEvents);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
