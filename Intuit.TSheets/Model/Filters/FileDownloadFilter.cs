// *******************************************************************************
// <copyright file="FileDownloadFilter.cs" company="Intuit">
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
    using Newtonsoft.Json;

    /// <summary>
    /// For internal use, converts an id into a filter for selecting the specific <see cref="File"/> to retrieve.
    /// </summary>
    [JsonObject]
    internal class FileDownloadFilter : EntityFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileDownloadFilter"/> class.
        /// </summary>
        /// <param name="id">The id of the file to download.</param>
        internal FileDownloadFilter(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the id of the file to download.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
