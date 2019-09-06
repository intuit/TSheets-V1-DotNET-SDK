// *******************************************************************************
// <copyright file="PipelineFactoryTests.cs" company="Intuit">
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
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.Pipelines;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PipelineFactoryTests : UnitTestBase
    {
        private PipelineFactory pipelineFactory;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineFactory = PipelineFactory.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineFactory_GivenGetContext_BuildsExpectedPipeline()
        {
            var context = new GetContext<TestEntity>(
                EndpointName.Tests,
                null,
                new RequestOptions
                {
                    IncludeSupplementalData = true,
                    AutoPaging = false
                });

            var pipeline = (RequestPipeline)this.pipelineFactory.GetPipeline(context);

            Type[] expectedElementTypes =
            {
                typeof(RestClientGetHandler),
                typeof(GetResultsDeserializer),
                typeof(GetResultsMetaDeserializer),
                typeof(SupplementalDataDeserializer)
            };

            IPipelineElement[] actualElements = pipeline.PipelineElements.ToArray();

            AssertElements(expectedElementTypes, actualElements);
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineFactory_GivenDownloadContext_BuildsExpectedPipeline()
        {
            var context = new DownloadContext<TestEntity>(
                EndpointName.FilesRaw,
                null);

            var pipeline = (RequestPipeline)this.pipelineFactory.GetPipeline(context);

            Type[] expectedElementTypes =
            {
                typeof(RestClientDownloadHandler)
            };

            IPipelineElement[] actualElements = pipeline.PipelineElements.ToArray();

            AssertElements(expectedElementTypes, actualElements);
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineFactory_GivenGetReportContext_BuildsExpectedPipeline()
        {
            var context = new GetReportContext<TestEntity>(
                EndpointName.CurrentTotalsReports,
                null);

            var pipeline = (RequestPipeline)this.pipelineFactory.GetPipeline(context);
            Type[] expectedElementTypes =
            {
                typeof(GetReportSerializer),
                typeof(RestClientPostHandler),
                typeof(GetReportDeserializer),
                typeof(SupplementalDataDeserializer)
            };

            IPipelineElement[] actualElements = pipeline.PipelineElements.ToArray();

            AssertElements(expectedElementTypes, actualElements);
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineFactory_GivenCreateContextAndPostMethod_BuildsExpectedPipeline()
        {
            const int entityCount = 20;

            var entities = new TestEntity[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = new TestEntity();
            }

            var context = new CreateContext<TestEntity>(
                EndpointName.CurrentTotalsReports,
                entities);

            var pipeline = (RequestPipeline)this.pipelineFactory.GetPipeline(context);

            Type[] expectedElementTypes =
            {
                typeof(CreateContextValidator),
                typeof(CreateRequestSerializer),
                typeof(RestClientPostHandler),
                typeof(ModificationResultsDeserializer),
                typeof(SupplementalDataDeserializer),
                typeof(MultiStatusHandler)
            };

            IPipelineElement[] actualInnerElements = pipeline.PipelineElements.ToArray();

            AssertElements(expectedElementTypes, actualInnerElements);
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineFactory_GivenCreateContextAndPostMethod_BuildsExpectedBatchingPipeline()
        {
            const int entityCount = 55;

            var entities = new TestEntity[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = new TestEntity();
            }

            var context = new CreateContext<TestEntity>(
                EndpointName.CurrentTotalsReports,
                entities);

            var outerPipeline = (RequestPipeline)this.pipelineFactory.GetPipeline(context);

            Type[] expectedOuterElementTypes =
            {
                typeof(AutoBatchingPipeline),
                typeof(MultiStatusHandler)
            };

            IPipelineElement[] actualOuterElements = outerPipeline.PipelineElements.ToArray();

            AssertElements(expectedOuterElementTypes, actualOuterElements);

            // Validate the nested pipeline elements
            var innerPipeline = (RequestPipeline)((AutoBatchingPipeline)actualOuterElements[0]).InnerPipeline;

            Type[] expectedInnerElementTypes =
            {
                typeof(CreateContextValidator),
                typeof(CreateRequestSerializer),
                typeof(RestClientPostHandler),
                typeof(ModificationResultsDeserializer),
                typeof(SupplementalDataDeserializer),
                typeof(MultiStatusHandler)
            };

            IPipelineElement[] actualInnerElements = innerPipeline.PipelineElements.ToArray();

            AssertElements(expectedInnerElementTypes, actualInnerElements);
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineFactory_GivenUpdateContextAndPutMethod_BuildsExpectedPipeline()
        {
            var context = new UpdateContext<TestEntity>(
                EndpointName.CurrentTotalsReports,
                new[] { new TestEntity() });

            var pipeline = (RequestPipeline)this.pipelineFactory.GetPipeline(context);

            Type[] expectedElementTypes =
            {
                typeof(UpdateContextValidator),
                typeof(UpdateRequestSerializer),
                typeof(RestClientPutHandler),
                typeof(ModificationResultsDeserializer),
                typeof(SupplementalDataDeserializer),
                typeof(MultiStatusHandler)
            };

            IPipelineElement[] actualPipelineElements = pipeline.PipelineElements.ToArray();

            AssertElements(expectedElementTypes, actualPipelineElements);
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineFactory_GivenUpdateContextAndPutMethod_BuildsExpectedBatchingPipeline()
        {
            const int entityCount = 55;

            var entities = new TestEntity[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = new TestEntity();
            }

            var context = new UpdateContext<TestEntity>(
                EndpointName.CurrentTotalsReports,
                entities);

            var outerPipeline = (RequestPipeline)this.pipelineFactory.GetPipeline(context);

            Type[] expectedOuterElementTypes =
            {
                typeof(AutoBatchingPipeline),
                typeof(MultiStatusHandler)
            };

            IPipelineElement[] actualOuterElements = outerPipeline.PipelineElements.ToArray();

            AssertElements(expectedOuterElementTypes, actualOuterElements);

            // Validate the nested pipeline elements
            var innerPipeline = (RequestPipeline)((AutoBatchingPipeline)actualOuterElements[0]).InnerPipeline;

            Type[] expectedInnerElementTypes =
            {
                typeof(UpdateContextValidator),
                typeof(UpdateRequestSerializer),
                typeof(RestClientPutHandler),
                typeof(ModificationResultsDeserializer),
                typeof(SupplementalDataDeserializer),
                typeof(MultiStatusHandler)
            };

            IPipelineElement[] actualInnerElements = innerPipeline.PipelineElements.ToArray();

            AssertElements(expectedInnerElementTypes, actualInnerElements);
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineFactory_GivenDeleteContext_BuildsExpectedPipeline()
        {
            var context = new DeleteContext<TestEntity>(
                EndpointName.Tests,
                new[]{ 1, 2, 3 });

            var pipeline = (RequestPipeline)this.pipelineFactory.GetPipeline(context);

            Type[] expectedElementTypes =
            {
                typeof(DeleteContextValidator),
                typeof(RestClientDeleteHandler),
                typeof(DeleteResultsDeserializer),
                typeof(MultiStatusHandler)
            };
            
            IPipelineElement[] actualElements = pipeline.PipelineElements.ToArray();

            AssertElements(expectedElementTypes, actualElements);
        }

        private static void AssertElements(
            IReadOnlyList<Type> expectedElementTypes,
            IReadOnlyList<IPipelineElement> actualElements)
        {
            Assert.AreEqual(
                expectedElementTypes.Count,
                actualElements.Count,
                $"Expected {expectedElementTypes.Count} method elements in the pipeline.");

            for (int i = 0; i < expectedElementTypes.Count; i++)
            {
                Assert.IsInstanceOfType(actualElements[i], expectedElementTypes[i], $"At index {i}.");
            }
        }

    }
}
