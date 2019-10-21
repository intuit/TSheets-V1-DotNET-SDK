// *******************************************************************************
// <copyright file="DataService_CurrentUserTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Api
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.Pipelines;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class DataServiceTests : UnitTestBase
    {
        protected const int DummyPageNumber = 1;

        private Mock<IPipelineFactory> mockPipelineFactory;
        private Mock<IRestClient> mockRestClient;

        private DataService apiService;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            this.mockPipelineFactory = new Mock<IPipelineFactory>(MockBehavior.Strict);
            this.mockRestClient = new Mock<IRestClient>(MockBehavior.Strict);

            this.apiService = new DataService(
                this.mockPipelineFactory.Object,
                this.mockRestClient.Object,
                MockLogger.Object);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task ExecuteOperationAsync_OperationCanceledExceptionIsUnhandled()
        {
            var mockPipeline = new Mock<IPipeline>(MockBehavior.Strict);

            mockPipeline
                .Setup(h => h.ProcessAsync(
                    It.IsAny<PipelineContext<BasicTestEntity>>(),
                    It.IsAny<ILogger>(),
                    It.IsAny<CancellationToken>()))
                .Callback((PipelineContext<BasicTestEntity> context, ILogger log, CancellationToken cancellationToken) => {
                    cancellationToken.ThrowIfCancellationRequested();
                })
                .Returns(Task.CompletedTask);

            this.mockPipelineFactory
                .Setup(h => h.GetPipeline(
                    It.IsAny<PipelineContext<BasicTestEntity>>()))
                .Returns(mockPipeline.Object);

            var getContext = new GetContext<BasicTestEntity>(EndpointName.Tests, null);

            var tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            try
            {
                await this.apiService.ExecuteOperationAsync(getContext, tokenSource.Token).ConfigureAwait(false);
                Assert.Fail($"Expected {nameof(OperationCanceledException)} to be thrown.");
            }
            catch (OperationCanceledException) { }
        }

        [TestMethod, TestCategory("Unit")]
        public async Task ExecuteOperationAsync_ApiExceptionsAreUnhandled()
        {
            var mockPipeline = new Mock<IPipeline>(MockBehavior.Strict);

            mockPipeline
                .Setup(h => h.ProcessAsync(
                    It.IsAny<PipelineContext<BasicTestEntity>>(),
                    It.IsAny<ILogger>(),
                    It.IsAny<CancellationToken>()))
                .Callback((PipelineContext<BasicTestEntity> context, ILogger log, CancellationToken cancellationToken) => {
                    throw new ConflictException("conflict", "conflict", null);
                })
                .Returns(Task.CompletedTask);

            this.mockPipelineFactory
                .Setup(h => h.GetPipeline(
                    It.IsAny<PipelineContext<BasicTestEntity>>()))
                .Returns(mockPipeline.Object);

            var getContext = new GetContext<BasicTestEntity>(EndpointName.Tests, null);

            var tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            try
            {
                await this.apiService.ExecuteOperationAsync(getContext, tokenSource.Token).ConfigureAwait(false);
                Assert.Fail($"Expected {nameof(ConflictException)} to be thrown.");
            }
            catch (ConflictException) { }
        }

        [TestMethod, TestCategory("Unit")]
        public async Task ExecuteOperationAsync_UnexpectedExceptionIsWrappedInFatalClientException()
        {
            var mockPipeline = new Mock<IPipeline>(MockBehavior.Strict);

            // some unexpected exception
            var innerException = new UnauthorizedAccessException();

            mockPipeline
                .Setup(h => h.ProcessAsync(
                    It.IsAny<PipelineContext<BasicTestEntity>>(),
                    It.IsAny<ILogger>(),
                    It.IsAny<CancellationToken>()))
                .Callback((PipelineContext<BasicTestEntity> context, ILogger log, CancellationToken cancellationToken) => {
                    throw innerException;  
                })
                .Returns(Task.CompletedTask);

            this.mockPipelineFactory
                .Setup(h => h.GetPipeline(
                    It.IsAny<PipelineContext<BasicTestEntity>>()))
                .Returns(mockPipeline.Object);

            var getContext = new GetContext<BasicTestEntity>(EndpointName.Tests, null);

            try
            {
                await this.apiService.ExecuteOperationAsync(getContext, default).ConfigureAwait(false);
                Assert.Fail($"Expected {nameof(FatalClientException)} to be thrown.");
            }
            catch (FatalClientException e)
            {
                Assert.IsInstanceOfType(e.InnerException, innerException.GetType());
            }
        }
    }
}
