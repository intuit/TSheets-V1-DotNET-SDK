// *******************************************************************************
// <copyright file="PipelineElement.cs" company="Intuit">
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
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for each pipeline stage; a stateless singleton which performs work
    /// on the pipeline context object that is passed in. 
    /// </summary>
    /// <typeparam name="TSingleton">The type of singleton pipeline element.</typeparam>
    internal abstract class PipelineElement<TSingleton> : Singleton<TSingleton>, IPipelineElement
        where TSingleton : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineElement{TSingleton}"/> class.
        /// </summary>
        protected PipelineElement()
        {
            Name = GetType().Name;
        }

        /// <summary>
        /// Gets the name of the pipeline element.
        /// </summary>
        internal string Name { get; }

        /// <summary>
        /// Centralizes trace logging for all pipeline stages.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public virtual async Task ProcessAsync<T>(
            PipelineContext<T> context,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            try
            {
                logger?.LogTrace(
                    context.LogContext.EventId,
                    "{CorrelationId} {Processor}::{Method}(): ENTER",
                    context.LogContext.CorrelationId,
                    Name,
                    nameof(ProcessAsync));

                // Call the derived class' overridden method to perform the "real" work.
                await _ProcessAsync(context, logger, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                // Intentionally logging as Debug here, *not* Error
                // Full Error detail is logged later in the DataService
                logger?.LogDebug(
                    context.LogContext.EventId,
                    e,
                    "{CorrelationId} {Processor}::{Method}(): ERROR",
                    context.LogContext.CorrelationId,
                    Name,
                    nameof(ProcessAsync));

                throw;
            }
            finally
            {
                // Serialize and log the context object itself, but *only* if
                // tracing is enabled - this is very verbose & comprehensive.
                if (logger != null && logger.IsEnabled(LogLevel.Trace))
                {
                    string serializedContext = JsonConvert.SerializeObject(context, Formatting.Indented);

                    logger?.LogTrace(
                        context.LogContext.EventId,
                        "{CorrelationId} {Processor}::{Method}(): {ContextName}\n{Context}",
                        context.LogContext.CorrelationId,
                        Name,
                        nameof(ProcessAsync),
                        nameof(PipelineContext<T>),
                        serializedContext);

                    logger?.LogTrace(
                        context.LogContext.EventId,
                        "{CorrelationId} {Processor}::{Method}(): EXIT",
                        context.LogContext.CorrelationId,
                        Name,
                        nameof(ProcessAsync));
                }
            }
        }

        /// <summary>
        /// Asynchronously process the pipeline context.
        /// </summary>
        /// <typeparam name="T">The type of the data entity.</typeparam>
        /// <param name="context">Contextual information for the request.</param>
        /// <param name="log">The logger.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        protected abstract Task _ProcessAsync<T>(
            PipelineContext<T> context,
            ILogger log,
            CancellationToken cancellationToken);
    }
}
