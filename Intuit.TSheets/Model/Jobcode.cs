// *******************************************************************************
// <copyright file="Jobcode.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Jobcode. Anything you're tracking time against is considered a job code and
    /// includes customers, job sites, work orders, projects, and tasks.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class Jobcode : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Jobcode"/> class.
        /// </summary>
        public Jobcode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jobcode"/> class,
        /// with minimal required parameters to create the new entity. 
        /// </summary>
        /// <param name="name">
        /// Name associated with this jobcode.
        /// </param>
        public Jobcode(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the id of jobcode.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id of the parent of this jobcode.
        /// </summary>
        /// <remarks>
        /// Value is 0 if jobcode is top-level.
        /// </remarks>
        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the jobcode.
        /// </summary>
        /// <remarks>
        /// Cannot be more than 64 characters and must be unique
        /// for all jobcodes that share the same <see cref="ParentId"/>.
        /// </remarks>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviated alias for the jobcode.
        /// </summary>
        /// <remarks>
        /// A shortened code or alias that consists only of letters and numbers.
        /// Must be unique for all jobcodes that share the same <see cref="ParentId"/>.
        /// If the Dial-in Add-on is installed, this field may only consist of number
        /// since it is used for jobcode selection from touch-tone phones.
        /// </remarks>
        [JsonProperty("short_code")]
        public string ShortCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the jobcode.
        /// </summary>
        /// <remarks>
        /// See <see cref="JobcodeType"/> for allowable values. Additional types may be added in the future.
        /// 'PTO' type jobcodes are used for PTO (Paid Time Off, i.e. Vacation, Holiday) time entries. They
        /// are only allowed with a <see cref="ParentId"/> of 0 (i.e. top-level).  'PaidBreak' and
        /// 'UnpaidBreak' type jobcodes are used in conjunction with the Breaks Add-On. These types of
        /// jobcodes may not be created/edited via the API. They are managed via the Breaks Add-On on the web.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public JobcodeType? JobcodeType { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether or not this jobcode is billable.
        /// </summary>
        [JsonProperty("billable")]
        public bool? Billable { get; set; }

        /// <summary>
        /// Gets or sets the billing rate associated with this jobcode.
        /// </summary>
        /// <remarks>
        /// Only effective if billable is true.
        /// </remarks>
        [JsonProperty("billable_rate")]
        public float? BillableRate { get; set; }

        /// <summary>
        /// Gets the value indicating whether or not this jobcode contains child jobcodes.
        /// </summary>
        /// <remarks>
        /// If true, there are jobcodes that exist underneath this one, so this jobcode should
        /// be treated as a container or folder with children jobcodes underneath it.
        /// </remarks>
        [JsonProperty("has_children")]
        public bool? HasChildren { get; internal set; }

        /// <summary>
        /// Gets or sets the value indicating whether or not this jobcode is assigned to all employees.
        /// </summary>
        [JsonProperty("assigned_to_all")]
        public bool? AssignedToAll { get; set; }

        /// <summary>
        /// Gets the ids of custom fields that should be displayed when this jobcode is selected on a timesheet.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("required_customfields")]
        public IReadOnlyList<int> RequiredCustomFields { get; internal set; }

        /// <summary>
        /// Gets the custom field items that are to be displayed when this jobcode is chosen for a timesheet.
        /// </summary>
        /// <remarks>
        /// Each property of the object is a <see cref="CustomField"/> id with its value being an array of
        /// <see cref="CustomFieldItem"/> id. If none, an empty string is returned.
        /// </remarks>
        [NoSerializeOnWrite]
        [JsonProperty("filtered_customfielditems")]
        public IReadOnlyDictionary<string, IReadOnlyList<int>> FilteredCustomFieldItems { get; internal set; }

        /// <summary>
        /// Gets or sets the status of the jobcode.
        /// </summary>
        /// <remarks>
        /// If true, this jobcode is active. If false, this jobcode is archived. To archive a jobcode,
        /// set this field to false.  When a jobcode is archived, any children underneath the jobcode
        /// are archived as well.  When you archive a jobcode, any jobcode assignments or custom field
        /// dependencies are removed. To restore a jobcode, set this field to true. When a jobcode is
        /// restored, any parents of that jobcode are also restored.
        /// </remarks>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets the date/time when this jobcode was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the date/time when this jobcode was created.
        /// </summary>
        [NoSerializeOnWrite] 
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// Gets the list of locations associated with this jobcode.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("locations")]
        public IReadOnlyList<int> Locations { get; internal set; }

        /// <summary>
        /// Gets the id of the project.
        /// </summary>
        [JsonProperty("project_id")]
        public int? ProjectId { get; internal set; }


        /// <summary>
        /// <remarks>
        /// This is a beta feature. Please leave this value null until it is generally available.
        /// </remarks>
        /// Gets or sets the value indicating whether or not this jobcode should be shared with QuickBooks.
        /// </summary>
        [JsonProperty("connect_with_quickbooks")]
        public bool? ConnectWithQuickBooks { get; set; }
    }
}
