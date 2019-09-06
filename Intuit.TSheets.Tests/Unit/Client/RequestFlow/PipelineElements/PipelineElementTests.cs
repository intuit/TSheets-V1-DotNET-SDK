// *******************************************************************************
// <copyright file="PipelineElementTests.cs" company="Intuit">
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
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PipelineElementTests : UnitTestBase
    {
        private const string InfoLogMessageAsync = "Derived class pipelineElement was called (async).";
        private const string ErrorLogMessageAsync = "You can't do that (async).";

        private TestPipelineElement pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = TestPipelineElement.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public void PipelineElement_SetsNamePropertyInConstructor()
        {
            Assert.AreEqual(this.pipelineElement.Name, nameof(TestPipelineElement),
                "Expected Name property to be set.");
        }

        private class TestPipelineElement : PipelineElement<TestPipelineElement>
        {
            private TestPipelineElement()
            {
            }

            protected override Task _ProcessAsync<T>(PipelineContext<T> context, ILogger logger)
            {
                logger?.Log(LogLevel.Debug, InfoLogMessageAsync);

                return Task.CompletedTask;
            }
        }
    }
}
