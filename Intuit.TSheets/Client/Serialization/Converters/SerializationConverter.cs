// *******************************************************************************
// <copyright file="SerializationConverter.cs" company="Intuit">
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
    using System.Reflection;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A custom converter for controlling whether properties of entities are to be serialized.
    /// </summary>
    /// <example>
    /// The "Id" property of any given entity is set by the TSheets API at the time the entity
    /// is created.  Since we don't want this property to be included in serialized POST requests
    /// (but we *DO* want it included on PUT requests), it should be marked with the [NoSerializeOnCreate]
    /// attribute, and this class should be instantiated by passing "typeof(NoSerializeOnCreate)"
    /// into the constructor as a "noSerializeType".
    /// <para/>
    /// Likewise, the "CreatedData" property is never to be serialized (whether a POST/PUT).
    /// This property is therefore attributed with [NoSerializeOnWrite].
    /// </example>
    internal class SerializationConverter : JsonConverter
    {
        private readonly List<Type> noSerializeTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationConverter"/> class.
        /// </summary>
        /// <param name="noSerializeTypes">
        /// The <see cref="Attribute"/> types used to indicate properties must not be serialized.
        /// </param>
        internal SerializationConverter(params Type[] noSerializeTypes)
        {
            this.noSerializeTypes = noSerializeTypes.ToList();
        }

        /// <summary>
        /// Gets a value indicating whether this converter can read JSON.
        /// </summary>
        public override bool CanRead => false;

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <remarks>
        /// Only objects decorated with the [DataEntity] attribute can be converted.
        /// </remarks>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType) => 
            objectType.GetCustomAttribute(typeof(DataEntityAttribute)) != null;

        /// <summary>
        /// During deserialization, reads the JSON representation of the object and converts a custom string into a bool value.
        /// </summary>
        /// <remarks>
        /// Not implemented.
        /// </remarks>
        /// <param name="reader">The <see cref="JsonReader"/> from which to read.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// During serialization, writes the JSON representation of the object.  Properties attributed
        /// with any of the provided 'noSerializeTypes' attributes will be silently omitted.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> into which to write.</param>
        /// <param name="value">The value to be converted/written.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken jt = JToken.FromObject(value);
            Type type = value.GetType();

            foreach (PropertyInfo propInfo in type.GetProperties())
            {
                if (!propInfo.CanRead)
                {
                    continue;
                }

                object propVal = propInfo.GetValue(value, null);

                bool noSerializeAttribute = this.noSerializeTypes.Any(n => propInfo.GetCustomAttribute(n) != null);

                if (propVal == null || noSerializeAttribute)
                {
                    var jsonPropertyAttribute = propInfo.GetCustomAttribute<JsonPropertyAttribute>();
                    jt.SelectToken(jsonPropertyAttribute.PropertyName).Parent.Remove();
                }
            }
            
            jt.WriteTo(writer);
        }
    }
}
