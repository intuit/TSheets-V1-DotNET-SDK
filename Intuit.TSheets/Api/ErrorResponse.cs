// *******************************************************************************
// <copyright file="ErrorResponse.cs" company="Intuit">
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

namespace Intuit.TSheets.Api
{
    using Newtonsoft.Json;

    /// <summary>
    /// Used internally, a transitory class for deserializing error response bodies from API calls.
    /// </summary>
    [JsonObject]
    internal class ErrorResponse
    {
        /// <summary>
        /// Gets or sets an instance of <see cref="ErrorResponseDetail"/>, contains error code and message.
        /// </summary>
        [JsonProperty("error")]
        public ErrorResponseDetail ErrorDetail { get; internal set; }
    }
}