// *******************************************************************************
// <copyright file="BoolStringConverter.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Serialization.Converters
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A JSON serialization converter for serializing bool properties to
    /// custom string values, and deserializing the inverse.
    /// </summary>
    internal class BoolStringConverter : JsonConverter
    {
        private const string DefaultTrueString = "yes";
        private const string DefaultFalseString = "no";

        private readonly string trueString;
        private readonly string falseString;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolStringConverter"/> class,
        /// for use with the default serialization string values.
        /// </summary>
        /// <example>
        /// [JsonConverter(typeof(BoolStringConverter)]
        /// public bool IsActive { get; set; }
        /// </example>
        public BoolStringConverter()
            : this(DefaultTrueString, DefaultFalseString)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolStringConverter"/> class,
        /// for customizing the serialized string values.
        /// </summary>
        /// <example>
        /// [JsonConverter(typeof(BoolStringConverter), "yay", "nay")]
        /// public bool IsActive { get; set; }
        /// </example>
        /// <param name="trueString">The serialized string value for 'true'</param>
        /// <param name="falseString">The serialized string value for 'false'</param>
        public BoolStringConverter(string trueString, string falseString)
        {
            this.trueString = trueString;
            this.falseString = falseString;
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType) => true;

        /// <summary>
        /// During deserialization, reads the JSON representation of the object and converts a custom string into a bool value.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> from which to read.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        /// <example> 
        /// <![CDATA[
        /// Given: "yes", Return: true
        /// ]]>
        /// </example>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var input = (string)reader?.Value;

            return input?.Equals(this.trueString, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// During serialization, writes the JSON representation of the object by converting a bool into a corresponding custom string value.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> into which to write.</param>
        /// <param name="value">The value to be converted/written.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        /// <example>
        /// <![CDATA[
        /// Given: true, Return: "yes"
        /// ]]>
        /// </example>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var input = (bool?)value;

            string output = input.HasValue
                ? input.Value ? this.trueString : this.falseString
                : null;

            JToken jt = JToken.FromObject(output);
            jt.WriteTo(writer);
        }
    }
}