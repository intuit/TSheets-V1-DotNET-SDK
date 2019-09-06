// *******************************************************************************
// <copyright file="GetReportDeserializerTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.RequestFlow.PipelineElements
{
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetReportDeserializerTests : UnitTestBase
    {
        private GetReportDeserializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = GetReportDeserializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetReportDeserializer_CorrectlyDeserializesReportAsync()
        {
            var expectedItem0 = new TestReportItem(1234, "Bob", 86.25f);
            var expectedItem1 = new TestReportItem(1237, "Mary", 90.5f);

            GetReportContext<TestReport> context = GetReportContext<TestReport>();
            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            const int expectedCount = 2;
            Assert.AreEqual(expectedCount, context.Results.Report.Count, $"Expected {expectedCount} items in the report.");
            Assert.AreEqual(context.Results.Report[0], expectedItem0);
            Assert.AreEqual(context.Results.Report[1], expectedItem1);
        }

        private static GetReportContext<T> GetReportContext<T>()
        {
            const string responseContent = @"
            {
              ""results"": {
                ""totals"": {
                  ""1234"": {
                    ""id"": 1234,
                    ""name"": ""Bob"",
                    ""sum"": 86.25,
                  },
                  ""1237"": {
                    ""id"": 1237,
                    ""name"": ""Mary"",
                    ""sum"": 90.5,
                  },
                }
              }
            }";

            return new GetReportContext<T>(EndpointName.Tests, null)
            {
                ResponseContent = responseContent
            };
        }
    }
}
