// *******************************************************************************
// <copyright file="DeleteResultsDeserializerTests.cs" company="Intuit">
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
    public class DeleteResultsDeserializerTests : UnitTestBase
    {
        private DeleteResultsDeserializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = DeleteResultsDeserializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteResultsSerializer_CorrectlyDeserializesSuccessfulResponseAsync()
        {
            DeleteContext<TestEntity> context = GetDeleteContext<TestEntity>();
            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            const int expectedCount = 0;
            Assert.AreEqual(expectedCount, context.Results.ErrorItems.Count, $"Expected {expectedCount} error results.");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteResultsSerializer_CorrectlyDeserializesResponseWithErrorResultsAsync()
        {
            DeleteContext<TestEntity> context = GetDeleteContextWithErrorItems<TestEntity>();
            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            const int expectedCount = 2;
            Assert.AreEqual(expectedCount, context.Results.ErrorItems.Count, $"Expected {expectedCount} error results.");
        }

        private static DeleteContext<T> GetDeleteContext<T>()
        {
            const string responseContent = @"
            {
              ""results"": {
                ""tests"": {
                  ""135694294"": {
                    ""_status_code"": 200,
                    ""_status_message"": ""OK, deleted"",
                    ""id"": ""135694294""
                  },
                  ""135694494"": {
                    ""_status_code"": 200,
                    ""_status_message"": ""OK, deleted"",
                    ""id"": ""135694494""
                  }
                }
              }
            }";

            return new DeleteContext<T>(EndpointName.Tests, new[]{ 135694294, 135694494 })
            {
                ResponseContent = responseContent
            };
        }

        private static DeleteContext<T> GetDeleteContextWithErrorItems<T>()
        {
            const string responseContent = @"
            {
              ""results"": {
                ""tests"": {
                  ""135694294"": {
                    ""_status_code"": 200,
                    ""_status_message"": ""OK, deleted"",
                    ""id"": ""135694294""
                  },
                  ""135694494"": {
                    ""_status_code"": 404,
                    ""_status_message"": ""Not found"",
                    ""id"": ""135694494""
                  },
                  ""135694495"": {
                    ""_status_code"": 404,
                    ""_status_message"": ""Not found"",
                    ""id"": ""135694495""
                  }
                }
              }
            }";

            return new DeleteContext<T>(EndpointName.Tests, new[]{ 135694294, 135694494, 135694495 })
            {
                ResponseContent = responseContent
            };
        }
    }

}
