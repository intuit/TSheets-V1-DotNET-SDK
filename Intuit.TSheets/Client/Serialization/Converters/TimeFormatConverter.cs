// *******************************************************************************
// <copyright file="TimeFormatConverter.cs" company="Intuit">
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
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// A custom converter for serializing DateTime properties in time-only format.
    /// </summary>
    internal class TimeFormatConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// The format for representing the time-only portion of a date/time value.
        /// </summary>
        internal const string TimeOnly = "HH:mm:ss";

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeFormatConverter"/> class.
        /// </summary>
        /// <remarks>Scope must remain public for schema generation.</remarks>
        public TimeFormatConverter()
        {
            DateTimeFormat = TimeOnly;
        }
    }
}
