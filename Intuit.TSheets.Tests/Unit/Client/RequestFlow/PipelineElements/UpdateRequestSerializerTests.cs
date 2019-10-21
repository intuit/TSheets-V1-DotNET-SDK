// *******************************************************************************
// <copyright file="UpdateRequestSerializerTests.cs" company="Intuit">
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
    using System;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.RequestFlow.PipelineElements;
    using Intuit.TSheets.Client.Utilities;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UpdateRequestSerializerTests : UnitTestBase
    {
        private UpdateRequestSerializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = UpdateRequestSerializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateRequestSerializationHandler_CorrectlySerializesEntity()
        {
            var entityToBeSerialized = new TestEntity
            {
                Id = 11,
                Name = "Larry",
                EmployeeId = 3755,
                ManagerOfIds = new[] { 105, 106, 109 }
            };

            const string expectedSerialization = @"
            {
              ""data"": [
                {
                  ""id"": 11,
                  ""name"": ""Larry"",
                  ""employee_id"": 3755,
                  ""manager_of_ids"": [ 105, 106, 109 ]
                }
              ]
            }";

            AssertSerializesAsExpected(entityToBeSerialized, expectedSerialization);
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateRequestSerializationHandler_DoesNotSerializePropertiesAttributedWithNoSerializeOnWrite()
        {
            var entityToBeSerialized = new TestEntityNoSerializeOnWrite
            {
                Created = DateTimeOffset.Parse("2019-06-15T12:00:00-06:00")
            };

            const string expectedSerialization = @"
            {
              ""data"": [
                { }
              ]
            }";

            AssertSerializesAsExpected(entityToBeSerialized, expectedSerialization);
        }
       
        private void AssertSerializesAsExpected<T>(T entityToSerialize, string expectedSerialization)
        {
            UpdateContext<T> context = new UpdateContext<T>(EndpointName.Tests, new[] { entityToSerialize });
            AsyncUtil.RunSync(() => this.pipelineElement.ProcessAsync(context, NullLogger.Instance, default));

            TestHelper.AssertJsonEqual(expectedSerialization, context.SerializedRequest);
        }
    }

}
