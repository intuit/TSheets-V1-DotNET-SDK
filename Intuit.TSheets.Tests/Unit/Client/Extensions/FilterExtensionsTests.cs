// *******************************************************************************
// <copyright file="FilterExtensionsTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Extensions
{
    using System;
    using System.Collections.Generic;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FilterExtensionsTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GetFiltersWithOptions_ThrowsWhenOptionsIsNull()
        {
            var filter = new BasicTestEntityFilter();
            Assert.ThrowsException<ArgumentNullException>(() => filter.GetFiltersWithOptions(null));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetFiltersWithOptions_ReturnsExpectedResults()
        {
            var filter = new BasicTestEntityFilter
            {
                Ids = new[] {1, 2, 3},
                Name = "Test"
            };

            var options = new RequestOptions()
            {
                IncludeSupplementalData = false,
                Page = 7,
                PerPage = 23
            };

            Dictionary<string, string> filterPairs = filter.GetFiltersWithOptions(options);

            const int expectedFilterPairCount = 5;
            Assert.AreEqual(expectedFilterPairCount, filterPairs.Count, $"Expected {expectedFilterPairCount} filter pairs.");

            Assert.AreEqual("1,2,3", filterPairs["ids"]);
            Assert.AreEqual("Test", filterPairs["name"]);
            Assert.AreEqual("no", filterPairs["supplemental_data"]);
            Assert.AreEqual("7", filterPairs["page"]);
            Assert.AreEqual("23", filterPairs["per_page"]);
        }
    }
}
