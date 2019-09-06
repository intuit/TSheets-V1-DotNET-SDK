// *******************************************************************************
// <copyright file="FilterExtensions.cs" company="Intuit">
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
    using System.Collections.Generic;
    using System.Linq;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Model.Filters;

    /// <summary>
    /// For internal use, extension methods for IEntityFilter objects.
    /// </summary>
    internal static class FilterExtensions
    {
        /// <summary>
        /// Returns a dictionary of key/value pairs for which request options
        /// have been added to the existing set of filters.
        /// </summary>
        /// <param name="filter">
        /// A <see cref="IEntityFilter"/> instance; an object which can be represented as a set of key/value pairs.
        /// </param>
        /// <param name="options">
        /// A <see cref="RequestOptions"/> object for controlling the behavior of API calls.
        /// </param>
        /// <returns>The dictionary of concatenated key-value pairs.</returns>
        internal static Dictionary<string, string> GetFiltersWithOptions(
            this IEntityFilter filter,
            RequestOptions options)
        {
            options.ThrowIfNull();

            Dictionary<string, string> filters = filter.GetFilters();
            Dictionary<string, string> optionsFilters = options.GetFilters();

            return filters.Concat(optionsFilters).ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
