// *******************************************************************************
// <copyright file="RestClientDeleteHandlerTests.cs" company="Intuit">
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
    using System.Collections.Generic;
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
    public class RestClientDeleteHandlerTests : UnitTestBase
    {
        private RestClientDeleteHandler pipelineElement;
        private Mock<IRestClient> mockRestClient;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = RestClientDeleteHandler.Instance;
            this.mockRestClient = new Mock<IRestClient>(MockBehavior.Strict);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task RestClientDeleteHandler_RestClientIsInvokedWithExpectedInputsAsync()
        {
            var idsToDelete = new List<long> { 1, 2, 3 };

            // rest client Delete() method is called with 3 parameters: 
            // the request id, the endpoint, and the list of id's to delete
            this.mockRestClient
                .Setup(p => p.DeleteAsync(
                    It.Is<EndpointName>(t => t.Equals(EndpointName.Tests)),
                    It.Is<IEnumerable<long>>(s => s.IsEqualTo(idsToDelete)),
                    It.IsAny<LogContext>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response));

            var context = new DeleteContext<BasicTestEntity>(EndpointName.Tests, idsToDelete)
            {
                RestClient = this.mockRestClient.Object
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            this.mockRestClient.VerifyAll();
        }

        [TestMethod, TestCategory("Unit")]
        public async Task RestClientDeleteHandler_RestClientSetsResponseContentPropertyOfContextObjectAsync()
        {
            this.mockRestClient
                .Setup(p => p.DeleteAsync(
                    It.IsAny<EndpointName>(),
                    It.IsAny<IEnumerable<long>>(),
                    It.IsAny<LogContext>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response));

            var context = new DeleteContext<BasicTestEntity>(EndpointName.Tests, new long[] {1})
            {
                RestClient = this.mockRestClient.Object
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default);

            Assert.AreEqual(Response, context.ResponseContent, "Expected response content to be set.");

            this.mockRestClient.VerifyAll();
        }

        private static string Response => @"
        {
          ""results"": {
            ""tests"": {
              ""1355"": {
                ""_status_code"": 200,
                ""_status_message"": ""OK, deleted"",
                ""id"": ""1355""
              },
              ""1357"": {
                ""_status_code"": 200,
                ""_status_message"": ""OK, deleted"",
                ""id"": ""1357""
              }
            }
          }
        }";
    }
}
