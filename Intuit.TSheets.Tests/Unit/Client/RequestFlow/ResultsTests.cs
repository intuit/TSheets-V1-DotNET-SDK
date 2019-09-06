// *******************************************************************************
// <copyright file="ResultsTests.cs" company="Intuit">
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

    [TestClass]
    public class ResultsTests
    {
        [TestMethod, TestCategory("Unit")]
        public void Results_PropertiesAreCorrectlyInitialized()
        {
            var results = new Results<TestEntity>();

            Assert.IsNotNull(results.Items, $"Expected {nameof(results.Items)} property to be set.");
            Assert.IsNotNull(results.ErrorItems, $"Expected {nameof(results.ErrorItems)} property to be set.");
        }
    }
}
