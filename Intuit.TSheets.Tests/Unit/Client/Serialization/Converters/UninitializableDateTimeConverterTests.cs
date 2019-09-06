// *******************************************************************************
// <copyright file="UninitializableDateTimeConverterTests.cs" company="Intuit">
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
    public class UninitializableDateTimeConverterTests
    {
        [TestMethod, TestCategory("Unit")]
        public void UninitializableDateTimeConverter_SerializesToEmptyStringWhenPropertyIsDateTimeOffsetMinValue()
        {
            var testEntity = new UninitializableDateTimeConverterTestEntity{ Created = DateTimeOffset.MinValue };

            Assert.AreEqual("{\"Created\":\"\"}", JsonConvert.SerializeObject(testEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UninitializableDateTimeConverter_SerializesToExpectedString()
        {
            var expectedDate = "2019-08-12T12:00:00-06:00";
            var testEntity = new UninitializableDateTimeConverterTestEntity { Created = DateTimeOffset.Parse(expectedDate) };

            Assert.AreEqual($"{{\"Created\":\"{expectedDate}\"}}", JsonConvert.SerializeObject(testEntity));
        }
    }

    public class UninitializableDateTimeConverterTestEntity
    {
        [JsonConverter(typeof(DateTimeFormatConverter))]
        public DateTimeOffset? Created { get; set; }
    }
}
