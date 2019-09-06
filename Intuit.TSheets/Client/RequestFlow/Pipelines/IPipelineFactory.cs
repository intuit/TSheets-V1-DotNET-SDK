// *******************************************************************************
// <copyright file="IPipelineFactory.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow.Pipelines
{
    using Intuit.TSheets.Client.RequestFlow.Contexts;

    /// <summary>
    /// Interface for generation of a request pipeline, each element of which will
    /// perform a single action in the sequence of performing a REST API call.
    /// </summary>
    /// <remarks>
    /// Exists for the purpose of unit test dependency injection.
    /// </remarks>
    internal interface IPipelineFactory
    {
        /// <summary>
        /// Returns a request pipeline.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <returns>
        /// An instance of an <see cref="IPipeline"/>, which when invoked processes the entire API method call.
        /// </returns>
        IPipeline GetPipeline<T>(PipelineContext<T> context);
    }
}
