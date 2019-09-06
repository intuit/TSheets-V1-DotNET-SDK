// *******************************************************************************
// <copyright file="RequestTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.RequestFlow
{
    using Intuit.TSheets.Client.RequestFlow;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class RequestTests
    {
        [TestMethod, TestCategory("Unit")]
        public void Request_IsCorrectlyInitializedWithNull()
        {
            var request = new Request<BasicTestEntity>(null);

            Assert.IsNotNull(request.Data);
        }

        [TestMethod, TestCategory("Unit")]
        public void Request_IsCorrectlyInitialized()
        {
            int entityCount = 2;
            var entities = new List<BasicTestEntity>(entityCount);
            for (int i = 0; i < entityCount; i++)
            {
                entities.Add((BasicTestEntity)AutoFixture.Create(typeof(BasicTestEntity)));
            }

            var request = new Request<BasicTestEntity>(entities);

            Assert.AreEqual(entityCount, request.Data.Length);
        }
    }
}
