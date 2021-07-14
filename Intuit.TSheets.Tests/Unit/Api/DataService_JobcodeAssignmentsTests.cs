// *******************************************************************************
// <copyright file="DataService_JobcodeAssignmentsTests.cs" company="Intuit">
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
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Enums;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataService_JobcodeAssignmentsTests : DataServiceTestBase
    {
        private static readonly JobcodeAssignmentFilter DummyFilter = new JobcodeAssignmentFilter
        {
            Active = TristateChoice.Both
        };

        private static readonly JobcodeAssignment DummyEntity = new JobcodeAssignment();
        private static readonly List<JobcodeAssignment> DummyEntities = new List<JobcodeAssignment> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateJobcodeAssignments_TestWithoutOptions()
        {
            ExpectCreate<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            VerifyResult(
                ApiService.CreateJobcodeAssignments(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateJobcodeAssignments_TestWithOptions()
        {
            ExpectCreate<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            VerifyResult(
                ApiService.CreateJobcodeAssignments(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateJobcodeAssignment_TestWithoutOptions()
        {
            ExpectCreate<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            VerifyResult(
                ApiService.CreateJobcodeAssignment(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateJobcodeAssignment_TestWithOptions()
        {
            ExpectCreate<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            VerifyResult(
                ApiService.CreateJobcodeAssignment(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateJobcodeAssignments_TestWithoutOptionsAsync()
        {
            ExpectCreate<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            VerifyResult(
                await ApiService.CreateJobcodeAssignmentsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateJobcodeAssignments_TestWithOptionsAsync()
        {
            ExpectCreate<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            VerifyResult(
                await ApiService.CreateJobcodeAssignmentsAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateJobcodeAssignment_TestWithoutOptionsAsync()
        {
            ExpectCreate<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            VerifyResult(
                await ApiService.CreateJobcodeAssignmentAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateJobcodeAssignment_TestWithOptionsAsync()
        {
            ExpectCreate<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            VerifyResult(
                await ApiService.CreateJobcodeAssignmentAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetJobcodeAssignments_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<JobcodeAssignment>(EndpointName.JobcodeAssignments, Params.None);

            VerifyResult(
                ApiService.GetJobcodeAssignments());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetJobcodeAssignments_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<JobcodeAssignment>(EndpointName.JobcodeAssignments, Params.Filter);

            VerifyResult(
                ApiService.GetJobcodeAssignments(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetJobcodeAssignments_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<JobcodeAssignment>(EndpointName.JobcodeAssignments, Params.RequestOptions);

            VerifyResult(
                ApiService.GetJobcodeAssignments(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetJobcodeAssignments_TestWithFilterAndWithOptions()
        {
            ExpectGet<JobcodeAssignment>(EndpointName.JobcodeAssignments, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetJobcodeAssignments(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetJobcodeAssignments_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<JobcodeAssignment>(EndpointName.JobcodeAssignments, Params.None);

            VerifyResult(
                await ApiService.GetJobcodeAssignmentsAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetJobcodeAssignments_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<JobcodeAssignment>(EndpointName.JobcodeAssignments, Params.Filter);

            VerifyResult(
                await ApiService.GetJobcodeAssignmentsAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetJobcodeAssignments_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<JobcodeAssignment>(EndpointName.JobcodeAssignments, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetJobcodeAssignmentsAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetJobcodeAssignments_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<JobcodeAssignment>(EndpointName.JobcodeAssignments, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetJobcodeAssignmentsAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Delete Method Tests

        [TestMethod, TestCategory("Unit")]
        public void DeleteJobcodeAssignment_Test()
        {
            ExpectDelete<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            ApiService.DeleteJobcodeAssignment(DummyEntity);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteJobcodeAssignments_Test()
        {
            ExpectDelete<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            ApiService.DeleteJobcodeAssignments(DummyEntities);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteJobcodeAssignment_ById_Test()
        {
            ExpectDelete<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            ApiService.DeleteJobcodeAssignment(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteJobcodeAssignments_ById_Test()
        {
            ExpectDelete<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            ApiService.DeleteJobcodeAssignments(new long[] { 1, 2 });
        }


        [TestMethod, TestCategory("Unit")]
        public async Task DeleteJobcodeAssignment_TestAsync()
        {
            ExpectDelete<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            await ApiService.DeleteJobcodeAssignmentAsync(DummyEntity).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteJobcodeAssignments_TestAsync()
        {
            ExpectDelete<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            await ApiService.DeleteJobcodeAssignmentsAsync(DummyEntities).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteJobcodeAssignment_ById_TestAsync()
        {
            ExpectDelete<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            await ApiService.DeleteJobcodeAssignmentAsync(1).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteJobcodeAssignments_ById_TestAsync()
        {
            ExpectDelete<JobcodeAssignment>(EndpointName.JobcodeAssignments);

            await ApiService.DeleteJobcodeAssignmentsAsync(new long[] { 1, 2 }).ConfigureAwait(false);
        }

        #endregion
    }
}
