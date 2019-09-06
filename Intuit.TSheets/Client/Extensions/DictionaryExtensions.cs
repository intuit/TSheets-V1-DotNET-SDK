// *******************************************************************************
// <copyright file="DictionaryExtensions.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// For internal use, extension methods for Dictionary&lt;string, string&gt; objects.
    /// </summary>
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// Builds and returns a url encoded query string.
        /// </summary>
        /// <param name="value">The input dictionary of key/value pairs</param>
        /// <returns>The url encoded query string.</returns>
        public static string ToUrlQueryString(this Dictionary<string, string> value)
        {
            List<string> pairs = null;
            if (value != null)
            {
                pairs = new List<string>();
                foreach (KeyValuePair<string, string> kvp in value)
                {
                    string escapedKey = Uri.EscapeDataString(kvp.Key);
                    string escapedValue = Uri.EscapeDataString(kvp.Value);
                    pairs.Add($"{escapedKey}={escapedValue}");
                }
            }

            return pairs == null
                ? string.Empty
                : string.Join("&", pairs);
        }
    }
}
