// *******************************************************************************
// <copyright file="DataService_EffectiveSettings.cs" company="Intuit">
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
    /// This file contains operations specific to the EffectiveSettings endpoint.
    /// </remarks>  
    public partial class DataService
    {
        #region Get Methods

        /// <summary>
        /// Retrieve Effective Settings.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        public EffectiveSettings GetEffectiveSettings()
        {
            return GetEffectiveSettings(null);
        }
        
        /// <summary>
        /// Retrieve Effective Settings.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="EffectiveSettingsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        public EffectiveSettings GetEffectiveSettings(EffectiveSettingsFilter filter)
        {
            return AsyncUtil.RunSync(() => GetEffectiveSettingsAsync(filter));
        }

        /// <summary>
        /// Asynchronously Retrieve Effective Settings.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        public async Task<EffectiveSettings> GetEffectiveSettingsAsync()
        {
            return await GetEffectiveSettingsAsync(null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Effective Settings, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        public async Task<EffectiveSettings> GetEffectiveSettingsAsync(
            CancellationToken cancellationToken)
        {
            return await GetEffectiveSettingsAsync(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Effective Settings.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="EffectiveSettingsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        public async Task<EffectiveSettings> GetEffectiveSettingsAsync(
            EffectiveSettingsFilter filter)
        {
            return await GetEffectiveSettingsAsync(filter, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Effective Settings, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="EffectiveSettingsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        public async Task<EffectiveSettings> GetEffectiveSettingsAsync(
            EffectiveSettingsFilter filter,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<EffectiveSettings>(EndpointName.EffectiveSettings, filter);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return context.Results.Items.FirstOrDefault();
        }

        #endregion
    }
}
