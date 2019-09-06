// *******************************************************************************
// <copyright file="MultiStatusHandlerTests.cs" company="Intuit">
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
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MultiStatusHandlerTests : UnitTestBase
    {
        private MultiStatusHandler pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = MultiStatusHandler.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public async Task ResultsStatusAnalyzer_NoExceptionIsThrownWhenResultsPropertyOfContextObjectIsNullAsync()
        {
            var context = new CreateContext<BasicTestEntity>(EndpointName.Tests, new[]{ new BasicTestEntity() });

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task ResultsStatusAnalyzer_NoExceptionIsThrownWhenThereAreNoErrorItemsAsync()
        {
            var context = new CreateContext<BasicTestEntity>(EndpointName.Tests, new[] { new BasicTestEntity() })
            {
                Results = new Results<BasicTestEntity>()
            };

            await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task ResultsStatusAnalyzer_ThrowsMultiStatusExceptionWhenErrorItemsArePresentAsync()
        {
            var context = new CreateContext<BasicTestEntity>(EndpointName.Tests, new[] { new BasicTestEntity() })
            {
                Results = new Results<BasicTestEntity>
                {
                    ErrorItems = new List<ErrorItem<BasicTestEntity>>
                    {
                        new ErrorItem<BasicTestEntity>(
                            0,
                            new Status {Id = 1, Code = 404, Message = "Not found.", Extra = "Unable to find item."})
                    }
                }
            };

            try
            {
                await this.pipelineElement.ProcessAsync(context, NullLogger.Instance).ConfigureAwait(false);

                Assert.Fail("Expected MultiStatusException to be thrown");
            }
            catch (MultiStatusException<BasicTestEntity>)
            { }

        }
           
    }

}
