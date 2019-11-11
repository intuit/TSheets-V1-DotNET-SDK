// *******************************************************************************
// <copyright file="Notification.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Notification, for pushing messages to employees of your company.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class Notification : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        public Notification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class,
        /// with minimal required parameters to create the new entity. 
        /// </summary>
        /// <param name="userId">
        /// The id for the user that this notification will be sent to.
        /// </param> 
        /// <param name="message">
        /// The message text of the notification.
        /// </param>
        public Notification(int userId, string message)
        {
            UserId = userId;
            Message = message;
        }

        /// <summary>
        /// Gets the id of the notification.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id for the user that this notification will be sent to.
        /// </summary>
        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets the GUID string used for additional tracking.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("msg_tracking_id")]
        public string MsgTrackingId { get; internal set; }

        /// <summary>
        /// Gets or sets the message text of the notification.
        /// </summary>
        /// <remarks>
        /// The maximum message length is 2000 characters.
        /// </remarks>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the transport method of the notification. 
        /// </summary>
        /// <remarks>
        /// See <see cref="NotificationMethod"/> for allowable values.
        /// The 'Push' method utilizes the TSheets mobile app to deliver the notification to a
        /// mobile device. The 'Email' method sends an Email to the user (if they have an Email
        /// address). The 'Dashboard' method utilizes the TSheets web dashboard notification queue
        /// to deliver a notification to the user. They will only see this when they're logged in
        /// to the TSheets web app.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("method")]
        public NotificationMethod? Method { get; set; }

        /// <summary>
        /// Gets or sets the pre-check macro name. 
        /// </summary>
        /// <remarks>
        /// See <see cref="NotificationPrecheckMacro"/> for allowable values.
        /// The 'OnTheClock' macro will first check if the recipient is on the clock before sending
        /// and if not, will discard the notification. The 'OffTheClock' macro will first check if
        /// the recipient is off the clock (and not on PTO) before sending and if not, will discard
        /// the notification. The 'None' macro (the default) will not perform any checks before sending.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("precheck")]
        public NotificationPrecheckMacro? Precheck { get; set; }

        /// <summary>
        /// Gets or sets the date/time when this notification will be delivered.
        /// </summary>
        /// <remarks>
        /// Defaults to the current time.
        /// </remarks>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("delivery_time")]
        public DateTimeOffset? DeliveryTime { get; set; }

        /// <summary>
        /// Gets the date/time when this notification was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }
    }
}
