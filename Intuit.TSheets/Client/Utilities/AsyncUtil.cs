// *******************************************************************************
// <copyright file="AsyncUtil.cs" company="Intuit">
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
    using System.Threading;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Helper class to synchronously run async processes while
    /// preventing deadlocks that may occur with alternative
    /// approaches, e.g. .GetAwaiter().GetResult()
    /// </summary>
    internal static class AsyncUtil
    {
        private static readonly TaskFactory TaskFactory = new TaskFactory(
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        /// <summary>
        /// Synchronously executes an async method with a T return type
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="task">Task to execute.</param>
        /// <returns>The task result.</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> task)
            => TaskFactory.StartNew(task).Unwrap().GetAwaiter().GetResult();

        /// <summary>
        /// Synchronously executes an async method with a void return type
        /// </summary>
        /// <param name="task">Task to execute</param>
        internal static void RunSync(Func<Task> task)
            => TaskFactory.StartNew(task).Unwrap().GetAwaiter().GetResult();
    }
}
