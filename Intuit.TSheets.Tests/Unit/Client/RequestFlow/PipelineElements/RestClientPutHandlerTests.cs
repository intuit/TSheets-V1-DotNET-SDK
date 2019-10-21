// *******************************************************************************
// <copyright file="RestClientPutHandlerTests.cs" company="Intuit">
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
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Intuit.TSheets.Client.Utilities;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RestClientPutHandlerTests : UnitTestBase
    {
        private RestClientPutHandler pipelineElement;
        private Mock<IRestClient> mockRestClient;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = RestClientPutHandler.Instance;
            this.mockRestClient = new Mock<IRestClient>(MockBehavior.Strict);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task RestClientPutHandler_RestClientIsInvokedWithExpectedInputsAsync()
        {
            UpdateContext<TestEntity> context = GetUpdateContext();

            // rest client Update() method is called with 3 parameters: 
            // the request id, the endpoint, and the serialized request string
            this.mockRestClient
                .Setup(p => p.UpdateAsync(
                    It.Is<EndpointName>(t => t.Equals(EndpointName.Tests)),
                    It.Is<string>(s => s.Equals(Request)),
                    It.IsAny<LogContext>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response));

            context.RestClient = this.mockRestClient.Object;

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            this.mockRestClient.VerifyAll();
        }

        [TestMethod, TestCategory("Unit")]
        public async Task RestClientPutHandler_RestClientSetsResponseContentPropertyOfContextObjectAsync()
        {
            UpdateContext<TestEntity> context = GetUpdateContext();

            this.mockRestClient
                .Setup(p => p.UpdateAsync(
                    It.IsAny<EndpointName>(),
                    It.IsAny<string>(),
                    It.IsAny<LogContext>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response));

            context.RestClient = this.mockRestClient.Object;

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            Assert.AreEqual(Response, context.ResponseContent, "Expected response content to be set.");

            this.mockRestClient.VerifyAll();
        }

        private static UpdateContext<TestEntity> GetUpdateContext() =>
            new UpdateContext<TestEntity>(EndpointName.Tests, new []{ new TestEntity() })
            {
                SerializedRequest = Request
            };


        private static string Request => @"
        {
           ""data"": [
             {
               ""name"": ""jerald"",
               ""employee_id"": ""123"",
               ""manager_of_ids"": [ 11, 19, 21 ]
             },
             {
               ""name"": ""cassidy"",
               ""employee_id"": ""125"",
               ""manager_of_ids"": [ 11 ]
             }
           ]
        }";

        private static string Response => @"
        {
          ""results"": {
            ""tests"": {
              ""25"": {
                ""_status_code"": 200,
                ""_status_message"": ""Updated"",
                ""id"": 25,
                ""name"": ""jerald"",
                ""employee_id"": ""123"",
                ""manager_of_ids"": [ 11, 19, 21 ]
              },
              ""26"": {
                ""_status_code"": 200,
                ""_status_message"": ""Updated"",
                ""id"": 26,
                ""name"": ""cassidy"",
                ""employee_id"": ""125"",
                ""manager_of_ids"": [ 11 ]
              },
            }
          }
        }";
    }

}
