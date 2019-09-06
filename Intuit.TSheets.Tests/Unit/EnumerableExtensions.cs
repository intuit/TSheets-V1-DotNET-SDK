// *******************************************************************************
// <copyright file="EnumerableExtensions.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class EnumerableExtensions
    {
        internal static bool IsEqualTo<T>(this IEnumerable<T> self, IEnumerable<T> other)
        {
            IEnumerable<T> selfArray = self as T[] ?? self.ToArray();
            IEnumerable<T> otherArray = other as T[] ?? other.ToArray();

            return selfArray.Count() == otherArray.Count()
                && selfArray.Intersect(otherArray).Count() == selfArray.Count();
        }
    }

}
