// *******************************************************************************
// <copyright file="AutoFixture.cs" company="Intuit">
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
using AutoFixture;
using AutoFixture.Kernel;

namespace Intuit.TSheets.Tests.Unit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class AutoFixture
    {
        private const int ListSize = 3;
        private static readonly Fixture InnerFixture = new Fixture();

        internal static object Create(Type t, int depth = 0)
        {
            object instance = Activator.CreateInstance(t);
            PropertyInfo[] propInfos =
                t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo propInfo in propInfos.Where(p => p.CanWrite))
            {
                Type type = propInfo.PropertyType;

                TypeInfo typeInfo = type.GetTypeInfo();
                if (typeInfo.IsClass && type != typeof(string) && type != typeof(Uri))
                {
                    if (propInfo.Name.Equals("Supplemental"))
                    {
                        depth++;
                    }

                    // limit recursion on SupplementalData, else will overflow stack
                    if (depth <= 1)
                    {
                        propInfo.SetValue(instance, Create(type, depth), null);
                    }
                }
                else
                {
                    object data = InnerFixture.Create(type);
                    if (type.IsGenericInterface(typeof(IReadOnlyList<>)))
                    {
                        data = CreateList(typeInfo);
                    }
                    else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>))
                    {
                        data = CreateDictionary(typeInfo);
                    }

                    propInfo.SetValue(instance, data, null);
                }
            }

            return instance;
        }

        public static IList CreateList(TypeInfo typeInfo)
        {
            var listType = typeof(List<>);
            var genericType = typeInfo.GenericTypeArguments[0];
            var constructedListType = listType.MakeGenericType(genericType);
            var constructedList = (IList)Activator.CreateInstance(constructedListType);

            for (int i = 0; i < ListSize; i++)
            {
                object item = genericType.IsClass && genericType != typeof(string)
                    ? Create(genericType)
                    : InnerFixture.Create(genericType);

                constructedList.Add(item);
            }

            return constructedList;
        }

        public static IDictionary CreateDictionary(TypeInfo typeInfo)
        {
            var dictType = typeof(Dictionary<,>);
            var keyType = typeInfo.GenericTypeArguments[0];
            var valueType = typeInfo.GenericTypeArguments[1];
            var constructedDictType = dictType.MakeGenericType(keyType, valueType);
            var constructedDict = (IDictionary)Activator.CreateInstance(constructedDictType);

            for (int i = 0; i < ListSize; i++)
            {
                var key = InnerFixture.Create(keyType);

                dynamic value = null;
                if (valueType.IsGenericInterface(typeof(IReadOnlyList<>)))
                {
                    value = CreateList(valueType.GetTypeInfo());
                }
                else if ((valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>)))
                {
                    value = CreateDictionary(valueType.GetTypeInfo());
                }
                else
                {
                    value = Create(valueType);
                }

                constructedDict.Add(key, value);
            }

            return constructedDict;
        }

        public static object Create(this Fixture fixture, Type type)
        {
            var context = new SpecimenContext(fixture);
            return context.Resolve(type);
        }

        public static bool IsGenericInterface(this Type type, Type interfaceType)
        {
            TypeInfo typeInfo = type.GetTypeInfo();

            return typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == interfaceType;
        }

    }

}
