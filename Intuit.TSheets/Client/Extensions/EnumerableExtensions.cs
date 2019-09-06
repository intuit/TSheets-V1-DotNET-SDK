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

namespace Intuit.TSheets.Client.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// For internal use, extension methods for IEnumerable&lt;T&gt; objects.
    /// </summary>
    internal static class EnumerableExtensions
    {
        /// <summary>
        /// Given an enumerable of objects of type T, split into batches of given size.
        /// </summary>
        /// <typeparam name="T">The type object to be split into batches.</typeparam>
        /// <param name="source">The set of objects to be split into batches.</param>
        /// <param name="count">The number of items to include in each batch.</param>
        /// <returns>The set of batches.</returns>
        internal static IEnumerable<IEnumerable<T>> MakeBatchesOfSize<T>(this IEnumerable<T> source, int count)
        {
            var batch = new List<T>();
            foreach (T item in source)
            {
                batch.Add(item);
                if (batch.Count == count)
                {
                    yield return batch;
                    batch = new List<T>();
                }
            }

            if (batch.Count != 0)
            {
                yield return batch;
            }
        }
    }
}