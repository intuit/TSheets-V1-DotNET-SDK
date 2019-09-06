// *******************************************************************************
// <copyright file="BoolStringConverterTests.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Converters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class BoolStringConverterTests
    {
        [TestMethod, TestCategory("Unit")]
        public void BoolStringConverter_SerializesToCustomStringValues()
        {
            var testEntityFalse = new BoolStringConverterCustomTestEntity { Active = false };
            var testEntityTrue = new BoolStringConverterCustomTestEntity { Active = true };

            Assert.AreEqual("{\"Active\":\"nope\"}", JsonConvert.SerializeObject(testEntityFalse));
            Assert.AreEqual("{\"Active\":\"yep\"}", JsonConvert.SerializeObject(testEntityTrue));
        }

        [TestMethod, TestCategory("Unit")]
        public void BoolStringConverter_DeserializesFromCustomStringValues()
        {
            var testEntityFalse = JsonConvert.DeserializeObject<BoolStringConverterCustomTestEntity>("{\"Active\":\"nope\"}");
            var testEntityTrue = JsonConvert.DeserializeObject<BoolStringConverterCustomTestEntity>("{\"Active\":\"yep\"}");

            Assert.IsFalse(testEntityFalse.Active);
            Assert.IsTrue(testEntityTrue.Active);
        }

        [TestMethod, TestCategory("Unit")]
        public void BoolStringConverter_SerializesToDefaultStringValues()
        {
            var testEntityFalse = new BoolStringConverterTestEntity { Active = false };
            var testEntityTrue = new BoolStringConverterTestEntity { Active = true };

            Assert.AreEqual("{\"Active\":\"no\"}", JsonConvert.SerializeObject(testEntityFalse));
            Assert.AreEqual("{\"Active\":\"yes\"}", JsonConvert.SerializeObject(testEntityTrue));
        }

        [TestMethod, TestCategory("Unit")]
        public void BoolStringConverter_DeserializesFromDefaultStringValues()
        {
            var testEntityFalse = JsonConvert.DeserializeObject<BoolStringConverterTestEntity>("{\"Active\":\"no\"}");
            var testEntityTrue = JsonConvert.DeserializeObject<BoolStringConverterTestEntity>("{\"Active\":\"yes\"}");

            Assert.IsFalse(testEntityFalse.Active);
            Assert.IsTrue(testEntityTrue.Active);
        }
    }

    public class BoolStringConverterCustomTestEntity
    {
        [JsonConverter(typeof(BoolStringConverter), "yep", "nope")]
        public bool Active { get; set; }
    }

    public class BoolStringConverterTestEntity
    {
        [JsonConverter(typeof(BoolStringConverter))]
        public bool Active { get; set; }
    }
}
