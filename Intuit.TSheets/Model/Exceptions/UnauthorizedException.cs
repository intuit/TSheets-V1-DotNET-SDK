// *******************************************************************************
// <copyright file="UnauthorizedException.cs" company="Intuit">
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
    /// Client exception thrown when the user has insufficient permissions to perform the requested action.
    /// </summary>
    [Serializable]
    public sealed class UnauthorizedException : ApiClientException
    {
        /// <summary>
        /// The HTTP code for unauthorized.
        /// </summary>
        internal const int HttpCode = 401;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
        /// </summary>
        /// <param name="errorText">
        /// Short error text returned from the API call.
        /// </param> 
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// </param>
        public UnauthorizedException(string errorText, string message, Exception innerException)
            : base(HttpCode, errorText, message, innerException)
        {
        }

        private UnauthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
