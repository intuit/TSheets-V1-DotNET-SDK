// *******************************************************************************
// <copyright file="SerializationTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class SerializationTests
    {
        [TestMethod, TestCategory("Unit")]
        public void AllEntities_SerializeAndDeserializeCorrectly()
        {
            List<Type> jsonObjectTypes = SerializationTestsHelper.GetJsonObjectTypes();

            string typeName = null;
            try
            {
                foreach (Type type in jsonObjectTypes)
                {
                    typeName = type.Name;
                    SerializationTestsHelper.Test(type);
                }
            }
            catch (Exception e)
            {
                Assert.Fail($"Type {typeName} failed to serialize/deserialize: {e}");
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void AllEntities_AllPublicPropertiesAreMarkedWithExpectedAttributes()
        {
            List<Type> jsonObjectTypes = SerializationTestsHelper.GetJsonObjectTypes();

            foreach (Type type in jsonObjectTypes)
            {
                foreach (PropertyInfo propertyInfo in type.GetProperties(
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    if (propertyInfo.GetCustomAttribute<JsonPropertyAttribute>() == null
                        && propertyInfo.GetCustomAttribute<JsonIgnoreAttribute>() == null)
                    {
                        Assert.Fail($"For type '{type.Name}', property '{propertyInfo.Name}' is missing "
                        + $"{nameof(JsonPropertyAttribute)} or {nameof(JsonIgnoreAttribute)}.");
                    }
                }
            }
        }
    }

    internal static class SerializationTestsHelper
    {
        internal static void Test(Type type)
        {
            var entity = AutoFixture.Create(type);

            string serialized = JsonConvert.SerializeObject(
                entity,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            var deserialized = JsonConvert.DeserializeObject(serialized);

            string serializedAgain = JsonConvert.SerializeObject(
                deserialized,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            Assert.AreEqual(serialized, serializedAgain);
        }

        internal static List<Type> GetJsonObjectTypes()
        {
            const string dataAssemblyName = "Intuit.TSheets";
            const string attributeName = "JsonObjectAttribute";

            Assembly dataAssembly = GetReflectionOnlyAssemblyByName(dataAssemblyName);

            return dataAssembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.ContainsGenericParameters
                     && CustomAttributeData.GetCustomAttributes(t)
                    .Any(a => a.AttributeType.Name.Equals(attributeName))).ToList();
        }

        internal static Assembly GetReflectionOnlyAssemblyByName(string assemblyName)
        {
            AssemblyName dataAssembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .FirstOrDefault(a => a.Name.Equals(assemblyName));

            Assert.IsNotNull(dataAssembly, $"Expected to find reference assembly '{assemblyName}'.");

            return Assembly.Load(dataAssembly.FullName);
        }
    }
}