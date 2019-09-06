// *******************************************************************************
// <copyright file="ExceptionMapper.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Utilities
{
    using System;
    using Intuit.TSheets.Model.Exceptions;

    /// <summary>
    /// Helper class for mapping error conditions to exceptions.
    /// </summary>
    internal static class ExceptionMapper
    {
        /// <summary>
        /// Maps an HTTP error code to a new instance of its corresponding exception.
        /// </summary>
        /// <remarks>
        /// Overload to simplify unit testing.
        /// </remarks>
        /// <param name="httpCode">The HTTP error code</param>
        /// <returns>An instance of an exception deriving from <see cref="ApiException"/>.</returns>
        internal static ApiException Map(int httpCode)
        {
            return Map(httpCode, string.Empty, string.Empty);
        }

        /// <summary>
        /// Maps an HTTP error code to a new instance of its corresponding exception.
        /// </summary>
        /// <param name="httpCode">The HTTP error code (>=400)</param>
        /// <param name="errorText">The short HTTP code description.</param>
        /// <param name="message">The detailed error message.</param>
        /// <param name="innerException">The optional exception to be nested.</param>
        /// <returns>A derived class instance of an <see cref="ApiException"/> exception.</returns>
        internal static ApiException Map(
            int httpCode,
            string errorText,
            string message,
            Exception innerException = null)
        {
            switch (httpCode)
            {
                case BadRequestException.HttpCode:
                    return new BadRequestException(errorText, message, innerException);

                case UnauthorizedException.HttpCode:
                    return new UnauthorizedException(errorText, message, innerException);

                case BillingNotCurrentException.HttpCode:
                    return new BillingNotCurrentException(errorText, message, innerException);

                case NotFoundException.HttpCode:
                    return new NotFoundException(errorText, message, innerException);

                case MethodNotAllowedException.HttpCode:
                    return new MethodNotAllowedException(errorText, message, innerException);

                case NotAcceptableException.HttpCode:
                    return new NotAcceptableException(errorText, message, innerException);

                case ConflictException.HttpCode:
                    return new ConflictException(errorText, message, innerException);

                case MaxItemsExceededException.HttpCode:
                    return new MaxItemsExceededException(errorText, message, innerException);

                case ExpectationFailedException.HttpCode:
                    return new ExpectationFailedException(errorText, message, innerException);

                case TooManyRequestsException.HttpCode:
                    return new TooManyRequestsException(errorText, message, innerException);

                case InternalServerException.Code:
                    return new InternalServerException(errorText, message, innerException);

                case MethodNotImplementedException.Code:
                    return new MethodNotImplementedException(errorText, message, innerException);

                case ServiceUnavailableException.Code:
                    return new ServiceUnavailableException(errorText, message, innerException);

                default:
                    return new UnmappedApiException(httpCode, errorText, message, innerException);
            }
        }
    }
}
