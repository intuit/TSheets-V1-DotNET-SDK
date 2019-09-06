// *******************************************************************************
// <copyright file="Request.cs" company="Intuit">
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
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Class for serializing create and update requests into the format expected by the TSheets API
    /// </summary>
    /// <typeparam name="T">The type of data entity</typeparam>
    [JsonObject]
    internal class Request<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request{T}"/> class.
        /// </summary>
        /// <param name="entities">The entities to be serialized.</param>
        internal Request(IEnumerable<T> entities)
        {
            Data = entities != null
                ? entities.ToArray()
                : new T[0];
        }

        /// <summary>
        /// Gets or sets the entities to be serialized.
        /// </summary>
        [JsonProperty("data")]
        public T[] Data { get; set; }
    }
}
