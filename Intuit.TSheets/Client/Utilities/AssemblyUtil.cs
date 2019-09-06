// *******************************************************************************
// <copyright file="AssemblyUtil.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Utilities
{
    using System;
    using System.Reflection;
    
    /// <summary>
    /// Helper class for retrieving information about the currently executing assembly.
    /// </summary>
    internal static class AssemblyUtil
    {
        /// <summary>
        /// Returns the value specified in the AssemblyVersion attribute (in AssemblyInfo.cs)
        /// </summary>
        /// <returns>The assembly version string.</returns>
        public static string GetProductVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;

            return version.ToString();
        }
    }
}
