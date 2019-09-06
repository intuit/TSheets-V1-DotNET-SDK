// *******************************************************************************
// <copyright file="EnumerableExtensionsTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Intuit.TSheets.Client.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EnumerableExtensionsTests
    {
        [TestMethod, TestCategory("Unit")]
        public void MakeBatchesOf_MakesBatchesOfExpectedSize()
        {
            const int totalItemCount = 7;
            const int batchSize = 3;
            int expectedBatchCount = (int) Math.Ceiling((float) totalItemCount / batchSize);

            var items = new int[totalItemCount];
            for (int i = 0; i < totalItemCount; i++)
            {
                items[i] = i;
            }

            List<IEnumerable<int>> batches = items.MakeBatchesOfSize(batchSize).ToList();

            Assert.AreEqual(expectedBatchCount, batches.Count, $"Expected {expectedBatchCount} batches.");

            // Validate each batch
            for (int i = 0; i < expectedBatchCount - 1; i++)
            {
                Assert.AreEqual(batchSize, batches[i].Count(), $"Expected {batchSize} items in the batch.");
            }

            // Validate final batch
            int expectedFinalBatchCount = totalItemCount % batchSize;
            if (expectedFinalBatchCount > 0)
            {
                Assert.AreEqual(expectedFinalBatchCount, batches.Last().Count(),
                    $"Expected {batchSize} items in the final batch.");
            }
        }
    }
}
