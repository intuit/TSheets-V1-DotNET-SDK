// *******************************************************************************
// <copyright file="LogContext.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Utilities
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// A helper class for passing extra context information to the logger.
    /// </summary>
    /// <remarks>
    /// Class is JsonObject attributed for easy serialization during logging.
    /// </remarks>
    [JsonObject]
    internal class LogContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogContext"/> class.
        /// </summary>
        internal LogContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogContext"/> class.
        /// </summary>
        /// <param name="eventId">
        /// The eventId value for associating a set of events.
        /// </param>
        internal LogContext(int eventId)
        {
            EventId = eventId;
        }

        /// <summary>
        /// Gets the event id value for this log context instance.
        /// </summary>
        [JsonProperty]
        internal int EventId { get; }

        /// <summary>
        /// Gets the unique id value for this log context instance.
        /// </summary>
        [JsonProperty]
        internal string CorrelationId { get; } = GetUniqueId();

        /// <summary>
        /// Get a short id value (unique to the application) for associating all 
        /// log records specific to a single method invocation.
        /// </summary>
        /// <returns>A unique 22-character string</returns>
        private static string GetUniqueId()
            => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=');
    }
}
