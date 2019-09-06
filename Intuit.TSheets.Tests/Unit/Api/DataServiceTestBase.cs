// *******************************************************************************
// <copyright file="DataServiceTestBase.cs" company="Intuit">
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
    using System.Linq;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.Pipelines;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [Flags]
    public enum Params
    {
        None = 0x0,
        Filter = 0x1,
        RequestOptions = 0x10
    }

    public abstract class DataServiceTestBase : UnitTestBase
    {
        protected const int DummyPageNumber = 1;

        private Mock<IPipelineFactory> mockPipelineFactory;
        private Mock<IPipeline> mockPipeline;
        private Mock<IRestClient> mockRestClient;
        private Mock<ILogger> mockLogger;

        protected IDataService ApiService { get; private set; }

        protected RequestOptions DummyRequestOptions { get; private set; }

        protected ResultsMeta DummyResultsMeta => new ResultsMeta
        {
            Page = DummyPageNumber
        };

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            this.DummyRequestOptions = new TestRequestOptions(TestContext.TestName);

            this.mockPipelineFactory = new Mock<IPipelineFactory>();
            this.mockPipeline = new Mock<IPipeline>();
            this.mockRestClient = new Mock<IRestClient>();
            this.mockLogger = new Mock<ILogger>();

            ApiService = new DataService(
                this.mockPipelineFactory.Object,
                this.mockRestClient.Object,
                this.mockLogger.Object);
        }

        internal void ExpectGet<T>(EndpointName endpoint, Params expect)
            where T : new()
        {
            SetupAsyncMocks<T, GetContext<T>>(endpoint, expect);
        }

        internal void ExpectGetReport<T>(EndpointName endpoint, Params expect)
            where T : new()
        {
            SetupAsyncMocks<T, GetReportContext<T>>(endpoint, expect);
        }

        internal void ExpectCreate<T>(EndpointName endpoint)
            where T : new()
        {
            SetupAsyncMocks<T, CreateContext<T>>(endpoint, Params.None);
        }

        internal void ExpectUpdate<T>(EndpointName endpoint)
            where T : new()
        {
            SetupAsyncMocks<T, UpdateContext<T>>(endpoint, Params.None);
        }

        internal void ExpectDownload<T>(EndpointName endpoint)
            where T : new()
        {
            SetupAsyncMocks<T, DownloadContext<T>>(endpoint, Params.None);
        }

        internal void ExpectDelete<T>(EndpointName endpoint)
            where T : new()
        {
            SetupAsyncMocks<T, DeleteContext<T>>(endpoint, Params.None);
        }

        private void SetupAsyncMocks<TEntity, TContext>(EndpointName endpoint, Params expect)
            where TEntity : new()
            where TContext : PipelineContext<TEntity>
        {
            this.mockPipeline
                .Setup(f => f.ProcessAsync(It.IsAny<TContext>(), It.IsAny<ILogger>()))
                .Callback((PipelineContext<TEntity> context, ILogger log) =>
                    Process(context, endpoint, expect))
                .Returns(Task.CompletedTask);

            SetupPipelineFactoryMock<TEntity>();
        }

        private void SetupPipelineFactoryMock<T>()
        {
            this.mockPipelineFactory
                .Setup(f => f.GetPipeline(It.IsAny<PipelineContext<T>>()))
                .Returns(this.mockPipeline.Object);
        }

        internal virtual void Process<T>(PipelineContext<T> context, EndpointName endpoint, Params expect)
            where T : new()
        {
            Assert.AreEqual(
                endpoint, context.Endpoint,
                $"Expected Endpoint property of context object to be '{endpoint}'");
            
            switch (context)
            {
                case GetContext<T> _:
                    VerifyFilter(context, expect);
                    break;

                case GetReportContext<T> reportContext:
                    reportContext.Results = new T();
                    VerifyFilter(context, expect);
                    break;

                case CreateContext<T> _:
                    VerifyItemsToCreate(context);
                    break;

                case UpdateContext<T> _:
                    VerifyItemsToUpdate(context);
                    break;

                case DeleteContext<T> _:
                    VerifyIdsToDelete(context);
                    break;
            }

            // Set the method results, to be validated in the TestMethod
            context.ResultsMeta = DummyResultsMeta;
            context.Results.Items.Add(new T());
        }

        protected virtual void VerifyResult<T>((T, ResultsMeta) result)
        {
            VerifyMocks();

            (T entity, ResultsMeta resultsMeta) = result;
            Assert.IsNotNull(entity, $"Expected {typeof(T)} result item.");

            Assert.AreEqual(DummyResultsMeta.Page, resultsMeta?.Page, $"Expected {nameof(ResultsMeta)} output parameter to be set.");
        }

        protected virtual void VerifyResult<T>(T entity)
        {
            VerifyMocks();

            Assert.IsNotNull(entity, $"Expected {typeof(T)} result item.");
        }

        protected virtual void VerifyMocks()
        {
            this.mockPipelineFactory.VerifyAll();
            this.mockPipeline.VerifyAll();
            this.mockRestClient.VerifyAll();
            this.mockLogger.VerifyAll();
        }

        internal virtual void VerifyFilter<T>(PipelineContext<T> context, Params expect)
        {
            int filterCount = 0;
            switch (context)
            {
                case GetContext<T> getContext:
                    filterCount = getContext.Filter.GetFilters().Count;
                    break;

                case GetReportContext<T> getReportContext:
                    filterCount = getReportContext.Filter.GetFilters().Count;
                    break;

                default:
                    Assert.Fail("context object is unexpected type.");
                    break;
            }

            if (expect.HasFlag(Params.Filter))
            {
                Assert.IsTrue(filterCount > 0,
                    $"Expected the {nameof(EntityFilter)} property of the context object to be set.");
            }
            else
            {
                Assert.IsTrue(filterCount == 0,
                    $"Expected the {nameof(EntityFilter)} property of the context object to not be set.");
            }
        }

        internal virtual void VerifyItemsToCreate<T>(PipelineContext<T> context)
        {
            var createContext = (CreateContext<T>)context;

            Assert.IsTrue(createContext.Items.Any(),
                $"Expected the {nameof(CreateContext<T>.Items)} property of the context object to be set.");

            Assert.IsTrue(createContext.Items.All(i => i != null),
                $"Expected no null values within the {nameof(CreateContext<T>.Items)} property of the context object.");
        }

        internal virtual void VerifyItemsToUpdate<T>(PipelineContext<T> context)
        {
            var updateContext = (UpdateContext<T>)context;

            Assert.IsTrue(updateContext.Items.Any(),
                $"Expected the {nameof(UpdateContext<T>.Items)} property of the context object to be set.");

            Assert.IsTrue(updateContext.Items.All(i => i != null),
                $"Expected no null values within the {nameof(UpdateContext<T>.Items)} property of the context object.");
        }

        internal virtual void VerifyIdsToDelete<T>(PipelineContext<T> context)
        {

            var deleteContext = (DeleteContext<T>)context;

            Assert.IsTrue(deleteContext.Ids.Any(),
                $"Expected the {nameof(DeleteContext<T>.Ids)} property of the context object to be set.");
        }
    }
}
