// *******************************************************************************
// <copyright file="ErrorItem.cs" company="Intuit">
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
    using Intuit.TSheets.Client.RequestFlow;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains error information for a single entity from a create or update batch call.
    /// </summary>
    /// <typeparam name="T">The type of data entity.</typeparam>
    [JsonObject]
    public class ErrorItem<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorItem{T}"/> class.
        /// </summary>
        /// <param name="index">The index number of the item in the input batch to which the error applies.</param>
        /// <param name="item">The entity item to which the error applies.</param>
        /// <param name="status">The <see cref="Status"/> object, containing error information.</param>
        internal ErrorItem(int index, T item, Status status)
            : this(index, status)
        {
            Item = item;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorItem{T}"/> class.
        /// </summary>
        /// <param name="index">The index number of the item in the input batch to which the error applies.</param>
        /// <param name="status">The <see cref="Status"/> object, containing error information.</param>
        internal ErrorItem(int index, Status status)
        {
            Index = index;
            Id = status.Id;
            Code = status.Code;
            Message = status.Message;
            Extra = status.Extra;
        }

        /// <summary>
        /// Gets the index number of the item in the input batch to which the error applies.
        /// </summary>
        [JsonProperty]
        public int Index { get; internal set; }

        /// <summary>
        /// Gets the entity item to which the error applies.
        /// </summary>
        /// <remarks>
        /// This value might not be set, depending on the type of error.
        /// </remarks>
        [JsonProperty]
        public T Item { get; }

        /// <summary>
        /// Gets the item's identifier.
        /// </summary>
        [JsonProperty]
        public int Id { get; }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        [JsonProperty]
        public int Code { get; }

        /// <summary>
        /// Gets the descriptive text providing error detail. 
        /// </summary>
        [JsonProperty]
        public string Message { get; }

        /// <summary>
        /// Gets the extra error detail information.
        /// </summary>
        /// <remarks>
        /// This value might not be set, depending on the type of error.
        /// </remarks>
        [JsonProperty]
        public string Extra { get; }
    }
}
