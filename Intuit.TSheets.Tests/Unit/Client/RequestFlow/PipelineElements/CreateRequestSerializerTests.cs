// *******************************************************************************
// <copyright file="CreateRequestSerializerTests.cs" company="Intuit">
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
    public class CreateRequestSerializerTests : UnitTestBase
    {
        private CreateRequestSerializer pipelineElement;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.pipelineElement = CreateRequestSerializer.Instance;
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateRequestSerializer_CorrectlySerializesEntity()
        {
            var entityToBeSerialized = new TestEntity
            {
                Name = "Larry",
                EmployeeId = 3755,
                ManagerOfIds = new[] { 105, 106, 109 }
            };

            const string expectedSerialization = @"
            {
              ""data"": [
                {
                  ""name"": ""Larry"",
                  ""employee_id"": 3755,
                  ""manager_of_ids"": [ 105, 106, 109 ]
                }
              ]
            }";

            AssertSerializesAsExpected(entityToBeSerialized, expectedSerialization);
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateRequestSerializer_DoesNotSerializePropertiesAttributedWithNoSerializeOnCreate()
        {
            var entityToBeSerialized = new TestEntityNoSerializeOnCreate
            {
                Id = 100
            };

            const string expectedSerialization = @"
            {
              ""data"": [
                { }
              ]
            }";

            AssertSerializesAsExpected(entityToBeSerialized, expectedSerialization);
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateRequestSerializer_DoesNotSerializePropertiesAttributedWithNoSerializeOnWrite()
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
       
        private static CreateContext<T> GetCreateContext<T>(T entity)
            => new CreateContext<T>(EndpointName.Tests, new[] { entity });

        private void AssertSerializesAsExpected<T>(T entityToSerialize, string expectedSerialization)
        {
            CreateContext<T> context = GetCreateContext(entityToSerialize);

            AsyncUtil.RunSync(() => this.pipelineElement.ProcessAsync(context, NullLogger.Instance));

            TestHelper.AssertJsonEqual(expectedSerialization, context.SerializedRequest);
        }
    }
}
