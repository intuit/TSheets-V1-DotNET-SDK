// *******************************************************************************
// <copyright file="DateFormatConverterTests.cs" company="Intuit">
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
    using System;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class DateFormatConverterTests
    {
        [TestMethod, TestCategory("Unit")]
        public void BoolStringConverter_SerializesToNullWhenPropertyHasNoValue()
        {
            var testEntity = new DateFormatConverterTestEntity();

            Assert.AreEqual("{\"Created\":null}", JsonConvert.SerializeObject(testEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void DateFormatConverter_SerializesToExpectedStringWhenPropertyIsDateTimeOffsetMinValue()
        {
            var testEntity = new DateFormatConverterTestEntity{ Created = DateTimeOffset.MinValue };

            Assert.AreEqual("{\"Created\":\"0000-00-00\"}", JsonConvert.SerializeObject(testEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void DateFormatConverter_SerializesToExpectedString()
        {
            var expectedDate = "2019-08-12";
            var testEntity = new DateFormatConverterTestEntity { Created = DateTimeOffset.Parse(expectedDate) };

            Assert.AreEqual($"{{\"Created\":\"{expectedDate}\"}}", JsonConvert.SerializeObject(testEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void DateFormatConverter_DeserializesToExpectedValue()
        {
            var expectedDate = "2019-08-12";
            var expectedValue = DateTimeOffset.Parse(expectedDate);

            var testEntity = JsonConvert.DeserializeObject<DateFormatConverterTestEntity>($"{{\"Created\":\"{expectedDate}\"}}");

            Assert.AreEqual(expectedValue, testEntity.Created);
        }

        [TestMethod, TestCategory("Unit")]
        public void DateFormatConverter_DeserializesToDateTimeOffsetMinValue()
        {
            var testEntity = JsonConvert.DeserializeObject<DateFormatConverterTestEntity>("{\"Created\":\"0000-00-00\"}");

            Assert.AreEqual(DateTimeOffset.MinValue, testEntity.Created);
        }

        [TestMethod, TestCategory("Unit")]
        public void DateFormatConverter_DeserializesToDateTimeOffsetMinValueWhenEmptyString()
        {
            var testEntity = JsonConvert.DeserializeObject<DateFormatConverterTestEntity>("{\"Created\":\"\"}");

            Assert.AreEqual(DateTimeOffset.MinValue, testEntity.Created);
        }
    }

    public class DateFormatConverterTestEntity
    {
        [JsonConverter(typeof(DateFormatConverter))]
        public DateTimeOffset? Created { get; set; }
    }
}
