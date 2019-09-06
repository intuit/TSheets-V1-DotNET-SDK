// *******************************************************************************
// <copyright file="ReportRequestTests.cs" company="Intuit">
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
    public class ReportRequestTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ReportRequest_IsCorrectlyInitialized()
        {
            var filter = new BasicTestEntityFilter
            {
                Ids = new[] { 1, 2, 3 },
                Name = "test"
            };

            var reportRequest = new ReportRequest(filter);

            int expectedCount = 2;
            Assert.AreEqual(expectedCount, reportRequest.Data.Count, $"Exected {expectedCount} filter items.");
        }
    }
}
