// *******************************************************************************
// <copyright file="User.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// An employee in your company for which time can be tracked.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class User : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// with minimal required parameters to create the new entity.         
        /// </summary>
        /// <param name="name">UserName associated with this user.</param>
        /// <param name="firstName">First name of user.</param>
        /// <param name="lastName">Last name of user.</param>
        public User(string name, string firstName, string lastName)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Gets the id of this user.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the first name of user.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of user.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the display name of user.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the pronouns name of user.
        /// </summary>
        [JsonProperty("pronouns")]
        public string Pronouns { get; set; }

        /// <summary>
        /// Gets or sets the id of the group this user belongs to.
        /// </summary>
        [JsonProperty("group_id")]
        public long? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether this user is active or archived.
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets the employee number associated with this user.
        /// </summary>
        [JsonProperty("employee_number")]
        public long? EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether or not the user is salaried.
        /// </summary>
        [JsonProperty("salaried")]
        public bool? Salaried { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether or not the user is exempt (i.e. eligible for overtime pay).
        /// </summary>
        [JsonProperty("exempt")]
        public bool? Exempt { get; set; }

        /// <summary>
        /// Gets or sets the user name associated with this user.
        /// </summary>
        [JsonProperty("username")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address associated with this user.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets the value Indicating whether or not the email address has been confirmed by the user.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("email_verified")]
        public bool? EmailVerified { get; internal set; }

        /// <summary>
        /// Gets or sets the payroll id associated with this user
        /// </summary>
        /// <remarks>
        ///  Usually used for linking with external systems.
        /// </remarks>
        [JsonProperty("payroll_id")]
        public string PayrollId { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone number associated with this user.
        /// </summary>
        [JsonProperty("mobile_number")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the date on which this user was hired.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("hire_date")]
        public DateTimeOffset? HireDate { get; set; }

        /// <summary>
        /// Gets or sets the date on which this user was terminated.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("term_date")]
        public DateTimeOffset? TermDate { get; set; }

        /// <summary>
        /// Gets the date/time when this user was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the date/time when this user last performed any action.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_active")]
        public DateTimeOffset? LastActive { get; internal set; }

        /// <summary>
        /// Gets the date/time when this user was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// Gets the sub-domain portion of the client account url identifier associated with this user.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("client_url")]
        public string ClientSubDomain { get; internal set; }

        /// <summary>
        /// Gets the client account name identifier associated with the user.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("company_name")]
        public string CompanyName { get; internal set; }

        /// <summary>
        /// Gets the Url identifier associated with this user's profile image.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("profile_image_url")]
        public Uri ProfileImageUrl { get; internal set; }

        /// <summary>
        /// Gets the list of jobcode identifiers and their respective PTO balances for this user.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("pto_balances")]
        public IReadOnlyDictionary<long, int> PtoBalances { get; internal set; }

        /// <summary>
        /// Gets or sets the latest date up to which this user has submitted timesheets.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("submitted_to")]
        public DateTimeOffset? SubmittedTo { get; set; }

        /// <summary>
        /// Gets or sets the latest date up to which this user has had timesheets approved.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("approved_to")]
        public DateTimeOffset? ApprovedTo { get; set; }

        /// <summary>
        /// Gets the ids of <see cref="Group"/> object this user manages.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("manager_of_group_ids")]
        public IReadOnlyList<long> ManagerOfGroups { get; internal set; }

        /// <summary>
        /// Gets or sets the value indicating whether or not a password change is required.
        /// </summary>
        /// <remarks>
        /// If true, this user will be required to change their password on their next login.
        /// This property is deprecated and will be removed in a future version.
        /// </remarks>
        [Obsolete("This property is deprecated for Create and Update operations.")]
        [JsonProperty("require_password_change")]
        public bool? RequirePasswordChange { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        /// <summary>
        /// May only be set when editing the currently authenticated user (i.e. you may only edit your own password).
        /// </summary>
        [Obsolete("This property is deprecated for Create and Update operations.")]
        [JsonProperty("password")]
        public bool? Password { internal get; set; }

        /// <summary>
        /// Gets or sets the login pin (for logging into a kiosk or similar.)
        /// </summary>
        [JsonProperty("login_pin")]
        public bool? LoginPin { get; set; }

        /// <summary>
        /// Gets the rate of pay associated with this user.
        /// </summary>
        /// <remarks>
        ///  Only visible to admins.
        /// </remarks>
        [NoSerializeOnWrite]
        [JsonProperty("pay_rate")]
        public float? PayRate { get; internal set; }

        /// <summary>
        /// Gets the time frame to which this user's pay rate applies.
        /// </summary>
        /// <remarks>
        /// See <see cref="PayInterval"/> for allowable values.
        /// Only visible to admins.
        /// </remarks>
        [NoSerializeOnWrite]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("pay_interval")]
        public PayInterval? PayInterval { get; internal set; }

        /// <summary>
        /// Gets or sets the permission settings that apply to this user.
        /// </summary>
        [JsonProperty("permissions")]
        public UserPermissions Permissions { get; set; }

        /// <summary>
        /// Gets the <see cref="CustomField"/> items that are associated with the user.
        /// </summary>               
        [NoSerializeOnWrite]
        [JsonProperty("customfields")]
        public IDictionary<string, string> CustomFields { get; internal set; }
    }
}
