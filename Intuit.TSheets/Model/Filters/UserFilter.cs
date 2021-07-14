// *******************************************************************************
// <copyright file="UserFilter.cs" company="Intuit">
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
    using System;
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="User"/> entities.
    /// </summary>
    [JsonObject]
    public class UserFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)] 
        [JsonProperty("ids")]
        public IEnumerable<long> Ids { get; set; }

        /// <summary>
        /// Gets or sets the ids you'd like to exclude.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("not_ids")]
        public IEnumerable<long> NotIds { get; set; }

        /// <summary>
        /// Gets or sets the employee numbers you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("employee_numbers")]
        public IEnumerable<long> EmployeeNumbers { get; set; }

        /// <summary>
        /// Gets or sets the user names you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("usernames")]
        public IEnumerable<string> UserNames { get; set; }

        /// <summary>
        /// Gets or sets the group ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("group_ids")]
        public IEnumerable<long> GroupIds { get; set; }

        /// <summary>
        /// Gets or sets the group ids you'd like to exclude.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("not_group_ids")]
        public IEnumerable<long> NotGroupIds { get; set; }

        /// <summary>
        /// Gets or sets the payroll ids you'd like to filter on. Only users with these payroll ids will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("payroll_ids")]
        public IEnumerable<long> PayrollIds { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to filter by active or inactive state, or both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("active")]
        public TristateChoice? Active { get; set; }

        /// <summary>
        /// Gets or sets the wildcard-able filter on the users' first name.
        /// </summary>
        /// <remarks>
        /// * will be interpreted as a wild card. Starts matching from the beginning of the string.
        /// </remarks>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the wildcard-able filter on the users' last name.
        /// </summary>
        /// <remarks>
        /// * will be interpreted as a wild card. Starts matching from the beginning of the string.
        /// </remarks>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those users modified before this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_before")]
        public DateTimeOffset? ModifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those users modified after this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("modified_since")]
        public DateTimeOffset? ModifiedSince { get; set; }
    }
}
