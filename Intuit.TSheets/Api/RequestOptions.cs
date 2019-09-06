// *******************************************************************************
// <copyright file="RequestOptions.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Filters;
    using Newtonsoft.Json;

    /// <summary>
    /// Controls the behavior of API calls
    /// </summary>
    [JsonObject]
    public class RequestOptions : EntityFilter
    {
        /// <summary>
        /// Default setting for AutoPaging behavior.
        /// </summary>
        public const bool AutoPagingDefault = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class.
        /// </summary>
        public RequestOptions()
        {
            AutoPaging = AutoPagingDefault;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="SupplementalData"/> will be returned.
        /// </summary>
        /// <remarks>
        /// If true, <see cref="SupplementalData"/> will be returned in the <see cref="ResultsMeta"/> response object (where applicable).
        /// </remarks>
        [JsonConverter(typeof(BoolStringConverter))]
        [JsonProperty("supplemental_data")]
        public bool? IncludeSupplementalData { get; set; }

        /// <summary>
        /// Gets or sets the number of entity items to be retrieved, per page.
        /// </summary>
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page number of entity items to be retrieved.
        /// </summary>
        [JsonProperty("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether auto paging behavior is enabled or disabled. (enabled by default)
        /// </summary>
        /// <remarks>
        /// The TSheets API returns a maximum of 50 items per call.  If AutoPaging is enabled,
        /// follow-up calls to retrieve the additional pages will automatically be made in the
        /// event that retrieval call results in more than 50 items.  If disabled, additional
        /// pages will need to be retrieved manually (using <see cref="Page"/>, while the 
        /// 'More' property of <see cref="ResultsMeta"/> is true.)
        /// </remarks>
        [JsonIgnore]
        public bool AutoPaging { get; set; }
    }
}
