// *******************************************************************************
// <copyright file="ObjectExtensionsTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Extensions
{
    using System;
    using Intuit.TSheets.Client.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ObjectExtensions_ThrowsIfNullMethodThrowsIfObjectIsNull()
        {
            object value = null;
            Assert.ThrowsException<ArgumentNullException>(() => value.ThrowIfNull());
        }
    }
}
