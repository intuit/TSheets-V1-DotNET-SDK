// *******************************************************************************
// <copyright file="DataService_FilesTests.cs" company="Intuit">
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
    public class DataService_FilesTests : DataServiceTestBase
    {
        private static readonly FileFilter DummyFilter = new FileFilter
        {
            Active = TristateChoice.Both
        };

        private static readonly File DummyEntity = new File
        {
            Id = 1
        };

        private static readonly List<File> DummyEntities = new List<File> { DummyEntity };

        #region Upload Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UploadFiles_TestWithoutOptions()
        {
            ExpectCreate<File>(EndpointName.Files);

            VerifyResult(
                ApiService.UploadFiles(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UploadFiles_TestWithOptions()
        {
            ExpectCreate<File>(EndpointName.Files);

            VerifyResult(
                ApiService.UploadFiles(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UploadFile_TestWithoutOptions()
        {
            ExpectCreate<File>(EndpointName.Files);

            VerifyResult(
                ApiService.UploadFile(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UploadFile_TestWithOptions()
        {
            ExpectCreate<File>(EndpointName.Files);

            VerifyResult(
                ApiService.UploadFile(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UploadFiles_TestWithoutOptionsAsync()
        {
            ExpectCreate<File>(EndpointName.Files);

            VerifyResult(
                await ApiService.UploadFilesAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UploadFiles_TestWithOptionsAsync()
        {
            ExpectCreate<File>(EndpointName.Files);

            VerifyResult(
                await ApiService.UploadFilesAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UploadFile_TestWithoutOptionsAsync()
        {
            ExpectCreate<File>(EndpointName.Files);

            VerifyResult(
                await ApiService.UploadFileAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UploadFile_TestWithOptionsAsync()
        {
            ExpectCreate<File>(EndpointName.Files);

            VerifyResult(
                await ApiService.UploadFileAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Get Method Tests

        [TestMethod, TestCategory("Unit")]
        public void GetFiles_TestWithoutFilterAndWithoutOptions()
        {
            ExpectGet<File>(EndpointName.Files, Params.None);

            VerifyResult(
                ApiService.GetFiles());
        }


        [TestMethod, TestCategory("Unit")]
        public void GetFiles_TestWithFilterAndWithoutOptions()
        {
            ExpectGet<File>(EndpointName.Files, Params.Filter);

            VerifyResult(
                ApiService.GetFiles(DummyFilter));
        }


        [TestMethod, TestCategory("Unit")]
        public void GetFiles_TestWithoutFilterAndWithOptions()
        {
            ExpectGet<File>(EndpointName.Files, Params.RequestOptions);

            VerifyResult(
                ApiService.GetFiles(DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public void GetFiles_TestWithFilterAndWithOptions()
        {
            ExpectGet<File>(EndpointName.Files, Params.Filter | Params.RequestOptions);

            VerifyResult(
                ApiService.GetFiles(DummyFilter, DummyRequestOptions));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetFiles_TestWithoutFilterAndWithoutOptionsAsync()
        {
            ExpectGet<File>(EndpointName.Files, Params.None);

            VerifyResult(
                await ApiService.GetFilesAsync().ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetFiles_TestWithFilterAndWithoutOptionsAsync()
        {
            ExpectGet<File>(EndpointName.Files, Params.Filter);

            VerifyResult(
                await ApiService.GetFilesAsync(DummyFilter).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetFiles_TestWithoutFilterAndWithOptionsAsync()
        {
            ExpectGet<File>(EndpointName.Files, Params.RequestOptions);

            VerifyResult(
                await ApiService.GetFilesAsync(DummyRequestOptions).ConfigureAwait(false));
        }


        [TestMethod, TestCategory("Unit")]
        public async Task GetFiles_TestWithFilterAndWithOptionsAsync()
        {
            ExpectGet<File>(EndpointName.Files, Params.Filter | Params.RequestOptions);

            VerifyResult(
                await ApiService.GetFilesAsync(DummyFilter, DummyRequestOptions).ConfigureAwait(false));
        }

        #endregion

        #region Update Method Tests

        [TestMethod, TestCategory("Unit")]
        public void UpdateFiles_TestWithoutOptions()
        {
            ExpectUpdate<File>(EndpointName.Files);

            VerifyResult(
                ApiService.UpdateFiles(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateFiles_TestWithOptions()
        {
            ExpectUpdate<File>(EndpointName.Files);

            VerifyResult(
                ApiService.UpdateFiles(DummyEntities));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateFile_TestWithoutOptions()
        {
            ExpectUpdate<File>(EndpointName.Files);

            VerifyResult(
                ApiService.UpdateFile(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public void UpdateFile_TestWithOptions()
        {
            ExpectUpdate<File>(EndpointName.Files);

            VerifyResult(
                ApiService.UpdateFile(DummyEntity));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateFiles_TestWithoutOptionsAsync()
        {
            ExpectUpdate<File>(EndpointName.Files);

            VerifyResult(
                await ApiService.UpdateFilesAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateFiles_TestWithOptionsAsync()
        {
            ExpectUpdate<File>(EndpointName.Files);

            VerifyResult(
                await ApiService.UpdateFilesAsync(DummyEntities).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateFile_TestWithoutOptionsAsync()
        {
            ExpectUpdate<File>(EndpointName.Files);

            VerifyResult(
                await ApiService.UpdateFileAsync(DummyEntity).ConfigureAwait(false));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateFile_TestWithOptionsAsync()
        {
            ExpectUpdate<File>(EndpointName.Files);

            VerifyResult(
                await ApiService.UpdateFileAsync(DummyEntity).ConfigureAwait(false));
        }

        #endregion

        #region Download Method Tests

        [TestMethod, TestCategory("Unit")]
        public void DownloadFile_Test()
        {
            ExpectDownload<File>(EndpointName.FilesRaw);

            ApiService.DownloadFile(1);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DownloadFile_TestAsync()
        {
            ExpectDownload<File>(EndpointName.FilesRaw);

            await ApiService.DownloadFileAsync(1).ConfigureAwait(false);
        }

        #endregion

        #region Delete Method Tests

        [TestMethod, TestCategory("Unit")]
        public void DeleteFile_Test()
        {
            ExpectDelete<File>(EndpointName.Files);

            ApiService.DeleteFile(DummyEntity);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteFiles_Test()
        {
            ExpectDelete<File>(EndpointName.Files);

            ApiService.DeleteFiles(DummyEntities);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteFile_ById_Test()
        {
            ExpectDelete<File>(EndpointName.Files);

            ApiService.DeleteFile(1);
        }

        [TestMethod, TestCategory("Unit")]
        public void DeleteFiles_ById_Test()
        {
            ExpectDelete<File>(EndpointName.Files);

            ApiService.DeleteFiles(new[]{ 1, 2 });
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteFile_TestAsync()
        {
            ExpectDelete<File>(EndpointName.Files);

            await ApiService.DeleteFileAsync(DummyEntity).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteFiles_TestAsync()
        {
            ExpectDelete<File>(EndpointName.Files);

            await ApiService.DeleteFilesAsync(DummyEntities).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteFile_ById_TestAsync()
        {
            ExpectDelete<File>(EndpointName.Files);

            await ApiService.DeleteFileAsync(1).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteFiles_ById_TestAsync()
        {
            ExpectDelete<File>(EndpointName.Files);

            await ApiService.DeleteFilesAsync(new[] { 1, 2 }).ConfigureAwait(false);
        }

        #endregion
    }
}
