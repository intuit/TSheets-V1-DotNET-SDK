// *******************************************************************************
// <copyright file="Group.cs" company="Intuit">
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
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// Group, for categorization of employees. Each employee may belong to
    /// one and only one group at any time.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class Group : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Group"/> class.
        /// </summary>
        public Group()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Group"/> class,
        /// with minimal required parameters to create the new entity. 
        /// </summary>
        /// <param name="name">
        /// Name associated with this group.
        /// </param>
        public Group(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the id of this group.
        /// </summary>
        [NoSerializeOnCreate] 
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the value indicating whether this group is active or archived.
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets this group's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of id's of the users allowed to manage this group.
        /// </summary>
        [JsonProperty("manager_ids")]
        public IList<int> ManagerIds { get; set; }

        /// <summary>
        /// Gets the date/time when this group was created.
        /// </summary>
        [JsonProperty("created")]
        [NoSerializeOnWrite]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// Gets the date/time when this group was last modified.
        /// </summary>
        [JsonProperty("last_modified")]
        [NoSerializeOnWrite]
        public DateTimeOffset? LastModified { get; internal set; }
    }
}
