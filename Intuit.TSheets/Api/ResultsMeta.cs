// *******************************************************************************
// <copyright file="ResultsMeta.cs" company="Intuit">
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

namespace Intuit.TSheets.Api
{
    using Newtonsoft.Json;

    /// <summary>
    /// Contains metadata information regarding the results of an API call.
    /// </summary>
    [JsonObject]
    public class ResultsMeta
    {
        /// <summary>
        /// Gets a value indicating whether additional results are available.
        /// </summary>
        /// <remarks>
        /// If true, a follow-up call to retrieve the next page of results can be made.
        /// </remarks>
        [JsonProperty]
        public bool More { get; internal set; }

        /// <summary>
        /// Gets the current page number of results.
        /// </summary>
        [JsonProperty]
        public int Page { get; internal set; }

        /// <summary>
        /// Gets or sets additional objects related to the entities returned, <see cref="SupplementalData"/>
        /// </summary>
        [JsonProperty]
        public SupplementalData SupplementalData { get; set; }
            = new SupplementalData();
    }
}
