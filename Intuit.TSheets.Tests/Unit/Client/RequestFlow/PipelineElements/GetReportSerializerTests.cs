// *******************************************************************************
// <copyright file="GetReportSerializerTests.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model.Enums;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetReportSerializerTests : UnitTestBase
    {
        private GetReportSerializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = GetReportSerializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public void GetReportSerializer_CorrectlySerializesFilters()
        {
            TestReportFilter filterToBeSerialized = GetTestReportFilter();

            const string expectedSerialization = @"
            {
              ""data"": {
                ""ids"": ""3,5,7"",
                ""name"": ""T*"",
                ""active"": ""both""
              }
            }";

            AssertSerializesAsExpected<TestReport>(filterToBeSerialized, expectedSerialization);
        }

        [TestMethod, TestCategory("Unit")]
        public void GetReportSerializer_CorrectlySerializesEmptyFilters()
        {
            var filterToBeSerialized = new TestReportFilter();

            const string expectedSerialization = @"
            {
              ""data"": {}
            }";

            AssertSerializesAsExpected<TestReport>(filterToBeSerialized, expectedSerialization);
        }

        private static TestReportFilter GetTestReportFilter() => new TestReportFilter
        {
            Ids = new[] { 3, 5, 7 },
            Name = "T*",
            Active = TristateChoice.Both
        };

        private static GetReportContext<T> GetReportContext<T>(EntityFilter filterToBeSerialized)
            => new GetReportContext<T>(EndpointName.Tests, filterToBeSerialized);

        private void AssertSerializesAsExpected<T>(EntityFilter filterToBeSerialized, string expectedSerialization)
        {
            GetReportContext<T> context = GetReportContext<T>(filterToBeSerialized);
            AsyncUtil.RunSync(() => this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default));

            TestHelper.AssertJsonEqual(expectedSerialization, context.SerializedRequest);
        }
    }
}
