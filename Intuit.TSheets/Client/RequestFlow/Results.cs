// *******************************************************************************
// <copyright file="Results.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow
{
    using System.Collections.Generic;
    using Intuit.TSheets.Api;
    using Newtonsoft.Json;

    /// <summary>
    /// The container into which results from an API method call are deserialized.
    /// </summary>
    /// <typeparam name="T">The type of data entity.</typeparam>
    [JsonObject]
    internal class Results<T>
    {
        /// <summary>
        /// Gets or sets the list of items that succeeded
        /// </summary>
        [JsonProperty]
        internal List<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// Gets or sets the list of items that failed
        /// </summary>
        [JsonProperty]
        internal List<ErrorItem<T>> ErrorItems { get; set; } = new List<ErrorItem<T>>();
    }
}
