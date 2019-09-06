// *******************************************************************************
// <copyright file="EmptyArrayObjectConverter.cs" company="Intuit">
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
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// This converter is a workaround for a bug in the TSheets API responses.  Specifically, some properties 
    /// will contain an empty JSON *array* to indicate no results found, when in actuality the response should
    /// be an empty *object*. This specialized converter simply ignores the unexpected empty arrays, and falls
    /// back to default conversion in the expected object case. Without it, serialization would fail with
    /// message "Cannot deserialize the current JSON array".
    /// <para/>
    /// As an example, see the "GET Files" operation:
    /// <para/>
    /// When empty:
    /// "linked_objects": [],
    /// <para/>
    /// When not empty:
    /// "linked_objects": {
    ///     "timesheets": [
    ///         "55912018",
    ///         "55913268"
    ///     ]
    /// }
    /// </summary>
    internal class EmptyArrayObjectConverter : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this converter can read JSON.
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true to indicate the type can be converted</returns>
        public override bool CanConvert(Type objectType) => true;

        /// <summary>
        /// During serialization, writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> into which to write.</param>
        /// <param name="value">The value to be converted/written.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken token = JToken.FromObject(value);

            token.WriteTo(writer);
        }

        /// <summary>
        /// During deserialization, reads the JSON representation of the object and handles accordingly, whether of type array or object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> from which to read.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                {
                    // consume & discard the empty array
                    JArray array = JArray.Load(reader);
                    if (array.Any())
                    {
                        throw new JsonSerializationException("Expected empty array.");
                    }

                    return null;
                }

                case JsonToken.StartObject:
                {
                    JsonContract contract = serializer.ContractResolver.ResolveContract(objectType);
                    existingValue = existingValue ?? contract.DefaultCreator();
                    serializer.Populate(reader, existingValue);
                    return existingValue;
                }

                default:
                    return null;
            }
        }
    }
}
