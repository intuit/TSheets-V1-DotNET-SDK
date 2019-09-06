// *******************************************************************************
// <copyright file="EntityFilter.cs" company="Intuit">
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

namespace Intuit.TSheets.Model.Filters
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Common base class for all entity filters. Converts properties into a dictionary
    /// for easy construction of URL query parameter strings.
    /// </summary>
    public abstract class EntityFilter : IEntityFilter
    {
        /// <summary>
        /// Generates a set of key/value pairs from the properties of a EntityFilter object.
        /// </summary>
        /// <returns>The set of key/value pairs</returns>
        public virtual Dictionary<string, string> GetFilters()
        {
            string serialized = JsonConvert.SerializeObject(
                this,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(serialized);
        }
    }
}