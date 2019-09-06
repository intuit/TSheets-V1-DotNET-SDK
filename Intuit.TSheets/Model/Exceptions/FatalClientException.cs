// *******************************************************************************
// <copyright file="FatalClientException.cs" company="Intuit">
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
    /// Exception thrown when an unexpected and otherwise unhandled condition is encountered.
    /// </summary>
    [Serializable]
    public sealed class FatalClientException : ApiClientException
    {
        private const string ErrorMessage = "A fatal error occurred.  See inner exception for details.";

        /// <summary>
        /// Initializes a new instance of the <see cref="FatalClientException"/> class.
        /// </summary>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// </param>
        public FatalClientException(Exception innerException)
            : base(ErrorMessage, innerException)
        {
        }

        private FatalClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}