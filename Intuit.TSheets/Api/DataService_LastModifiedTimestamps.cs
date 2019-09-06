// *******************************************************************************
// <copyright file="DataService_LastModifiedTimestamps.cs" company="Intuit">
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
    using System.Linq;
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
    /// This file contains operations specific to the LastModifiedTimestamps endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Last Modified Timestamps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of last modified timestamps associated with each requested API endpoint. 
        /// </remarks>
        /// <returns>
        /// An instance of a <see cref="LastModifiedTimestamps"/> class.
        /// </returns>
        public LastModifiedTimestamps GetLastModifiedTimestamps()
        {
            return GetLastModifiedTimestamps(null);
        }

        /// <summary>
        /// Retrieve Last Modified Timestamps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of last modified timestamps associated with each requested API endpoint. 
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LastModifiedTimestampsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of a <see cref="LastModifiedTimestamps"/> class.
        /// </returns>
        public LastModifiedTimestamps GetLastModifiedTimestamps(LastModifiedTimestampsFilter filter)
        {
            return AsyncUtil.RunSync(() => GetLastModifiedTimestampsAsync(filter));
        }

        /// <summary>
        /// Asynchronously Retrieve Last Modified Timestamps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of last modified timestamps associated with each requested API endpoint. 
        /// </remarks>
        /// <returns>
        /// An instance of a <see cref="LastModifiedTimestamps"/> class.
        /// </returns>
        public async Task<LastModifiedTimestamps> GetLastModifiedTimestampsAsync()
        {
            return await GetLastModifiedTimestampsAsync(null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Last Modified Timestamps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of last modified timestamps associated with each requested API endpoint. 
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LastModifiedTimestampsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of a <see cref="LastModifiedTimestamps"/> class.
        /// </returns>
        public async Task<LastModifiedTimestamps> GetLastModifiedTimestampsAsync(LastModifiedTimestampsFilter filter)
        {
            var context = new GetContext<LastModifiedTimestamps>(EndpointName.LastModifiedTimestamps, filter);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return context.Results.Items.FirstOrDefault();
        }

        #endregion
    }
}
