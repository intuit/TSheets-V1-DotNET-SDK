// *******************************************************************************
// <copyright file="GetResultsMetaDeserializerTests.cs" company="Intuit">
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
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetResultsMetaDeserializerTests : UnitTestBase
    {
        private GetResultsMetaDeserializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = GetResultsMetaDeserializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetResultsMetaDeserializer_SetsMetaMoreTrueWhenMoreIsTrueAsync()
        {
            var context = new GetContext<TestEntity>(EndpointName.Tests, filter: null, options: null)
            {
                ResponseContent = @"{ ""more"": true }"
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            Assert.IsTrue(context.ResultsMeta.More, "Expected ResultsMeta.More to be true");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetResultsMetaDeserializer_SetsMetaMoreFalseWhenMoreIsFalseAsync()
        {
            var context = new GetContext<TestEntity>(EndpointName.Tests, filter: null, options: null)
            {
                ResponseContent = @"{ ""more"": false }"
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            Assert.IsFalse(context.ResultsMeta.More, "Expected ResultsMeta.More to be false");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetResultsMetaDeserializer_SetsMetaMoreFalseWhenMoreIsNotPresentAsync()
        {
            var context = new GetContext<TestEntity>(EndpointName.Tests, filter: null, options: null)
            {
                ResponseContent = @"{ ""more_is_not_present"": ""expect false"" }"
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            Assert.IsFalse(context.ResultsMeta.More, "Expected ResultsMeta.More to be false");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetResultsMetaDeserializer_SetsMetaPageValueAsync()
        {
            const int expectedPage = 3;
            var options = new RequestOptions { Page = expectedPage };
            var context = new GetContext<TestEntity>(EndpointName.Tests, filter: null, options: options)
            {
                ResponseContent = @"{ ""more"": false }"
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

            Assert.AreEqual(expectedPage, context.ResultsMeta.Page, $"Expected ResultsMeta.Page to be {expectedPage}.");
        }
    }
}
