﻿// *******************************************************************************
// <copyright file="TimesheetTypeTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Model.Enums
{
    using System;
    using Intuit.TSheets.Model.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class TimesheetTypeTests
    {
        [TestMethod, TestCategory("Unit")]
        public void TimesheetType_StringValuesAreCorrect()
        {
            const int expectedCount = 3;
            int actualCount = Enum.GetNames(typeof(TimesheetType)).Length;
            Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} enum values.");

            Assert.AreEqual("manual", TimesheetType.Manual.StringValue());
            Assert.AreEqual("regular", TimesheetType.Regular.StringValue());
            Assert.AreEqual("both", TimesheetType.Both.StringValue());
        }
    }
}