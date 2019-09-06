// *******************************************************************************
// <copyright file="UserPermissions.cs" company="Intuit">
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
    using Newtonsoft.Json;

    /// <summary>
    /// UserPermissions, the rights assignable to an individual user.
    /// </summary>
    [JsonObject]
    public class UserPermissions
    {
        /// <summary>
        /// Gets or sets the value indicating whether the user is an administrator (able to perform all changes on the account).
        /// </summary>
        [JsonProperty("admin")]
        public bool? Admin { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is allowed to use mobile devices to record time.
        /// </summary>
        [JsonProperty("mobile")]
        public bool? Mobile { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to view the list of users currently working for the company.
        /// </summary>
        [JsonProperty("status_box")]
        public bool? StatusBox { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to run/view all reports for the company.
        /// </summary>
        [JsonProperty("reports")]
        public bool? Reports { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to create/edit/delete timesheets for anyone in the company.
        /// </summary>
        [JsonProperty("manage_timesheets")]
        public bool? ManageTimesheets { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to manage computer authorization for the company.
        /// </summary>
        [JsonProperty("manage_authorization")]
        public bool? ManageAuthorization { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to create/edit/delete users, groups, and managers for the entire company.
        /// </summary>
        [JsonProperty("manage_users")]
        public bool? ManageUsers { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to completely manage and own timesheets.
        /// </summary>
        [JsonProperty("manage_my_timesheets")]
        public bool? ManageMyTimesheets { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to create/edit/delete jobcodes and custom field items for the entire company.
        /// </summary>
        [JsonProperty("manage_jobcodes")]
        public bool? ManageJobcodes { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to login to apps via PIN.
        /// </summary>
        [JsonProperty("pin_login")]
        public bool? PinLogin { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to run approval reports and approve time for all employees.
        /// </summary>
        [JsonProperty("approve_timesheets")]
        public bool? ApproveTimesheets { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to create/edit/delete events within the schedule for the groups that the user can manage.
        /// </summary>
        [JsonProperty("manage_schedules")]
        public bool? ManageSchedules { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to access the account externally
        /// </summary>
        [JsonProperty("external_access")]
        public bool? ExternalAccess { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to create/edit/delete events within the schedule for only themselves.
        /// </summary>
        [JsonProperty("manage_my_schedule")]
        public bool? ManageMySchedule { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to create/edit/delete events within the schedule for any user in the company.
        /// </summary>
        [JsonProperty("manage_company_schedules")]
        public bool? ManageCompanySchedules { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to view published events within the schedule for any user in the company.
        /// </summary>
        [JsonProperty("view_company_schedules")]
        public bool? ViewCompanySchedules { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to view published events within the schedule for the groups that the user is a member of.
        /// </summary>
        [JsonProperty("view_group_schedules")]
        public bool? ViewGroupSchedules { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is *not* able to create/edit/delete events within the schedule for any user.
        /// </summary>
        [JsonProperty("manage_no_schedules")]
        public bool? ManageNoSchedules { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is able to view published events within the schedule for themselves.
        /// </summary>
        [JsonProperty("view_my_schedules")]
        public bool? ViewMySchedules { get; set; }
    }
}
