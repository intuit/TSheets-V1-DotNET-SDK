// *******************************************************************************
// <copyright file="SchemaGen.cs" company="Intuit">
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

namespace Intuit.TSheets.Tools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using NJsonSchema.Generation;

    /// <summary>
    /// JSON Schema generation tool for the DataEntity classes within the Intuit.TSheets SDK library.
    /// </summary>
    public class SchemaGen
    {
        /// <summary>
        /// Entry point into the schema generation tool.
        /// </summary>
        /// <remarks>
        /// This utility generates JSON schema files (.xsd's) for all public classes found within the provided assembly that
        /// are decorated with the'JsonObject' attribute, and have a name that satisfies the MatchPattern.
        /// File output location is based on the sub-namespace of each type.
        /// </remarks>
        /// <returns>0 if success, else 1</returns>
        public static int Main()
        {
            IConfigurationRoot configuration = GetConfig();

            string assemblyFile = configuration["AssemblyFile"];
            string outputPath = configuration["OutputPath"];
            string rootNamespace = configuration["RootNamespace"];
            string excludeNamespaceCsv = configuration["ExcludeNamespaceCsv"];
            string matchPattern = configuration["MatchPattern"];

            if (string.IsNullOrWhiteSpace(assemblyFile)
                || string.IsNullOrWhiteSpace(outputPath)
                || string.IsNullOrWhiteSpace(rootNamespace)
                || string.IsNullOrWhiteSpace(matchPattern))
            {
                Usage();
                return 1;
            }

            try
            {
                Console.WriteLine("Generating JSON Schemas");
                Console.WriteLine($"Assembly            : {assemblyFile}");
                Console.WriteLine($"OutPath             : {outputPath}");
                Console.WriteLine($"Root Namespace      : {rootNamespace}");
                Console.WriteLine($"Excluded Namespaces : {excludeNamespaceCsv}");
                Console.WriteLine($"Match Pattern       : {matchPattern}");

                GenerateSchemas(assemblyFile, rootNamespace, excludeNamespaceCsv, matchPattern, outputPath);

                Console.WriteLine("\nSchema generation completed successfully.");

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Schema generation failed:\n{e}");
                return 1;
            }
        }

        private static IConfigurationRoot GetConfig()
        {
            // See appsettings.json for settings values.
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        private static void GenerateSchemas(
            string assemblyFile,
            string rootNamespace,
            string excludedNamespaceCsv,
            string matchPattern,
            string outputPath)
        {
            var fileInfo = new FileInfo(assemblyFile);
            Assembly assembly = Assembly.LoadFile(fileInfo.FullName);

            List<string> excludedNamespaces = excludedNamespaceCsv != null
                ? excludedNamespaceCsv.Split(',').ToList()
                : new List<string>();

            // Get a list of all types decorated with the "[JsonObject]" attribute
            // which are in our root namespace (or child namespace beneath it),
            // and not in the list of excluded namespaces.
            List<Type> types = assembly.GetExportedTypes()
                .Where(t => t.FullName != null
                    && t.FullName.StartsWith(rootNamespace)
                    && !excludedNamespaces.Any(e => e.Trim().Equals(t.Namespace))
                    && CustomAttributeData.GetCustomAttributes(t)
                    .Any(a => a.AttributeType.Name.Equals("JsonObjectAttribute"))).ToList();

            // For each type, generate the JSON schema and output to a file
            // if the name of the type satisfies the configured match pattern.
            foreach (Type type in types.Where(t => MatchesPattern(t.FullName, matchPattern)))
            {
                var settings = new JsonSchemaGeneratorSettings
                {
                    FlattenInheritanceHierarchy = true,
                    SerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new SchemaContractResolver(),
                    }
                };

                var generator = new JsonSchemaGenerator(settings);
                var schema = generator.Generate(type);

                string schemaAsJson = schema.ToJson(Formatting.Indented);

                string outFile = GetOutputFilePath(outputPath, rootNamespace, type.Namespace, type.Name);

                WriteSchemaFile(outFile, schemaAsJson);

                Console.WriteLine($"{type.Name} -> {outFile}");
            }
        }

        private static void WriteSchemaFile(string schemaFilePath, string serializedSchema)
        {
            // create the output directory if it doesn't already exist
            string filePath = Path.GetDirectoryName(schemaFilePath);

            if (!string.IsNullOrWhiteSpace(filePath)
                && !Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            File.WriteAllText(schemaFilePath, serializedSchema);
        }

        private static string GetOutputFilePath(
            string basePath,
            string rootNamespace,
            string @namespace,
            string name)
        {
            // strip the leading assembly name portion
            string subPath = @namespace.Replace(rootNamespace, string.Empty).TrimStart('.');

            // and convert into a nested subPath based on the remainder of the namespace sections
            subPath = subPath.Replace(".", @"\");

            return Path.Combine(basePath, subPath, $"{name}.xsd");
        }

        private static bool MatchesPattern(string input, string pattern)
        {
            pattern = "^" + pattern.Replace("*", ".*?");
            return Regex.IsMatch(input, pattern);
        }

        private static void Usage()
        {
            Console.WriteLine($"\nUsage: {nameof(SchemaGen)}.exe");
            Console.WriteLine(@"
This utility generates JSON schema files (.xsd's) for all public classes found within the provided assembly that
are decorated with the ""[JsonObject]"" attribute, and have a name that satisfies the MatchPattern.
File output location is based on the sub-namespace of each type.

To use, first configure the appsettings.json settings file. For example:

    <appSettings>
        <add key=""AssemblyFile"" value=""C:\Your\Path\To\Intuit.TSheets.Data.dll"" />
        <add key=""OutputPath"" value=""C:\Your\Path\For\Output\schemas"" />
        <add key=""RootNamespace"" value=""Intuit.TSheets.Model"" />
        <add key=""ExcludedNamespaces"" value="""" />
        <add key=""MatchPattern"" value=""*"" />
    </appSettings>
");
        }
    }
}
