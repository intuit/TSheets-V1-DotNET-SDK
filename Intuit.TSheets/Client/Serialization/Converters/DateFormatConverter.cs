// *******************************************************************************
// <copyright file="DateFormatConverter.cs" company="Intuit">
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
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// A JSON serialization converter for customizing the serialization format of dates.
    /// </summary>
    /// <remarks>
    /// This converter is necessitated by the TSheets' API convention of using "0000-00-00"
    /// to indicate an uninitialized date.
    /// </remarks>
    internal class DateFormatConverter : IsoDateTimeConverter
    {
        private const string UninitializedDateString = "0000-00-00";
        private const string DateOnlyFormat = "yyyy-MM-dd";

        /// <summary>
        /// Initializes a new instance of the <see cref="DateFormatConverter"/> class.
        /// </summary>
        /// <remarks>Scope must remain public for schema generation.</remarks>
        public DateFormatConverter()
        {
            DateTimeFormat = DateOnlyFormat;
        }

        /// <summary>
        /// During serialization, writes a date string from the <see cref="DateTimeOffset"/> object.
        /// If value is DateTimeOffset.MinValue, then special value "0000-00-00" is written.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> into which to write.</param>
        /// <param name="value">The value to be converted/written.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param> 
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string outValue = GetStringValue(value as DateTimeOffset?, DateOnlyFormat);

            writer.WriteValue(outValue);
        }

        /// <summary>
        /// During deserialization, parses a date string into a <see cref="DateTimeOffset"/> object.
        /// If value is "0000-00-00", then DateTimeOffset.MinValue is returned.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> from which to read.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer, <see cref="JsonSerializer"/></param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return GetDateTimeOffsetValue((string)reader.Value, DateOnlyFormat);
        }

        private static DateTimeOffset GetDateTimeOffsetValue(string stringValue, string format)
        {
            return stringValue.Equals(UninitializedDateString)
                ? DateTimeOffset.MinValue
                : DateTimeOffset.ParseExact(stringValue, format, CultureInfo.InvariantCulture);
        }

        private static string GetStringValue(DateTimeOffset? dateTimeOffsetValue, string format)
        {
            return dateTimeOffsetValue.HasValue
                ? dateTimeOffsetValue.Value == DateTimeOffset.MinValue
                    ? UninitializedDateString
                    : dateTimeOffsetValue.Value.ToString(format)
                : null;
        }
    }
}
