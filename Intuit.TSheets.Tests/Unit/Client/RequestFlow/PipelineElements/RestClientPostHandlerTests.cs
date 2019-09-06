// *******************************************************************************
// <copyright file="RestClientPostHandlerTests.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Utilities;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RestClientPostHandlerTests : UnitTestBase
    {
        private RestClientPostHandler pipelineElement;
        private Mock<IRestClient> mockRestClient;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = RestClientPostHandler.Instance;
            this.mockRestClient = new Mock<IRestClient>(MockBehavior.Strict);
        }


        [TestMethod, TestCategory("Unit")]
        public async Task RestClientPostHandler_RestClientIsInvokedWithExpectedInputsAsync()
        {
            CreateContext<TestEntity> context = GetCreateContext();

            // rest client Create() method is called with 3 parameters: 
            // the request id, the endpoint, and the serialized request string
            this.mockRestClient
                .Setup(p => p.CreateAsync(It.Is<EndpointName>(t => t.Equals(EndpointName.Tests)),
                    It.Is<string>(s => s.Equals(Request)), It.IsAny<LogContext>()))
                .Returns(Task.FromResult(Response));

            context.RestClient = this.mockRestClient.Object;

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            this.mockRestClient.VerifyAll();
        }

        [TestMethod, TestCategory("Unit")]
        public async Task RestClientPostHandler_RestClientSetsResponseContentPropertyOfContextObjectAsync()
        {
            CreateContext<TestEntity> context = GetCreateContext();

            this.mockRestClient
                .Setup(p => p.CreateAsync(It.IsAny<EndpointName>(),
                    It.IsAny<string>(), It.IsAny<LogContext>()))
                .Returns(Task.FromResult(Response));

            context.RestClient = this.mockRestClient.Object;

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            Assert.AreEqual(Response, context.ResponseContent, "Expected response content to be set.");

            this.mockRestClient.VerifyAll();
        }

        private static CreateContext<TestEntity> GetCreateContext() =>
            new CreateContext<TestEntity>(EndpointName.Tests, new[]{ new TestEntity() })
            {
                SerializedRequest = Request
            };


        private static string Request => @"
        {
           ""data"": [
             {
               ""name"": ""jerry"",
               ""employee_id"": ""123"",
               ""manager_of_ids"": [ 11, 19 ]
             },
             {
               ""name"": ""cassie"",
               ""employee_id"": ""125"",
               ""manager_of_ids"": [ ]
             }
           ]
        }";

        private static string Response => @"
        {
          ""results"": {
            ""tests"": {
              ""25"": {
                ""_status_code"": 200,
                ""_status_message"": ""Created"",
                ""id"": 25,
                ""name"": ""jerry"",
                ""employee_id"": ""123"",
                ""manager_of_ids"": [ 11, 19 ]
              },
              ""26"": {
                ""_status_code"": 200,
                ""_status_message"": ""Created"",
                ""id"": 26,
                ""name"": ""cassie"",
                ""employee_id"": ""125"",
                ""manager_of_ids"": [ ]
              },
            }
          }
        }";
    }

}
