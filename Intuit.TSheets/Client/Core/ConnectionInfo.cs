// *******************************************************************************
// <copyright file="ConnectionInfo.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Core
{
    using System;
    using System.Net;

    /// <summary>
    /// The API application/server connection information
    /// </summary>
    public class ConnectionInfo
    {
        private const string DefaultBaseUri = "https://rest.tsheets.com/api/v1";

        /// <summary>
        /// Initializes static members of the <see cref="ConnectionInfo"/> class.
        /// </summary>
        static ConnectionInfo()
        {
            // Default is TLS 1.2
            SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionInfo"/> class.
        /// </summary>
        public ConnectionInfo()
            : this(new Uri(DefaultBaseUri))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionInfo"/> class.
        /// </summary>
        /// <param name="baseUri">Base URI of the API (https://rest.tsheets.com/api/v1)</param>
        public ConnectionInfo(string baseUri)
            : this(new Uri(baseUri))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionInfo"/> class.
        /// </summary>
        /// <param name="baseUri">Base URI of the API (https://rest.tsheets.com/api/v1)</param>
        public ConnectionInfo(Uri baseUri)
        {
            BaseUri = baseUri;
        }

        /// <summary>
        /// Gets or sets the security protocol to use for the transport layer.
        /// </summary>
        /// <remarks>
        /// This is a static, application-wide setting.
        /// </remarks>
        public static SecurityProtocolType SecurityProtocol
        {
            get
            {
                return ServicePointManager.SecurityProtocol;
            }

            set
            {
                ServicePointManager.SecurityProtocol = value;
            }
        }

        /// <summary>
        /// Gets or sets the base URI of the API (https://rest.tsheets.com/api/v1)
        /// </summary>
        public Uri BaseUri { get; set; }
    }
}
