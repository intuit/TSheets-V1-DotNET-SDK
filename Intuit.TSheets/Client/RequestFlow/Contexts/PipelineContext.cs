// *******************************************************************************
// <copyright file="PipelineContext.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow.Contexts
{
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Base class providing contextual information as the vehicle of state through the request pipeline.
    /// </summary>
    /// <remarks>
    /// Each stateless pipeline stage reads and/or writes data to the context object before passing
    /// it along to the next stage.
    /// </remarks>
    /// <typeparam name="T">The type of data entity.</typeparam>
    [JsonObject]
    internal abstract class PipelineContext<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineContext{T}"/> class.
        /// </summary>
        /// <param name="methodType">The type of API operation to be performed, <see cref="MethodType"/></param>
        /// <param name="endpointName">The name of the endpoint with which to interact.</param>
        internal PipelineContext(MethodType methodType, EndpointName endpointName)
        {
            MethodType = methodType;
            Endpoint = endpointName;

            int eventId = GetEventId(methodType, endpointName);
            LogContext = new LogContext(eventId);
        }

        /// <summary>
        /// Gets or sets the implementation of the <see cref="IRestClient"/> that will be
        /// used to perform the http call to the TSheets API.
        /// </summary>
        [JsonIgnore]
        public IRestClient RestClient { get; set; }

        /// <summary>
        /// Gets the endpoint with which to interact.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty]
        public EndpointName Endpoint { get; private set; }

        /// <summary>
        /// Gets the type of API operation to be performed, <see cref="MethodType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty]
        public MethodType MethodType { get; private set; }

        /// <summary>
        /// Gets or sets the raw http response string, as returned from the API method call.
        /// </summary>
        [JsonProperty]
        public string ResponseContent { get; set; }

        /// <summary>
        /// Gets or sets metadata about the method call, e.g. page, supplemental data, etc.
        /// </summary>
        [JsonProperty]
        public ResultsMeta ResultsMeta { get; set; } = new ResultsMeta();

        /// <summary>
        /// Gets or sets the <see cref="Results{T}"/> entities resulting from the method call.
        /// </summary>
        [JsonProperty]
        public Results<T> Results { get; set; } = new Results<T>();

        /// <summary>
        /// Gets contextual information about this method call instance, for logging purposes.
        /// </summary>
        [JsonProperty]
        public LogContext LogContext { get; private set; }

        private static int GetEventId(MethodType methodType, EndpointName endpointName)
        {
            return (int)methodType * 1000 + (int)endpointName;
        }
    }
}
