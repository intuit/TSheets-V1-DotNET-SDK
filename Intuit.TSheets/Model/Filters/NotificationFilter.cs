// *******************************************************************************
// <copyright file="NotificationFilter.cs" company="Intuit">
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
    using Newtonsoft.Json;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="Notification"/> entities.
    /// </summary>
    [JsonObject]
    public class NotificationFilter : EntityFilter
    {
        /// <summary>
        /// Gets or sets the notification ids you'd like to filter on. Only notifications with an id set to one of these values will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<int> Ids { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those notifications with a delivery data before this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("delivery_before")]
        public DateTimeOffset? DeliveryBefore { get; set; }

        /// <summary>
        /// Gets or sets the filter for returning only those notifications with a delivery data after this date/time.
        /// </summary>
        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("delivery_after")]
        public DateTimeOffset? DeliveryAfter { get; set; }

        /// <summary>
        /// Gets or sets the user id for filtering results only to those notifications linked.
        /// </summary>
        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the value for filtering by the tracking ID string of a notification. Only those notifications with this message tracking id will be returned.
        /// </summary>
        [JsonProperty("msg_tracking_id")]
        public string MsgTrackingId { get; set; }
    }
}
