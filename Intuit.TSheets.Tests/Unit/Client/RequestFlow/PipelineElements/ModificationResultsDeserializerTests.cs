// *******************************************************************************
// <copyright file="ModificationResultsDeserializerTests.cs" company="Intuit">
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
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ModificationResultsDeserializerTests : UnitTestBase
    {
        private ModificationResultsDeserializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = ModificationResultsDeserializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public async Task ModificationResultsDeserializer_CorrectlyDeserializesResultsAsync()
        {
            var expectedResult1 = new BasicTestEntity(2735, "Lawrence");
            var expectedResult2 = new BasicTestEntity(2737, "Muriel");

            UpdateContext<BasicTestEntity> context = GetUpdateContext();
            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            const int expectedCount = 2;
            Assert.AreEqual(expectedCount, context.Results.Items.Count, $"Expected {expectedCount} success results.");

            Assert.AreEqual(expectedResult1, context.Results.Items[0],
                "First success result does not match expected.");

            Assert.AreEqual(expectedResult2, context.Results.Items[1],
                "Second success result does not match expected.");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task ModificationResultsDeserializer_CorrectlyDeserializesResultsWithErrorsAsync()
        {
            var expectedErrorStatus1 = new ErrorItem<BasicTestEntity>(
                0,
                new Status
                {
                    Id = 2739,
                    Code = 409,
                    Message = "Conflict",
                    Extra = "User with name Lawrence already exists."
                });

            var expectedErrorResult1 = new BasicTestEntity(2739, "Lawrence");

            var expectedErrorStatus2 = new ErrorItem<BasicTestEntity>(
                0,
                new Status
                {
                    Id = 2741,
                    Code = 417,
                    Message = "Expectation Failed",
                    Extra = "You forgot something."
                });

            UpdateContext<BasicTestEntity> context = GetUpdateContextWithErrorResults();
            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            const int expectedCount = 2;
            Assert.AreEqual(expectedCount, context.Results.ErrorItems.Count, $"Expected {expectedCount} error results.");

            Assert.IsTrue(expectedErrorStatus1.StatusIsEqualTo(context.Results.ErrorItems[0]),
                "First error status does not match expected.");

            Assert.AreEqual(expectedErrorResult1, context.Results.ErrorItems[0].Item,
                "First error item does not match expected.");

            Assert.IsTrue(expectedErrorStatus2.StatusIsEqualTo(context.Results.ErrorItems[1]),
                "Second error status does not match expected.");
        }

        private static UpdateContext<BasicTestEntity> GetUpdateContext()
        {
            const string responseContent = @"
            {
              ""results"": {
                ""tests"": {
                  ""2735"": {
                    ""_status_code"": 200,
                    ""_status_message"": ""Updated"",
                    ""id"": ""2735"",
                    ""name"": ""Lawrence""
                  },
                  ""2737"": {
                    ""_status_code"": 200,
                    ""_status_message"": ""Updated"",
                    ""id"": ""2737"",
                    ""name"": ""Muriel""
                  }
                }
              }
            }";

            var item1 = new BasicTestEntity(2735, "Lawrence");
            var item2 = new BasicTestEntity(2737, "Muriel");

            return new UpdateContext<BasicTestEntity>(EndpointName.Tests, new[]{ item1, item2 })
            {
                ResponseContent = responseContent
            };
        }

        private static UpdateContext<BasicTestEntity> GetUpdateContextWithErrorResults()
        {
            const string responseContent = @"
            {
              ""results"": {
                ""tests"": {
                  ""2739"": {
                    ""_status_code"": 409,
                    ""_status_message"": ""Conflict"",
                    ""_status_extra"":  ""User with name Lawrence already exists."",
                    ""id"": ""2739"",
                    ""name"": ""Lawrence""
                  },
                  ""2741"": {
                    ""_status_code"": 417,
                    ""_status_message"": ""Expectation Failed"",
                    ""_status_extra"": ""You forgot something."",
                    ""id"": ""2741""
                  }
                }
              }
            }";

            var item1 = new BasicTestEntity(2739, "Lawrence");
            var item2 = new BasicTestEntity(2741);

            return new UpdateContext<BasicTestEntity>(EndpointName.Tests, new[]{ item1, item2 })
            {
                ResponseContent = responseContent
            };
        }
    }
}
