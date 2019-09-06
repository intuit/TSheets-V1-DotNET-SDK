// *******************************************************************************
// <copyright file="GetResultsMetaDeserializer.cs" company="Intuit">
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
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A singleton pipeline stage that deserializes paging information from the response from a retrieval operation.
    /// </summary>
    internal class GetResultsMetaDeserializer : PipelineElement<GetResultsMetaDeserializer>
    {
        private const string MoreTokenPath = "more";

        private GetResultsMetaDeserializer()
        {
        }

        /// <summary>
        /// Reads the JSON response and writes to the context object the values
        /// for "More" and "Page", to facilitate paging.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <returns>The completed asynchronous task.</returns>
        protected override Task _ProcessAsync<T>(PipelineContext<T> context, ILogger logger)
        {
            try
            {
                JObject document = JObject.Parse(context.ResponseContent);
                JToken moreToken = document.SelectToken(MoreTokenPath);

                if (moreToken != null)
                {
                    context.ResultsMeta.More = moreToken.Value<bool>();
                }
            }
            finally
            {
                var readContext = (GetContext<T>)context;
                context.ResultsMeta.Page = readContext.Options.Page ?? 1;
            }

            return Task.CompletedTask;
        }
    }
}
