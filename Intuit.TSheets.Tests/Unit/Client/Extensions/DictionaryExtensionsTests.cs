// *******************************************************************************
// <copyright file="DictionaryExtensionsTests.cs" company="Intuit">
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
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DictionaryExtensionsTests
    {
        [TestMethod, TestCategory("Unit")]
        public void DictionaryExtensions_ToUrlQueryStringReturnsExpectedConcatenationOfKeysAndValues()
        {
            const string expectedValue = "key1=value1&key2=value2";
            var dict = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            string actualValue = dict.ToUrlQueryString();

            Assert.IsTrue(actualValue.Equals(expectedValue),
                $"Expected '{expectedValue}', but extension method returned '{actualValue}'");
        }

        [TestMethod, TestCategory("Unit")]
        public void DictionaryExtensions_ToUrlQueryStringReturnsEmptyStringWhenDictionaryIsEmpty()
        {
            var dict = new Dictionary<string, string>();

            string actualValue = dict.ToUrlQueryString();

            Assert.IsTrue(actualValue.Equals(string.Empty), "Expected empty string.");
        }

        [TestMethod, TestCategory("Unit")]
        public void DictionaryExtensions_ToUrlQueryStringProperlyEscapesValues()
        {
            const string expectedValue = "start=2019-07-23T12%3A00%3A00%2B06%3A00";
            var dict = new Dictionary<string, string>
            {
                { "start", "2019-07-23T12:00:00+06:00" }
            };

            string actualValue = dict.ToUrlQueryString();

            Assert.IsTrue(actualValue.Equals(expectedValue),
                $"Expected '{expectedValue}', but extension method returned '{actualValue}'");
        }
    }
}
