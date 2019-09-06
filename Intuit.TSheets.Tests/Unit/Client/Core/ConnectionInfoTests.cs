// *******************************************************************************
// <copyright file="ConnectionInfoTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Core
{
    using System;
    using System.Net;
    using Intuit.TSheets.Client.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConnectionInfoTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ConnectionInfo_UriPropertyIsInitialized()
        {
            string baseUriString = "http://localhost";
            Uri baseUri = new Uri(baseUriString);

            var connectionInfo = new ConnectionInfo(baseUriString);

            Assert.AreEqual(baseUri, connectionInfo.BaseUri);
        }

        [TestMethod, TestCategory("Unit")]
        public void ConnectionInfo_SecurityProtocolDefaultsToTls12()
        {
            Assert.AreEqual(SecurityProtocolType.Tls12, ConnectionInfo.SecurityProtocol);
        }

        [TestMethod, TestCategory("Unit")]
        public void ConnectionInfo_SecurityProtocolCanBeConfigured()
        {
            var expectedProtocolType = SecurityProtocolType.Tls11;
            ConnectionInfo.SecurityProtocol = expectedProtocolType;
            Assert.AreEqual(expectedProtocolType, ConnectionInfo.SecurityProtocol);
        }
    }
}
