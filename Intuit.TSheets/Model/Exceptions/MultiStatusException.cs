// *******************************************************************************
// <copyright file="MultiStatusException.cs" company="Intuit">
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

namespace Intuit.TSheets.Model.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.RequestFlow;

    /// <summary>
    /// Exception thrown when one or more items in a batch fails.
    /// </summary>
    /// <typeparam name="T">A business object entity type.</typeparam>
    [Serializable]
    public sealed class MultiStatusException<T> : ApiClientException
    {
        /// <summary>
        /// The HTTP code for a multi-status condition.
        /// </summary>
        internal const int Code = 207;

        /// <summary>
        /// The error text for a multi-status condition.
        /// </summary>
        internal const string ErrorTextValue = "Multi-Status";

        private readonly Results<T> results;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiStatusException{T}"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        /// <param name="results">
        /// An instance of <see cref="Results{T}"/>, contains separate lists of entities
        /// for which the create or update operation succeeded and/or failed.
        /// </param>
        internal MultiStatusException(string message, Exception innerException, Results<T> results)
            : base(Code, ErrorTextValue, message, innerException)
        {
            this.results = results;
        }

        private MultiStatusException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// The list of items for which the create or update operation failed.
        /// </summary>
        public IList<ErrorItem<T>> FailureResults => this.results?.ErrorItems;

        /// <summary>
        /// The list of items for which the create or update operation succeeded.
        /// </summary>
        public IList<T> SuccessResults => this.results?.Items;
    }
}
