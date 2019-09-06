// *******************************************************************************
// <copyright file="MultiStatusHandler.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow.PipelineElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A singleton pipeline stage that throws an exception in the event that one or more
    /// items in a "create" or "update" batch failed.
    /// </summary>
    internal class MultiStatusHandler : PipelineElement<MultiStatusHandler>
    {
        private MultiStatusHandler()
        {
        }

        /// <summary>
        /// If error results exist in the context, maps each error code to a specific exception
        /// type, then builds and throws a <see cref="MultiStatusException{T}"/>, with specific
        /// exceptions nested within.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <returns>The completed asynchronous task.</returns>
        protected override Task _ProcessAsync<T>(PipelineContext<T> context, ILogger logger)
        {
            if (context.Results == null || !context.Results.ErrorItems.Any())
            {
                return Task.CompletedTask;
            }

            var exceptions = new List<ApiException>();
            foreach (ErrorItem<T> errorItem in context.Results.ErrorItems)
            {
                exceptions.Add(ExceptionMapper.Map(errorItem.Code, errorItem.Message, errorItem.Extra));
            }

            throw new MultiStatusException<T>(
                "One or more items in the batch failed. See inner exception for details.",
                new AggregateException(exceptions),
                context.Results);
        }
    }
}
