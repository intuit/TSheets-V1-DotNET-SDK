// *******************************************************************************
// <copyright file="UnmappedApiException.cs" company="Intuit">
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
    using System.Runtime.Serialization;

    /// <summary>
    /// A "backstop" exception to catch HTTP errors that are newly introduced to the API.
    /// </summary>
    [Serializable]
    public sealed class UnmappedApiException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnmappedApiException"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// Error code returned from the API call.
        /// </param>
        /// <param name="errorText">
        /// Short error text returned from the API call.
        /// </param> 
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// </param>
        public UnmappedApiException(int errorCode, string errorText, string message, Exception innerException)
            : base(errorCode, errorText, message, innerException)
        {
        }

        private UnmappedApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
