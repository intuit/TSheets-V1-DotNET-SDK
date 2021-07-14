// *******************************************************************************
// <copyright file="Invitation.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Invitation, for inviting users to your company.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class Invitation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invitation"/> class.
        /// </summary>
        public Invitation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Invitation"/> class,
        /// with minimal required parameters to create the new entity.         
        /// </summary>
        /// <param name="contactMethod">
        /// The method to be used for the invitation.
        /// </param>
        /// <param name="contactInfo">
        /// The user contact information.
        /// </param>
        /// <param name="userId">
        /// The id of the user for which the invitation is to be sent.
        /// </param>
        public Invitation(InvitationContactMethod contactMethod, string contactInfo, long userId)
        {
            ContactMethod = contactMethod;
            ContactInfo = contactInfo;
            UserId = userId;
        }

        /// <summary>
        /// Gets or sets the method to be used for the invitation.
        /// </summary>
        /// <remarks>
        /// See <see cref="InvitationContactMethod"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("contact_method")]
        public InvitationContactMethod? ContactMethod { get; set; }

        /// <summary>
        /// Gets or sets the user contact information.
        /// </summary>
        /// <remarks>
        /// Email address or mobile phone number matching the type specified by the <see cref="ContactMethod"/> parameter.
        /// </remarks>
        [JsonProperty("contact_info")]
        public string ContactInfo { get; set; }

        /// <summary>
        /// Gets or sets the id of the user for which the invitation is to be sent.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}
