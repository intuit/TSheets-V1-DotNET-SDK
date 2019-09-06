// *******************************************************************************
// <copyright file="SupplementalDataTests.cs" company="Intuit">
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
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class SupplementalDataTests
    {
        [TestMethod, TestCategory("Unit")]
        public void SupplementalData_AddsAndRetrieveEntityById()
        {
            var entityToAdd = new BasicTestEntity(1);

            var supplementalData = new SupplementalData();
            supplementalData.AddOrUpdate(entityToAdd);

            var entityRetrieved = supplementalData.GetById<BasicTestEntity>(1);

            Assert.AreSame(entityToAdd, entityRetrieved);
        }

        [TestMethod, TestCategory("Unit")]
        public void SupplementalData_UpdatesEntityById()
        {
            var initialEntityToAdd = new BasicTestEntity(1, "foo");
            var updatedEntityToAdd = new BasicTestEntity(1, "bar");

            var supplementalData = new SupplementalData();
            supplementalData.AddOrUpdate(initialEntityToAdd);
            supplementalData.AddOrUpdate(updatedEntityToAdd);

            Assert.AreEqual(1, supplementalData.GetAll<BasicTestEntity>().Count);

            var entityRetrieved = supplementalData.GetById<BasicTestEntity>(1);

            Assert.AreSame(updatedEntityToAdd, entityRetrieved);
        }

        [TestMethod, TestCategory("Unit")]
        public void SupplementalData_GetAllEntitiesByTypeReturnsExpectedResults()
        {
            var entity1 = new BasicTestEntity(1, "foo");
            var entity2 = new BasicTestEntity(2, "bar");
            var entity3 = new BasicTestEntity(3, "baz");

            var supplementalData = new SupplementalData();
            supplementalData.AddOrUpdate(entity1);
            supplementalData.AddOrUpdate(entity2);
            supplementalData.AddOrUpdate(entity3);

            Assert.AreEqual(3, supplementalData.GetAll<BasicTestEntity>().Count);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(NotFoundException))]
        public void SupplementalData_GetByIdThrowsWhenIdNotFound()
        {
            var supplementalData = new SupplementalData();
            supplementalData.GetById<BasicTestEntity>(123);
        }

        [TestMethod, TestCategory("Unit")]
        public void SupplementalData_AddsAndRetrievesMultipleTypesOfEntities()
        {
            var entity1 = new BasicTestEntity(1, "foo");
            var entity2 = new TestEntity(1, "foo");

            var supplementalData = new SupplementalData();
            supplementalData.AddOrUpdate(entity1);
            supplementalData.AddOrUpdate(entity2);

            IReadOnlyList<IIdentifiable> allEntities = supplementalData.GetAll();

            Assert.AreEqual(2, allEntities.Count);
        }
    }
}
