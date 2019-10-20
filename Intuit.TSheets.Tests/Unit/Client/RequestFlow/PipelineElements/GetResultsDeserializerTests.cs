// *******************************************************************************
// <copyright file="GetResultsDeserializerTests.cs" company="Intuit">
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
    public class GetResultsDeserializerTests : UnitTestBase
    {
        private GetResultsDeserializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = GetResultsDeserializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetResultsDeserializer_CorrectlyDeserializesResultsAsync()
        {
            var expectedResult0 = new BasicTestEntity(1, "Larry");
            var expectedResult1 = new BasicTestEntity(2, "Mary");

            GetContext<BasicTestEntity> context = GetContext<BasicTestEntity>();
            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            const int expectedCount = 2;
            Assert.AreEqual(expectedCount, context.Results.Items.Count, $"Expected {expectedCount} results.");
            Assert.AreEqual(context.Results.Items[0], expectedResult0);
            Assert.AreEqual(context.Results.Items[1], expectedResult1);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetResultsDeserializer_CorrectlyDeserializesEmptyResultsAsync()
        {
            var context = new GetContext<BasicTestEntity>(EndpointName.Tests, null, null)
            {
                ResponseContent = @"
                {
                  ""results"": {
                    ""tests"": {
                    }
                  }
                }"
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            const int expectedCount = 0;
            Assert.AreEqual(expectedCount, context.Results.Items.Count, $"Expected {expectedCount} results.");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetResultsDeserializer_CorrectlyDeserializesWhenResultSectionIsMissingAsync()
        {
            var context = new GetContext<BasicTestEntity>(EndpointName.Tests, null, null)
            {
                ResponseContent = @"
                {
                  ""results"": {
                  }
                }"
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            const int expectedCount = 0;
            Assert.AreEqual(expectedCount, context.Results.Items.Count, $"Expected {expectedCount} results.");
        }

        private static GetContext<T> GetContext<T>()
        {
            const string responseContent = @"
            {
              ""results"": {
                ""tests"": {
                  ""1"": {
                    ""Id"": 1,
                    ""name"": ""Larry""
                  },
                  ""2"": {
                    ""Id"": 2,
                    ""name"": ""Mary""
                  },
                }
              }
            }";

            return new GetContext<T>(EndpointName.Tests, null, null)
            {
                ResponseContent = responseContent
            };
        }
    }
}
