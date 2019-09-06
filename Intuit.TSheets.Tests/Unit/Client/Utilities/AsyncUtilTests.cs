// *******************************************************************************
// <copyright file="AsyncUtilTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Utilities
{
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AsyncUtilTests
    {
        private bool testMethodCalled;
  
        [TestMethod, TestCategory("Unit")]
        public void AsyncUtil_SynchronouslyRunsMethodWithVoidReturn()
        {
            AsyncUtil.RunSync(() => TestMethodAsync());

            Assert.IsTrue(this.testMethodCalled);
        }

        [TestMethod, TestCategory("Unit")]
        public void AsyncUtil_SynchronouslyRunsMethodWithReturnValue()
        {
            bool result = AsyncUtil.RunSync(() => TestMethodWithReturnValueAsync());

            Assert.IsTrue(result);
        }

        private async Task TestMethodAsync()
        {
            this.testMethodCalled = true;

            await Task.CompletedTask;
        }

        private async Task<bool> TestMethodWithReturnValueAsync()
        {
            return await Task.FromResult(true);
        }
    }
}
