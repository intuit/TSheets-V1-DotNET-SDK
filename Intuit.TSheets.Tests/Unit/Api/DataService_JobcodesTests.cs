// *******************************************************************************
// <copyright file="DataService_JobcodesTests.cs" company="Intuit">
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
    public class DataService_JobcodesTests : DataServiceTestBase
    {
        private static readonly JobcodeFilter DummyFilter = new JobcodeFilter
        {
            Active = TristateChoice.Both
        };

        private static readonly Jobcode DummyEntity = new Jobcode();
        private static readonly List<Jobcode> DummyEntities = new List<Jobcode> { DummyEntity };

        #region Create Method Tests

        [TestMethod, TestCategory("Unit")]
        public void CreateJobcodes_TestWithoutOptions()
        {
            ExpectCreate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                ApiService.CreateJobcodes(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateJobcodes_TestWithOptions()
        {
            ExpectCreate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                ApiService.CreateJobcodes(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateJobcode_TestWithoutOptions()
        {
            ExpectCreate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                ApiService.CreateJobcode(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void CreateJobcode_TestWithOptions()
        {
            ExpectCreate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                ApiService.CreateJobcode(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateJobcodes_TestWithoutOptionsAsync()
        {
            ExpectCreate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                await ApiService.CreateJobcodesAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateJobcodes_TestWithOptionsAsync()
        {
            ExpectCreate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                await ApiService.CreateJobcodesAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateJobcode_TestWithoutOptionsAsync()
        {
            ExpectCreate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                await ApiService.CreateJobcodeAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateJobcode_TestWithOptionsAsync()
        {
            ExpectCreate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                await ApiService.CreateJobcodeAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetJobcodes_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<Jobcode>(EndpointName.Jobcodes, Params.None);

            VerifyResult(
                ApiService.GetJobcodes());
        }

        [TestMethod, TestCategory("Unit")]
        public void GetJobcodes_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<Jobcode>(EndpointName.Jobcodes, Params.Filter);

            VerifyResult(
                ApiService.GetJobcodes(DummyFilter));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetJobcodes_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<Jobcode>(EndpointName.Jobcodes, Params.RequestOptions);

            VerifyResult(
                ApiService.GetJobcodes(DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public void GetJobcodes_TestWithFilterAndWithOptions()
        {
            ExpectGet<Jobcode>(EndpointName.Jobcodes, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetJobcodes(DummyFilter, DummyRequestOptions));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetJobcodes_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Jobcode>(EndpointName.Jobcodes, Params.None);

            VerifyResult(
                await ApiService.GetJobcodesAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetJobcodes_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<Jobcode>(EndpointName.Jobcodes, Params.Filter);

            VerifyResult(
                await ApiService.GetJobcodesAsync(DummyFilter).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetJobcodes_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<Jobcode>(EndpointName.Jobcodes, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetJobcodesAsync(DummyRequestOptions).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetJobcodes_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<Jobcode>(EndpointName.Jobcodes, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetJobcodesAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateJobcodes_TestWithoutOptions()
        {
            ExpectUpdate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                ApiService.UpdateJobcodes(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateJobcodes_TestWithOptions()
        {
            ExpectUpdate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                ApiService.UpdateJobcodes(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateJobcode_TestWithoutOptions()
        {
            ExpectUpdate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                ApiService.UpdateJobcode(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateJobcode_TestWithOptions()
        {
            ExpectUpdate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                ApiService.UpdateJobcode(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateJobcodes_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                await ApiService.UpdateJobcodesAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateJobcodes_TestWithOptionsAsync()
        {
            ExpectUpdate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                await ApiService.UpdateJobcodesAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateJobcode_TestWithoutOptionsAsync()
        {
            ExpectUpdate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                await ApiService.UpdateJobcodeAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateJobcode_TestWithOptionsAsync()
        {
            ExpectUpdate<Jobcode>(EndpointName.Jobcodes);

            VerifyResult(
                await ApiService.UpdateJobcodeAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion
    }
}
