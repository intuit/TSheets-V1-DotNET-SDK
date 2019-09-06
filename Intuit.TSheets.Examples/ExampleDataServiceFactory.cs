// *******************************************************************************
// <copyright file="Program.cs" company="Intuit">
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

namespace Intuit.TSheets.Examples
{
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Example factory class for creating an API client (i.e. instance of a DataService)
    /// </summary>
    /// <remarks>
    /// Purpose of this example is to demonstrate a variety of ways to configure your
    /// DataService, depending on use case.
    /// </remarks>
    internal static class ExampleDataServiceFactory
    {
        /// <summary>
        /// Returns the simplest possible instantiation of a <see cref="DataService"/> class.
        /// </summary>
        /// <param name="authToken">The OAuth token.</param>
        /// <returns>An instance of a data service.</returns>
        internal static DataService CreateDataService_Simplest(string authToken)
        {
            return new DataService(authToken);
        }

        /// <summary>
        /// Returns a simple instantiation of a <see cref="DataService"/> class, with logging.
        /// </summary>
        /// <param name="authToken">The OAuth token.</param>
        /// <returns>An instance of a data service.</returns>
        internal static DataService CreateDataService(string authToken, ILogger logger)
        {
            return new DataService(authToken, logger);
        }

        /// <summary>
        /// Returns an instantiation of a <see cref="DataService"/> class, with a custom 
        /// authentication provider and logging.
        /// </summary>
        /// <param name="authToken">The OAuth token.</param>
        /// <returns>An instance of a data service.</returns>
        internal static DataService CreateDataService_CustomAuthProviderWithLogging(string authToken, ILogger logger)
        {
            var authProvider = new CustomAuthProvider();
            return new DataService(new DataServiceContext(authProvider), logger);
        }

        /// <summary>
        /// Returns an instantiation of a <see cref="DataService"/> class, with a custom 
        /// base URI, a custom authentication provider, and logging.
        /// </summary>
        /// <param name="authToken">The OAuth token.</param>
        /// <returns>An instance of a data service.</returns>
        internal static DataService CreateDataService_CustomBaseUriAndAuthProviderWithLogging(string authToken, ILogger logger)
        {
            var connectInfo = new ConnectionInfo("https://some.test.server/api/v1");
            var authProvider = new CustomAuthProvider();

            return new DataService(
                new DataServiceContext(connectInfo, authProvider),
                logger);
        }

        /// <summary>
        /// Returns an instantiation of a <see cref="DataService"/> class, with transient error
        /// retry logic disabled, and logging.
        /// </summary>
        /// <param name="authToken">The OAuth token.</param>
        /// <returns>An instance of a data service.</returns>
        internal static DataService CreateDataService_RetryBehaviorDisabled(string authToken, ILogger logger)
        {
            return new DataService(authToken, RetrySettings.None, logger);
        }

        /// <summary>
        /// Returns an instantiation of a <see cref="DataService"/> class, with custom transient error
        /// retry logic, and logging.
        /// </summary>
        /// <param name="authToken">The OAuth token.</param>
        /// <returns>An instance of a data service.</returns>
        internal static DataService CreateDataService_CustomRetryBehavior(string authToken, ILogger logger)
        {
            // Example retries up to 5 times when the API service is unavailable (HTTP 503).
            // The formula is R^e*m, where "R" is the retry number, "e" is the exponential back-off value, and "m" is
            // a multiplier to linearly compress/expand time between the retries (first 3 params below, respectively).
            // So for this example: R^2*1.5 => retries after 1.5, 6, 13.5, 24, & 37.5 seconds.
            var retrySettings = new RetrySettings(5, 2.0f, 1.5f, typeof(ServiceUnavailableException));
            return new DataService(authToken, retrySettings, logger);
        }

        /// <summary>
        /// Demonstrates overriding the TLS security protocol (for future support). Currently there is no
        /// use case for this, and the example will not work.  The V1 TSheets API supports TLS 1.2.
        /// </summary>
        /// <param name="authToken">The OAuth token.</param>
        /// <returns>An instance of a data service.</returns>
        internal static DataService CreateDataService_OverrideSecurityProtocol(string authToken, ILogger logger)
        {
            ConnectionInfo.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
            return new DataService(authToken, logger);
        }

        /// <summary>
        /// Make a call on behalf of one of the clients your account manages.
        /// </summary>
        /// <remarks>
        /// If you have the external access add-on installed in your account, you can make API requests using
        /// your auth token against clients that you manage. When you want to make an API request against one
        /// of the clients that you manage, you must include the client's id in the DataServiceContext object.
        /// You can obtain the client IDs of the clients you manage by calling GetManagedClients().
        /// </remarks>
        /// <param name="authToken">The OAuth token.</param>
        /// <param name="managedClientId">The id of the managed client.</param>
        /// <returns>An instance of a data service.</returns>
        internal static DataService CreateDataService_ManagedClient(string authToken, int managedClientId, ILogger logger)
        {
            var context = new DataServiceContext(authToken)
            {
                ManagedClientId = managedClientId
            };

            return new DataService(context, logger);
        }
    }
}
