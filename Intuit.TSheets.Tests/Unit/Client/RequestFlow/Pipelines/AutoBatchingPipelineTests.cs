// *******************************************************************************
// <copyright file="AutoBatchingPipelineTests.cs" company="Intuit">
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.Pipelines;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class AutoBatchingPipelineTests : UnitTestBase
    {
        private const int MaxBatchSize = 50;
        private const int CountOfEntitiesToCreate = 53;

        private Mock<IPipeline> mockInnerPipeline;
        private AutoBatchingPipeline pipeline;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.mockInnerPipeline = new Mock<IPipeline>();
            this.pipeline = new AutoBatchingPipeline(this.mockInnerPipeline.Object);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task AutoBatchingPipelineTests_CorrectlySplitsBatches()
        {
            var getContext = GetContext();

            this.mockInnerPipeline
                .Setup(h => h.ProcessAsync(
                    It.IsAny<PipelineContext<BasicTestEntity>>(),
                    It.IsAny<ILogger>(),
                    It.IsAny<CancellationToken>()))
                .Callback((PipelineContext<BasicTestEntity> context, ILogger log, CancellationToken cancellationToken) => MockHandleTwoBatches(context))
                .Returns(Task.CompletedTask);

            this.pipeline.InnerPipeline = this.mockInnerPipeline.Object;

            await this.pipeline.ProcessAsync(getContext, NullLogger.Instance, default).ConfigureAwait(false);

            // inner pipeline should have been called twice
            int expectedBatchCount = (int)Math.Ceiling((float)CountOfEntitiesToCreate / MaxBatchSize);
            Assert.AreEqual(expectedBatchCount, this.mockInnerPipeline.Invocations.Count,
                $"Expected the inner pipeline to have been called {expectedBatchCount} times.");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task AutoBatchingPipelineTests_ThrowsWhenCancellationIsRequested()
        {
            var getContext = GetContext();

            var tokenSource = new CancellationTokenSource();

            // setup the inner pipeline element to cancel during processing of the first batch
            this.mockInnerPipeline
                .Setup(h => h.ProcessAsync(
                    It.IsAny<PipelineContext<BasicTestEntity>>(),
                    It.IsAny<ILogger>(),
                    It.IsAny<CancellationToken>()))
                .Callback((PipelineContext<BasicTestEntity> context, ILogger log, CancellationToken cancellationToken) => tokenSource.Cancel())
                .Returns(Task.CompletedTask);

            this.pipeline.InnerPipeline = this.mockInnerPipeline.Object;

            try
            {
                await this.pipeline.ProcessAsync(getContext, NullLogger.Instance, tokenSource.Token).ConfigureAwait(false);
                Assert.Fail($"Expected {nameof(OperationCanceledException)} to be thrown.");
            }
            catch (OperationCanceledException) { }
        }

        private static CreateContext<BasicTestEntity> GetContext()
        {
            var entities = new List<BasicTestEntity>(CountOfEntitiesToCreate);
            for (int i = 0; i < CountOfEntitiesToCreate; i++)
            {
                entities.Add((BasicTestEntity)AutoFixture.Create(typeof(BasicTestEntity)));
            }

            return new CreateContext<BasicTestEntity>(EndpointName.Tests, entities);
        }

        private static void MockHandleTwoBatches(PipelineContext<BasicTestEntity> context)
        {
            const int partialBatchSize = CountOfEntitiesToCreate % MaxBatchSize;

            var createContext = (CreateContext<BasicTestEntity>)context;

            int batchSize = createContext.Items.Count();

            Assert.IsTrue(batchSize == MaxBatchSize || batchSize == partialBatchSize,
                $"Unexpected batch to be of size {MaxBatchSize} or {partialBatchSize} (final batch).");
        }
    }
}
