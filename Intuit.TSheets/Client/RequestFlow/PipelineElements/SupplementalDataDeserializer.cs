// *******************************************************************************
// <copyright file="SupplementalDataDeserializer.cs" company="Intuit">
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
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A singleton pipeline stage that deserializes the supplemental data section of a TSheets API method response.
    /// </summary>
    internal class SupplementalDataDeserializer : PipelineElement<SupplementalDataDeserializer>
    {
        private const string JsonPath = "supplemental_data";

        private SupplementalDataDeserializer()
        {
        }

        /// <summary>
        /// Finds all items within the "supplemental data" of an API JSON response,
        /// and deserializes each into the appropriate entity type, writing back
        /// into the context object.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <param name="context">The object of state through the pipeline.</param>
        /// <param name="logger">The logging instance.</param>
        /// <returns>The completed asynchronous task.</returns>
        protected override Task _ProcessAsync<T>(PipelineContext<T> context, ILogger logger)
        {
            JToken document = JToken.Parse(context.ResponseContent);
            JObject supplementalDataSection = (JObject)document.SelectToken(JsonPath);
            if (supplementalDataSection == null)
            {
                return Task.CompletedTask;
            }

            var sectionItemCount = new Dictionary<string, int>();
            
            // Get the various supplemental data sections, i.e. "users", "jobcodes", etc.
            IEnumerable<JToken> sections = supplementalDataSection.Children();

            var serializer = new JsonSerializer();
            foreach (JToken section in sections)
            {
                // Get a function delegate which knows how to instantiate the correct object
                // for the section we're in - e.g. a User when in "users" section, etc.
                string sectionName = ((JProperty)section).Name;
                Func<IIdentifiable> createInstance = EntityTypeMapper.GetTypeCreator(sectionName);

                // Get all of the items within the section
                IEnumerable<JToken> items = document.SelectTokens($"{section.Path}.*");
                foreach (JToken item in items)
                {
                    // Get a new object instance and "fill" it by deserializing from the json
                    IIdentifiable entity = createInstance();
                    JsonReader reader = ((JObject)item).CreateReader();

                    serializer.Populate(reader, entity);

                    // Write it to our set of all supplemental data objects
                    context.ResultsMeta.SupplementalData.AddOrUpdate(entity);

                    // Maintain some counts for logging purposes
                    if (!sectionItemCount.ContainsKey(sectionName))
                    {
                        sectionItemCount.Add(sectionName, 0);
                    }

                    sectionItemCount[sectionName]++;
                }
            }

            return Task.CompletedTask;
        }
    }
}
