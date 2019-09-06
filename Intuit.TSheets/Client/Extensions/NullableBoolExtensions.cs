// *******************************************************************************
// <copyright file="NullableBoolExtensions.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Extensions
{
    /// <summary>
    /// For internal use, extension methods for bool?.
    /// </summary>
    internal static class NullableBoolExtensions
    {
        /// <summary>
        /// Returns true if has a value, and the value is true.
        /// </summary>
        /// <param name="input">The value to interpret.</param>
        /// <returns>True or false</returns>
        internal static bool IsTrue(this bool? input)
        {
            return input.HasValue && input.Value;
        }

        /// <summary>
        /// Returns true if null, or has a true value.
        /// </summary>
        /// <param name="input">The value to interpret.</param>
        /// <returns>True or false</returns>
        internal static bool IsTrueOrNull(this bool? input)
        {
            return !input.HasValue || input.Value;
        }
    }
}