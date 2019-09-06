// *******************************************************************************
// <copyright file="DateTimeFormatConverter.cs" company="Intuit">
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
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// A converter which writes the expected ISO 8601 formatted string, or an empty string when provided
    ///  with DateTimeOffset.MinValue to indicate an "uninitialized" state.
    /// </summary>
    /// <remarks>
    /// The empty string behavior of this converter exists to support the use case of creating "on-the-clock"
    /// timesheets.  In such a case, the API expects the 'End' property to be set to an empty string.
    /// </remarks>
    internal class DateTimeFormatConverter : IsoDateTimeConverter
    {
        private const string Format = "yyyy-MM-ddTHH:mm:ssK";

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeFormatConverter"/> class.
        /// </summary>
        /// <remarks>Scope must remain public for schema generation.</remarks>
        public DateTimeFormatConverter()
        {
            DateTimeFormat = Format;
        }

        /// <summary>
        /// During serialization, writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> into which to write.</param>
        /// <param name="value">The value to be converted/written.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var temp = value as DateTimeOffset?;

            string valueToWrite = string.Empty;
            if (temp.HasValue && !temp.Value.Equals(DateTimeOffset.MinValue))
            {
                valueToWrite = temp.Value.ToString(Format);
            }

            writer.WriteValue(valueToWrite);
        }
    }
}