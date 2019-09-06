// *******************************************************************************
// <copyright file="EnumerableToCsvConverter.cs" company="Intuit">
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
    using System.Collections.Generic;
    using System.Linq;
    using Intuit.TSheets.Client.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A JSON serialization converter for serializing objects of type IEnumerable&lt;T&gt;
    /// to a string of comma-delimited values, and deserializing the inverse.
    /// </summary>
    internal class EnumerableToCsvConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        /// <remarks>
        /// Conversion is available for generic enumerable types.
        /// </remarks>
        public override bool CanConvert(Type objectType)
            => objectType.GetInterfaces().Any(
                t => t.GetGenericTypeDefinition() == typeof(IEnumerable<>));

        /// <summary>
        /// Convert a string of values into a list.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> from which to read.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param> 
        /// <example>
        /// <![CDATA[
        /// Given: "1,2,3", Return: new List<int>{ 1, 2, 3 }
        /// ]]>
        /// </example>
        /// <returns>The generic list of values</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var csv = (string)reader.Value;

            if (string.IsNullOrWhiteSpace(csv))
            {
                return null;
            }

            // Split the values and return as a list of ints if possible, else as a list of strings.
            List<string> values = csv.Split(',').Select(p => p.Trim()).ToList();

            if (values.All(v => int.TryParse(v, out _)))
            {
                return values.Select(v => int.Parse(v)).ToList();
            }

            return values;
        }

        /// <summary>
        /// Convert a list of values into a comma-separated string.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> into which to write.</param>
        /// <param name="value">The value to be converted/written.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        /// <example>
        /// <![CDATA[
        /// Given: List<int>{ 1, 2, 3 }, Return: "1,2,3"
        /// ]]>
        /// </example>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            value.ThrowIfNull();

            string csv;
            switch (value)
            {
                case IEnumerable<string> stringsValue:
                    csv = string.Join(",", stringsValue);
                    break;

                case IEnumerable<int> intsValue:
                    csv = string.Join(",", intsValue);
                    break;

                default:
                    throw new InvalidOperationException("Unexpected type.");
            }

            JToken jt = JToken.FromObject(csv);
            jt.WriteTo(writer);
        }
    }
}   