// *******************************************************************************
// <copyright file="SchemaValidationTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using NJsonSchema.Validation;
    using NJsonSchema;

    internal class SchemaValidationInfo
    {
        internal Type DataType { get; set; }

        internal string SchemaFilePath { get; set; }
    }

    [TestClass]
    public class SchemaValidationTests
    {
        [TestMethod, TestCategory("Unit")]
        [DeploymentItem(@"Intuit.TSheets\Model\Schemas\")]
        public void ValidateJsonObjectSchemas()
        {
            List<string> includedNamespaces = new List<string>
            {
                "Intuit.TSheets.Model",
                "Intuit.TSheets.Model.Filters"
            };

            List<SchemaValidationInfo> validationsInfo = GetSchemaValidationsInfo(includedNamespaces);

            foreach (SchemaValidationInfo validationInfo in validationsInfo)
            {
                ValidateSchema(validationInfo);
            }

            //Check for extra schema files
            List<string> extraSchemaFiles = GetSchemaFiles()
                .Where(f => !validationsInfo.Any(v => v.SchemaFilePath.Equals(f))).ToList();

            if (extraSchemaFiles.Count > 0)
            {
                Assert.Fail("The following extra schema files were found:\n"
                            + String.Join("\n", extraSchemaFiles));
            }
        }

        private static IEnumerable<string> GetSchemaFiles()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return Directory.GetFiles(currentDirectory, "*.xsd", SearchOption.AllDirectories).ToList();
        }

        private static void ValidateSchema(SchemaValidationInfo validationInfo)
        {
            try
            {
                object entity = AutoFixture.Create(validationInfo.DataType);

                if (!File.Exists(validationInfo.SchemaFilePath))
                {
                    Assert.Fail($"Json Schema not found for type '{validationInfo.DataType.FullName}'.\n"
                               + $"Expected to find file: {validationInfo.SchemaFilePath}");
                }

                var schema = JsonSchema.FromFileAsync(validationInfo.SchemaFilePath).GetAwaiter().GetResult();

                var json = JsonConvert.SerializeObject(
                    entity,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                ICollection<ValidationError> errors = schema.Validate(json);

                Assert.IsTrue(errors.Count == 0, $"Json Schema validation failed for type '{validationInfo.DataType.FullName}'.\n"
                    + $"Found {errors.Count} error(s).  See schema file: {validationInfo.SchemaFilePath}");
            }
            catch (Exception e)
            {
                Assert.Fail($"Error {validationInfo.DataType}: {e.Message}");
                throw;
            }
        }

        private List<SchemaValidationInfo> GetSchemaValidationsInfo(
            IReadOnlyCollection<string> includedNamespaces)
        {
            var validationsInfo = new List<SchemaValidationInfo>();

            List<Type> jsonObjectTypes = GetJsonObjectTypes();

            foreach (Type type in jsonObjectTypes.Where(t => includedNamespaces.Any(i => i.Equals(t.Namespace))))
            {
                string schemaFilePath = GetSchemaFilePath("Intuit.TSheets.Model", type.Namespace, type.Name);

                validationsInfo.Add(new SchemaValidationInfo
                {
                    DataType = type,
                    SchemaFilePath = schemaFilePath
                });
            }

            return validationsInfo;
        }

        private static string GetSchemaFilePath(string namespacePrefix, string @namespace, string name)
        {
            // string the leading assembly name portion
            @namespace = @namespace.Replace(namespacePrefix, string.Empty).TrimStart('.');

            string subpath = @namespace.Replace(".", @"\");

            string baseDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(baseDirectory, "Model", "Schemas", subpath, $"{name}.xsd");
        }

        internal List<Type> GetJsonObjectTypes()
        {
            const string dataAssemblyName = "Intuit.TSheets";
            const string attributeName = "JsonObjectAttribute";

            Assembly dataAssembly = GetReflectionOnlyAssemblyByName(dataAssemblyName);

            return dataAssembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && CustomAttributeData.GetCustomAttributes(t)
                    .Any(a => a.AttributeType.Name.Equals(attributeName))).ToList();
        }

        internal Assembly GetReflectionOnlyAssemblyByName(string assemblyName)
        {
            AssemblyName dataAssembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .FirstOrDefault(a => a.Name.Equals(assemblyName));

            Assert.IsNotNull(dataAssembly, $"Expected to find reference assembly '{assemblyName}'.");

            return Assembly.Load(dataAssembly.FullName);
        }
    }
}