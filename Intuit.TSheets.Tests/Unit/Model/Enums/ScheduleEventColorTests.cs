// *******************************************************************************
// <copyright file="ScheduleEventColorTests.cs" company="Intuit">
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
    public class ScheduleEventColorTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ScheduleEventColor_StringValuesAreCorrect()
        {
            const int expectedCount = 24;
            int actualCount = Enum.GetNames(typeof(ScheduleEventColor)).Length;
            Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} enum values.");

            Assert.AreEqual("#BF1959", ScheduleEventColor.Beet.StringValue());
            Assert.AreEqual("#010101", ScheduleEventColor.Black.StringValue());
            Assert.AreEqual("#6A5E72", ScheduleEventColor.BloomyPlum.StringValue());
            Assert.AreEqual("#2196F3", ScheduleEventColor.Blue.StringValue());
            Assert.AreEqual("#78909C", ScheduleEventColor.BlueGrey.StringValue());
            Assert.AreEqual("#785548", ScheduleEventColor.Brown.StringValue());
            Assert.AreEqual("#8A2731", ScheduleEventColor.Crimson.StringValue());
            Assert.AreEqual("#673AB7", ScheduleEventColor.DeepPurple.StringValue());
            Assert.AreEqual("#43A047", ScheduleEventColor.Green.StringValue());
            Assert.AreEqual("#888888", ScheduleEventColor.Grey.StringValue());
            Assert.AreEqual("#3F51B5", ScheduleEventColor.Indigo.StringValue());
            Assert.AreEqual("#A6D5FA", ScheduleEventColor.LightBlue.StringValue());
            Assert.AreEqual("#B3D9B5", ScheduleEventColor.LightGreen.StringValue());
            Assert.AreEqual("#CDC8A2", ScheduleEventColor.LightOlive.StringValue());
            Assert.AreEqual("#F8C499", ScheduleEventColor.LightOrange.StringValue());
            Assert.AreEqual("#D7A8DF", ScheduleEventColor.LightPurple.StringValue());
            Assert.AreEqual("#827717", ScheduleEventColor.Olive.StringValue());
            Assert.AreEqual("#EF6C00", ScheduleEventColor.Orange.StringValue());
            Assert.AreEqual("#E91E63", ScheduleEventColor.Pink.StringValue());
            Assert.AreEqual("#9C27B0", ScheduleEventColor.Purple.StringValue());
            Assert.AreEqual("#F44336", ScheduleEventColor.Red.StringValue());
            Assert.AreEqual("#486B7A", ScheduleEventColor.Slate.StringValue());
            Assert.AreEqual("#009688", ScheduleEventColor.Teal.StringValue());
            Assert.AreEqual("#FAB3AE", ScheduleEventColor.LightRed.StringValue());
        }
    }
}