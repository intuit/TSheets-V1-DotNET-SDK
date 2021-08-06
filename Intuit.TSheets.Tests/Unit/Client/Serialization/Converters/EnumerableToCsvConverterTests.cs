// *******************************************************************************
// <copyright file="EnumerableToCsvConverterTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Serialization.Converters
{
    using System.Collections.Generic;
    using System.Linq;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class EnumerableToCsvConverterTests
    {
        [TestMethod, TestCategory("Unit")]
        public void EnumerableToCsvConverter_SerializesLongsToCsv()
        {
            var testEntityFalse = new LongsToCsvConverterTestEntity { Ids = new long[] { 1, 2, 3 } };

            Assert.AreEqual("{\"Ids\":\"1,2,3\"}", JsonConvert.SerializeObject(testEntityFalse));
        }

        [TestMethod, TestCategory("Unit")]
        public void EnumerableToCsvConverter_SerializesStringsToCsv()
        {
            var testEntityFalse = new StringsToCsvConverterTestEntity { Ids = new[] { "one", "two", "three" } };

            Assert.AreEqual("{\"Ids\":\"one,two,three\"}", JsonConvert.SerializeObject(testEntityFalse));
        }

        [TestMethod, TestCategory("Unit")]
        public void EnumerableToCsvConverter_DeserializesCsvToLongs()
        {
            var expected = new long[] { 1, 2, 3 };
            var testEntity = JsonConvert.DeserializeObject<LongsToCsvConverterTestEntity>("{\"Ids\":\"1,2,3\"}");

            Assert.IsTrue(expected.SequenceEqual(testEntity.Ids));
        }

        [TestMethod, TestCategory("Unit")]
        public void EnumerableToCsvConverter_DeserializesCsvToStrings()
        {
            var expected = new[] { "one", "two", "three" };
            var testEntity = JsonConvert.DeserializeObject<StringsToCsvConverterTestEntity>("{\"Ids\":\"one,two,three\"}");

            Assert.IsTrue(expected.SequenceEqual(testEntity.Ids));
        }
    }

    public class LongsToCsvConverterTestEntity
    {
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        public IList<long> Ids { get; set; }
    }

    public class StringsToCsvConverterTestEntity
    {
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        public IList<string> Ids { get; set; }
    }
}
