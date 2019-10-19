// *******************************************************************************
// <copyright file="DataService_ScheduleCalendars.cs" company="Intuit">
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
    /// This file contains operations specific to the ScheduleCalendars endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ScheduleCalendar>, ResultsMeta) GetScheduleCalendars()
        {
            return AsyncUtil.RunSync(() => GetScheduleCalendarsAsync());
        }

        /// <summary>
        /// Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ScheduleCalendar>, ResultsMeta) GetScheduleCalendars(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetScheduleCalendarsAsync(options));
        }

        /// <summary>
        /// Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleCalendarFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ScheduleCalendar>, ResultsMeta) GetScheduleCalendars(
            ScheduleCalendarFilter filter)
        {
            return AsyncUtil.RunSync(() => GetScheduleCalendarsAsync(filter));
        }

        /// <summary>
        /// Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleCalendarFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<ScheduleCalendar>, ResultsMeta) GetScheduleCalendars(
            ScheduleCalendarFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetScheduleCalendarsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ScheduleCalendar>, ResultsMeta)> GetScheduleCalendarsAsync()
        {
            return await GetScheduleCalendarsAsync(null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ScheduleCalendar>, ResultsMeta)> GetScheduleCalendarsAsync(
            RequestOptions options)
        {
            return await GetScheduleCalendarsAsync(null, options).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleCalendarFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ScheduleCalendar>, ResultsMeta)> GetScheduleCalendarsAsync(
            ScheduleCalendarFilter filter)
        {
            return await GetScheduleCalendarsAsync(filter, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleCalendarFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<ScheduleCalendar>, ResultsMeta)> GetScheduleCalendarsAsync(
            ScheduleCalendarFilter filter,
            RequestOptions options)
        {
            var context = new GetContext<ScheduleCalendar>(EndpointName.ScheduleCalendars, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
