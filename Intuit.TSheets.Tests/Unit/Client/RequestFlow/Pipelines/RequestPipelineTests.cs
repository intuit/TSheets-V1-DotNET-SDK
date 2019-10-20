// *******************************************************************************
// <copyright file="RequestPipelineTests.cs" company="Intuit">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.Pipelines;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using System.Threading;

    [TestClass]
    public class RequestPipelineTests : UnitTestBase
    {
        private RequestPipeline requestPipeline;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.requestPipeline = new RequestPipeline();
        }

        [TestMethod, TestCategory("Unit")]
        public void Pipeline_SetsNamePropertyInConstructor()
        {
            Assert.AreEqual(this.requestPipeline.Name, nameof(RequestPipeline),
                "Expected Name property to be set.");
        }

        [TestMethod, TestCategory("Unit")]
        public void Pipeline_CorrectlyAddsStages()
        {
            var pipelineElement1 = new Mock<IPipelineElement>();
            var pipelineElement2 = new Mock<IPipelineElement>();

            this.requestPipeline.AddStage(pipelineElement1.Object, pipelineElement2.Object);

            const int expectedCount = 2;
            Assert.AreEqual(expectedCount, this.requestPipeline.PipelineElements.Count,
                $"Expected {expectedCount} elements to have been added to the pipeline.");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task Pipeline_CallsEachElementInSequenceAsync()
        {
            var context = new GetContext<TestEntity>(EndpointName.Tests, filter: null, options: null);
            var pipelineElement1 = new Mock<IPipelineElement>(MockBehavior.Strict);
            var pipelineElement2 = new Mock<IPipelineElement>(MockBehavior.Strict);

            var callSequence = new List<string>();

            pipelineElement1.Setup(h => h.ProcessAsync(
                It.IsAny<PipelineContext<TestEntity>>(),
                It.IsAny<ILogger>(),
                It.IsAny<CancellationToken>()))
            .Callback((PipelineContext<TestEntity> c, ILogger l, CancellationToken cancellationToken) => callSequence.Add(nameof(pipelineElement1)))
            .Returns(Task.CompletedTask);

            pipelineElement2.Setup(h => h.ProcessAsync(
                It.IsAny<PipelineContext<TestEntity>>(),
                It.IsAny<ILogger>(),
                It.IsAny<CancellationToken>()))
            .Callback((PipelineContext<TestEntity> c, ILogger l, CancellationToken cancellationToken) => callSequence.Add(nameof(pipelineElement2)))
            .Returns(Task.CompletedTask);

            this.requestPipeline.AddStage(pipelineElement1.Object, pipelineElement2.Object);
            await this.requestPipeline.ProcessAsync(context, NullLogger.Instance, default).ConfigureAwait(false);

            Assert.IsTrue(callSequence.First().Equals(nameof(pipelineElement1)), $"Expected {nameof(pipelineElement1)} to be called first.");
            Assert.IsTrue(callSequence.Last().Equals(nameof(pipelineElement2)), $"Expected {nameof(pipelineElement2)} to be called second.");
        }
    }

}
