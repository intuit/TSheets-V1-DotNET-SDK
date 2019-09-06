// *******************************************************************************
// <copyright file="SerializationConverterTests.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class SerializationConverterTests
    {
        [TestMethod, TestCategory("Unit")]
        public void SerializationConverter_OmitsPropertiesWithNoSerializeAttribute()
        {
            var expected = "{\"name\":\"Bob\"}";

            var entity = new SerializationConverterTestEntity
            {
                Id = 1,
                Name = "Bob"
            };

            var converter = new SerializationConverter(typeof(NoSerializeOnWriteAttribute));
            string actual = JsonConvert.SerializeObject(entity, Formatting.None, converter);

            Assert.AreEqual(expected, actual);
        }
    }

    [DataEntity]
    [JsonObject]
    public class SerializationConverterTestEntity
    {
        [NoSerializeOnWrite]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
