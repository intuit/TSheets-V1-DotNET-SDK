// *******************************************************************************
// <copyright file="ManagedClient.cs" company="Intuit">
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

namespace Intuit.TSheets.Model
{
    using System;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// ManagedClient. If you have the External Access add-on installed, you can
    /// make API requests using your auth token against clients that you manage.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class ManagedClient : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the managed client.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets the sub-domain portion of the company URL used by the managed client to sign in to TSheets.
        /// </summary>
        /// <remarks>
        /// Also known as 'Company URL'.
        /// </remarks>
        [JsonProperty("company_url")]
        public string CompanySubDomain { get; internal set; }

        /// <summary>
        /// Gets the name of the managed client's company.
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName { get; internal set; }

        /// <summary>
        /// Gets the value indicating whether the client is active or archived.
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; internal set; }

        /// <summary>
        /// Gets the date/time when this managed client record was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// Gets the date/time when this managed client record was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }
    }
}
