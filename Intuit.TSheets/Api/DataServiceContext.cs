// *******************************************************************************
// <copyright file="DataServiceContext.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Core;

    /// <summary>
    /// Class which contains data needed to establish a connection to the TSheets API
    /// </summary>
    public class DataServiceContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataServiceContext"/> class.
        /// </summary>
        /// <param name="authToken">
        /// The authentication token.
        /// </param>
        public DataServiceContext(string authToken)
            : this(new ConnectionInfo(), new StaticAuthentication(authToken))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataServiceContext"/> class.
        /// </summary>
        /// <param name="authProvider">
        /// An instance of a <see cref="IOAuth2"/> authentication provider class.
        /// </param>
        public DataServiceContext(IOAuth2 authProvider)
            : this(new ConnectionInfo(), authProvider)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataServiceContext"/> class.
        /// </summary>
        /// <param name="connectionInfo">
        /// An instance of a <see cref="ConnectionInfo"/> class.
        /// </param>
        /// <param name="authProvider">
        /// An instance of a <see cref="IOAuth2"/> authentication provider class.
        /// </param>
        public DataServiceContext(ConnectionInfo connectionInfo, IOAuth2 authProvider)
        {
            ConnectionInfo = connectionInfo;
            AuthProvider = authProvider;
        }

        /// <summary>
        /// Gets or sets the instance of the <see cref="ConnectionInfo"/> class.
        /// </summary>
        public ConnectionInfo ConnectionInfo { get; set; }

        /// <summary>
        /// Gets or sets the instance of the <see cref="IOAuth2"/> authentication provider class.
        /// </summary>
        public IOAuth2 AuthProvider { get; set; }

        /// <summary>
        /// Gets or sets the managed client id.
        /// </summary>
        /// <remarks>
        /// If you have the external access add-on installed in your TSheets account, you can
        /// make API requests using your auth token against clients that you manage. When you
        /// want to make an API request against one of the clients that you manage, you must
        /// include this property value.  To obtain the id's of clients you managed, call
        /// the GetManagedClients() data service method.
        /// </remarks>
        public int? ManagedClientId { get; set; }
    }
}
