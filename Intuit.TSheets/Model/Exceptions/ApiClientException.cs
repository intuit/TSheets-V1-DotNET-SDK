﻿// *******************************************************************************
// <copyright file="ApiClientException.cs" company="Intuit">
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
    /// Common base class for all client-side exceptions (i.e. for HTTP 400-level responses.)
    /// </summary>
    [Serializable]
    public abstract class ApiClientException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientException"/> class.
        /// </summary>
        protected ApiClientException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientException"/> class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// </param>
        protected ApiClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientException"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// The error code value.
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
        protected ApiClientException(int errorCode, string errorText, string message, Exception innerException)
            : base(errorCode, errorText, message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized
        /// object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual
        /// information about the source or destination.
        /// </param>
        protected ApiClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }  
}
