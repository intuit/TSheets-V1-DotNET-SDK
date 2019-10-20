// *******************************************************************************
// <copyright file="AutoPagingPipelineTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.RequestFlow.Pipelines
{
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.Pipelines;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class AutoPagingPipelineTests : UnitTestBase
    {
        private Mock<IPipeline> mockInnerPipeline;
        private AutoPagingPipeline pipeline;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipeline = new AutoPagingPipeline();
            this.mockInnerPipeline = new Mock<IPipeline>();
        }

        [TestMethod, TestCategory("Unit")]
        public async Task AutoPagingPipelineTests_CorrectlyHandlesMultiplePagesAsync()
        {
            var getContext = new GetContext<BasicTestEntity>(EndpointName.Tests, null, null);

            this.mockInnerPipeline
                .Setup(h => h.ProcessAsync(
                    It.IsAny<PipelineContext<BasicTestEntity>>(),
                    It.IsAny<ILogger>(),
                    It.IsAny<CancellationToken>()))
                .Callback((PipelineContext<BasicTestEntity> context, ILogger log, CancellationToken cancellationToken) => MockHandleTwoPages(context))
                .Returns(Task.CompletedTask);

            this.pipeline.InnerPipeline = this.mockInnerPipeline.Object;

            await this.pipeline.ProcessAsync(getContext, NullLogger.Instance, default).ConfigureAwait(false);

            // inner pipeline should have been called twice
            const int expectedCount = 2;
            Assert.AreEqual(expectedCount, this.mockInnerPipeline.Invocations.Count,
                $"Expected the inner pipeline to have been called {expectedCount} times.");

            Assert.AreEqual(expectedCount, getContext.Results.Items.Count,
                $"Expected {expectedCount} result items.");

            Assert.IsFalse(getContext.ResultsMeta.More, "Expected no more pages.");

            Assert.AreEqual(expectedCount, getContext.Options.Page,
                $"Expected final page request to be for page {expectedCount}.");
        }

        private static void MockHandleTwoPages(PipelineContext<BasicTestEntity> context)
        {
            var getContext = (GetContext<BasicTestEntity>)context;
            getContext.Results = new Results<BasicTestEntity>();

            if (!getContext.Options.Page.HasValue || getContext.Options.Page == 1)
            {
                getContext.Results.Items.Add(new BasicTestEntity(1, "Bob"));

                // causes the auto paging pipeline to make a call for the next page.
                getContext.ResultsMeta.More = true;
                getContext.ResultsMeta.Page = 1;
            }
            else
            {
                const int expectedPage = 2;
                Assert.AreEqual(expectedPage, getContext.Options.Page, $"Expected page {expectedPage}.");
                getContext.Results.Items.Add(new BasicTestEntity(2, "Luane"));

                // causes the auto paging pipeline stop making calls.
                getContext.ResultsMeta.More = false;
            }
        }
    }
}
