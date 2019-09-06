// *******************************************************************************
// <copyright file="RetrySettings.cs" company="Intuit">
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
    using System;
    using System.Collections.Generic;
    using Intuit.TSheets.Model.Exceptions;

    /// <summary>
    /// Controls retry behavior, intended for use with transient network faults.
    /// </summary>
    /// <remarks>
    /// The number of seconds between retries is given by the formula:
    ///   i^e * m
    /// where i = iteration (aka retry number), e = exponent, m = multiplier.
    /// <para/>
    /// Exponential back-off example:
    /// Given MaxRetryCount = 3, Exponent = 2, and Multiplier = 1
    /// Retries will occur at 1, 4, and 9 seconds after each successive attempt (up to max of 3 retries).
    /// <para/>
    /// Linear retry example: 
    /// Given MaxRetryCount = 3, Exponent = 0, and Multiplier = 5
    /// Retries will occur at 5 seconds after each attempt (up to max of 3 retries).
    /// </remarks>
    public class RetrySettings
    {
        private const int DefaultMaxRetryCount = 3;
        private const float DefaultExponent = 2.0f;
        private const float DefaultMultiplier = 1.0f;

        private static readonly Type RetryServiceUnavailable
            = typeof(ServiceUnavailableException);

        /// <summary>
        /// Initializes a new instance of the <see cref="RetrySettings"/> class.
        /// </summary>
        /// <param name="maxRetryCount">
        /// The maximum number of times to retry.
        /// </param>
        /// <param name="exponent">
        /// For exponential back-off, the power to which the retry iteration will be raised. 
        /// </param>
        /// <param name="multiplier">
        /// Value to multiply for linear scaling of the time between retries.
        /// </param>
        /// <param name="retryTypes">
        /// The Exception types to retry when encountered.
        /// </param>
        public RetrySettings(int maxRetryCount, float exponent, float multiplier, params Type[] retryTypes)
        {
            MaxRetryCount = maxRetryCount;
            Exponent = exponent;
            Multiplier = multiplier;
            RetryTypes = retryTypes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetrySettings"/> class.
        /// </summary>
        internal RetrySettings()
            : this(DefaultMaxRetryCount, DefaultExponent, DefaultMultiplier, RetryServiceUnavailable)
        {
        }

        /// <summary>
        /// Gets the static instance used to disable retries.
        /// </summary>
        public static RetrySettings None { get; }
            = new RetrySettings(0, 0, 0, null);

        /// <summary>
        /// Gets the maximum number of times to retry.
        /// </summary>
        public int MaxRetryCount { get; }

        /// <summary>
        /// Gets the power to which the retry iteration will be raised (for exponential back-off).
        /// </summary>
        public float Exponent { get; }

        /// <summary>
        /// Gets the rate at which to linearly stretch or compress the time between retries.
        /// </summary>
        public float Multiplier { get; }
        
        /// <summary>
        /// Gets the enumerable of Exception types to retry when encountered.
        /// </summary>
        public IEnumerable<Type> RetryTypes { get; }
    }
}