// *******************************************************************************
// <copyright file="JobcodeAssignment.cs" company="Intuit">
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
    /// JobcodeAssignment represents that a user has access to a given jobcode for selection while tracking
    /// time. A jobcode is considered assigned if the jobcode has been specifically assigned to a person,
    /// or if the <see cref="Jobcode"/> has the AssignedToAll property set true.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class JobcodeAssignment : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobcodeAssignment"/> class.
        /// </summary>
        public JobcodeAssignment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobcodeAssignment"/> class,
        /// with minimal required parameters to create the new entity. 
        /// </summary>
        /// <param name="userId">
        /// The id of the user to which this assignment pertains.
        /// </param>
        /// <param name="jobcodeId">
        /// The id of the jobcode to which this assignment pertains.
        /// </param> 
        public JobcodeAssignment(int userId, int jobcodeId)
        {
            UserId = userId;
            JobcodeId = jobcodeId;
        }

        /// <summary>
        /// Gets the id of the jobcode assignment.
        /// </summary>
        [NoSerializeOnCreate] 
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id of the user to which this assignment pertains.
        /// </summary>
        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the id of the jobcode that this assignment pertains to.
        /// </summary>
        [JsonProperty("jobcode_id")]
        public int? JobcodeId { get; set; }

        /// <summary>
        /// Gets or sets the status of the jobcode assignment.
        /// </summary>
        /// <remarks>
        /// Whether or not this assignment is 'active'. If false, then the assignment
        /// has been deleted. true means it is in force.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets the date/time when this jobcode assignment was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the date/time when this jobcode assignment was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }
    }
}
