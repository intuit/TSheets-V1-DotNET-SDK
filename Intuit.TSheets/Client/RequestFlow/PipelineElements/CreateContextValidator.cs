// *******************************************************************************
// <copyright file="CreateContextValidator.cs" company="Intuit">
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
    using System.Linq;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A singleton pipeline stage that validates input data for a "create" operation.
    /// </summary>
    internal class CreateContextValidator : PipelineElement<CreateContextValidator>
    {
        private CreateContextValidator()
        {
        }

        /// <summary>
        /// Ensures validity of the set of data entity items to be created.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <returns>The completed asynchronous task.</returns>
        protected override Task _ProcessAsync<T>(PipelineContext<T> context, ILogger logger)
        {
            var createContext = (CreateContext<T>)context;

            if (createContext.Items == null || !createContext.Items.Any() || createContext.Items.Any(i => i == null))
            {
                throw new BadRequestException("Request cannot contain a null or empty set of items.");
            }

            return Task.CompletedTask;
        }
    }
}
