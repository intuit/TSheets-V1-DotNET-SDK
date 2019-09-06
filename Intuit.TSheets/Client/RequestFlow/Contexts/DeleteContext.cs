// *******************************************************************************
// <copyright file="DeleteContext.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow.Contexts
{
    using System.Collections.Generic;
    using System.Linq;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model.Exceptions;
    using Newtonsoft.Json;

    /// <summary>
    /// For a delete operation, provides contextual information as the vehicle of state through the request pipeline.
    /// </summary>
    /// <typeparam name="T">The type of data entity.</typeparam>
    [JsonObject]
    internal class DeleteContext<T> : PipelineContext<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteContext{T}"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint with which to interact.</param>
        /// <param name="ids">The set of ids corresponding to the data entities to be deleted.</param>
        internal DeleteContext(EndpointName endpoint, IEnumerable<int> ids)
            : base(MethodType.Delete, endpoint)
        {
            List<int> listIds = ids?.ToList();
            if (listIds == null || !listIds.Any())
            {
                throw new BadRequestException("Request cannot contain a null or empty set of ids.");
            }

            Ids = listIds;
        }

        /// <summary>
        /// Gets the set of ids corresponding to the data entities to be deleted.
        /// </summary>
        [JsonProperty]
        internal IEnumerable<int> Ids { get; private set; }
    }
}
