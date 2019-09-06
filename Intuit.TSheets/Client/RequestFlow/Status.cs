// *******************************************************************************
// <copyright file="Status.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow
{
    using Newtonsoft.Json;

    /// <summary>
    /// The class into which status from a create or update operation,
    /// for each entity in the batch is deserialized.
    /// </summary>
    [JsonObject]
    internal class Status
    {
        /// <summary>
        /// Gets or sets the entity's identifier
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code indicating whether the operation failed or succeeded for this entity
        /// </summary>
        [JsonProperty("_status_code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the descriptive message providing reason for an error
        /// </summary>
        [JsonProperty("_status_message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets extra information (used occasionally)
        /// </summary>
        [JsonProperty("_status_extra")]
        public string Extra { get; set; }

        /// <summary>
        /// Gets or sets warning information (rarely used)
        /// </summary>
        [JsonProperty("_status_warning")]
        public string Warning { get; set; }

        /// <summary>
        /// Gets the value indicating whether a code represents success
        /// </summary>
        internal bool IsSuccess => this.Code < 300;
    }
}
