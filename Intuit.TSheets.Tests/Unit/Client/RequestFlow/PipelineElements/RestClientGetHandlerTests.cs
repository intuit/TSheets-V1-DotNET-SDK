// *******************************************************************************
// <copyright file="RestClientGetHandlerTests.cs" company="Intuit">
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
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Intuit.TSheets.Client.Utilities;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RestClientGetHandlerTests : UnitTestBase
    {
        private RestClientGetHandler pipelineElement;
        private Mock<IRestClient> mockRestClient;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = RestClientGetHandler.Instance;
            this.mockRestClient = new Mock<IRestClient>(MockBehavior.Strict);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task RestClientGetHandler_RestClientIsInvokedWithExpectedInputsAsync()
        {
            GetContext<BasicTestEntity> context = GetContext();

            // rest client Get() method is called with 3 parameters: 
            // the request id, the endpoint, and the dictionary of filter settings
            this.mockRestClient
                .Setup(p => p.GetAsync(
                    It.Is<EndpointName>(t => t.Equals(EndpointName.Tests)),
                    It.Is<Dictionary<string, string>>(s => s.IsEqualTo(ExpectedFilters)),
                    It.IsAny<LogContext>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response));

            context.RestClient = this.mockRestClient.Object;

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            this.mockRestClient.VerifyAll();
        }

        [TestMethod, TestCategory("Unit")]
        public async Task RestClientGetHandler_RestClientSetsResponseContentPropertyOfContextObjectAsync()
        {
            this.mockRestClient
                .Setup(p => p.GetAsync(
                    It.IsAny<EndpointName>(),
                    It.IsAny<Dictionary<string, string>>(),
                    It.IsAny<LogContext>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Response));

            GetContext<BasicTestEntity> context = GetContext();
            context.RestClient = this.mockRestClient.Object;

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            Assert.AreEqual(Response, context.ResponseContent, "Expected response content to be set.");

            this.mockRestClient.VerifyAll();
        }

        private static GetContext<BasicTestEntity> GetContext()
        {
            var filter = new BasicTestEntityFilter
            {
                Ids = new[] { 1, 2, 3 },
                Name = "B*"
            };

            var options = new RequestOptions
            {
                AutoPaging = true,
                IncludeSupplementalData = false,
                Page = 1,
                PerPage = 10
            };

            return new GetContext<BasicTestEntity>(EndpointName.Tests, filter, options);
        }

        private static Dictionary<string, string> ExpectedFilters =>
            new Dictionary<string, string>
            {
                { "ids", "1,2,3" },
                { "name", "B*" },
                { "supplemental_data", "no" },
                { "per_page", "10" },
                { "page", "1" }
            };

        private static string Response => @"
        {
          ""results"": {
            ""tests"": {
              ""1"": {
                ""id"": 1,
                ""name"": ""Larry""
              },
              ""2"": {
                ""id"": 2,
                ""name"": ""Mary""
              },
            }
          }
        }";
    }
}
