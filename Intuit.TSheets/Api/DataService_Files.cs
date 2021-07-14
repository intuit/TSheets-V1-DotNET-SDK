// *******************************************************************************
// <copyright file="DataService_Files.cs" company="Intuit">
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

namespace Intuit.TSheets.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    /// <remarks>
    /// This file contains operations specific to the Files endpoint.
    /// </remarks>  
    public partial class DataService
    {
        #region Upload methods

        /// <summary>
        /// Upload Files.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="File"/> object that can be attached to a timesheet.
        /// </remarks>
        /// <param name="file">
        /// The set of <see cref="File"/> objects to be created.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (File, ResultsMeta) UploadFile(
            File file)
        {
            (IList<File> files, ResultsMeta resultsMeta) = UploadFiles(new[] { file });

            return (files.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Upload Files.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="File"/> objects that can be attached to timesheets.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="File"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<File>, ResultsMeta resultsMeta) UploadFiles(
            IEnumerable<File> files)
        {
            return AsyncUtil.RunSync(() => UploadFilesAsync(files));
        }

        /// <summary>
        /// Asynchronously Upload Files.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="File"/> object that can be attached to a timesheet.
        /// </remarks>
        /// <param name="file">
        /// The set of <see cref="File"/> objects to be created.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(File, ResultsMeta)> UploadFileAsync(
            File file)
        {
            (IList<File> files, ResultsMeta resultsMeta) = await UploadFilesAsync(new[] { file }, default).ConfigureAwait(false);

            return (files.FirstOrDefault(), resultsMeta);
        }


        /// <summary>
        /// Asynchronously Upload Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="File"/> object that can be attached to a timesheet.
        /// </remarks>
        /// <param name="file">
        /// The set of <see cref="File"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(File, ResultsMeta)> UploadFileAsync(
            File file,
            CancellationToken cancellationToken)
        {
            (IList<File> files, ResultsMeta resultsMeta) = await UploadFilesAsync(new[] { file }, cancellationToken).ConfigureAwait(false);

            return (files.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Upload Files.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="File"/> objects that can be attached to timesheets.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="File"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<File>, ResultsMeta)> UploadFilesAsync(
            IEnumerable<File> files)
        {
            return await UploadFilesAsync(files, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Upload Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="File"/> objects that can be attached to timesheets.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="File"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<File>, ResultsMeta)> UploadFilesAsync(
            IEnumerable<File> files,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<File>(EndpointName.Files, files);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Files.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<File>, ResultsMeta) GetFiles()
        {
            return AsyncUtil.RunSync(() => GetFilesAsync());
        }

        /// <summary>
        /// Retrieve Files.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<File>, ResultsMeta) GetFiles(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetFilesAsync(options));
        }

        /// <summary>
        /// Retrieve Files.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="FileFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<File>, ResultsMeta) GetFiles(
            FileFilter filter)
        {
            return AsyncUtil.RunSync(() => GetFilesAsync(filter));
        }

        /// <summary>
        /// Retrieve Files.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="FileFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<File>, ResultsMeta) GetFiles(
            FileFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetFilesAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Files.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<File>, ResultsMeta)> GetFilesAsync()
        {
            return await GetFilesAsync(null, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<File>, ResultsMeta)> GetFilesAsync(
            CancellationToken cancellationToken)
        {
            return await GetFilesAsync(null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Files.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<File>, ResultsMeta)> GetFilesAsync(
            RequestOptions options)
        {
            return await GetFilesAsync(null, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<File>, ResultsMeta)> GetFilesAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            return await GetFilesAsync(null, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Files.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="FileFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<File>, ResultsMeta)> GetFilesAsync(
            FileFilter filter)
        {
            return await GetFilesAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="FileFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<File>, ResultsMeta)> GetFilesAsync(
            FileFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetFilesAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Files.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="FileFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<File>, ResultsMeta)> GetFilesAsync(
            FileFilter filter,
            RequestOptions options)
        {
            return await GetFilesAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all uploaded files, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="FileFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="File"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<File>, ResultsMeta)> GetFilesAsync(
            FileFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<File>(EndpointName.Files, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// Update Files.
        /// </summary>
        /// <remarks>
        /// Update a single <see cref="File"/> object that is/can be attached to a timesheet.
        /// </remarks>
        /// <param name="file">
        /// The set of <see cref="File"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (File, ResultsMeta) UpdateFile(File file)
        {
            (IList<File> files, ResultsMeta resultsMeta) = UpdateFiles(new[] { file });

            return (files.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update Files.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="File"/> objects that are/can be attached to timesheets.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="File"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<File>, ResultsMeta resultsMeta) UpdateFiles(
            IEnumerable<File> files)
        {
            return AsyncUtil.RunSync(() => UpdateFilesAsync(files));
        }

        /// <summary>
        /// Asynchronously Update Files.
        /// </summary>
        /// <remarks>
        /// Update a single <see cref="File"/> object that is/can be attached to a timesheet.
        /// </remarks>
        /// <param name="file">
        /// The set of <see cref="File"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(File, ResultsMeta)> UpdateFileAsync(
            File file)
        {
            (IList<File> files, ResultsMeta resultsMeta) = await UpdateFilesAsync(new[] { file }, default).ConfigureAwait(false);

            return (files.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Update a single <see cref="File"/> object that is/can be attached to a timesheet.
        /// </remarks>
        /// <param name="file">
        /// The set of <see cref="File"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(File, ResultsMeta)> UpdateFileAsync(
            File file,
            CancellationToken cancellationToken)
        {
            (IList<File> files, ResultsMeta resultsMeta) = await UpdateFilesAsync(new[] { file }, cancellationToken).ConfigureAwait(false);

            return (files.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Files.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="File"/> objects that are/can be attached to timesheets.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="File"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<File>, ResultsMeta)> UpdateFilesAsync(
            IEnumerable<File> files)
        {
            return await UpdateFilesAsync(files, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="File"/> objects that are/can be attached to timesheets.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="File"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<File>, ResultsMeta)> UpdateFilesAsync(
            IEnumerable<File> files,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<File>(EndpointName.Files, files);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Download Methods

        /// <summary>
        /// Download the raw bytes of an image file.
        /// </summary>
        /// <param name="id">The id the of the image file to download.</param>
        /// <returns>An array of bytes, representing the image content.</returns>
        public byte[] DownloadFile(long id)
        {
            return AsyncUtil.RunSync(() => DownloadFileAsync(id));
        }

        /// <summary>
        /// Asynchronously download the raw bytes of an image file.
        /// </summary>
        /// <param name="id">The id the of the image file to download.</param>
        /// <returns>An array of bytes, representing the image content.</returns>
        public async Task<byte[]> DownloadFileAsync(
            long id)
        {
            return await DownloadFileAsync(id, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously download the raw bytes of an image file, with support for cancellation.
        /// </summary>
        /// <param name="id">The id the of the image file to download.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>An array of bytes, representing the image content.</returns>
        public async Task<byte[]> DownloadFileAsync(
            long id,
            CancellationToken cancellationToken)
        {
            var context = new DownloadContext<File>(EndpointName.FilesRaw, new FileDownloadFilter(id));

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return context.RawResponseContent;
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="File"/> object.
        /// </remarks>
        /// <param name="file">
        /// The <see cref="File"/> object to be deleted.
        /// </param>
        public void DeleteFile(File file)
        {
            AsyncUtil.RunSync(() => DeleteFileAsync(file));
        }

        /// <summary>
        /// Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="File"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="File"/> object to be deleted.
        /// </param>
        public void DeleteFile(long id)
        {
            AsyncUtil.RunSync(() => DeleteFileAsync(id));
        }

        /// <summary>
        /// Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="File"/> objects.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be deleted.
        /// </param>
        public void DeleteFiles(IEnumerable<File> files)
        {
            AsyncUtil.RunSync(() => DeleteFilesAsync(files));
        }

        /// <summary>
        /// Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="File"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="File"/> objects to be deleted.
        /// </param>
        public void DeleteFiles(IEnumerable<long> ids)
        {
            AsyncUtil.RunSync(() => DeleteFilesAsync(ids));
        }

        /// <summary>
        /// Asynchronously Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="File"/> object.
        /// </remarks>
        /// <param name="file">
        /// The <see cref="File"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteFileAsync(
            File file)
        {
            await DeleteFilesAsync(new[] { file.Id }, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="File"/> object.
        /// </remarks>
        /// <param name="file">
        /// The <see cref="File"/> object to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteFileAsync(
            File file,
            CancellationToken cancellationToken)
        {
            await DeleteFilesAsync(new[] { file.Id }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="File"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="File"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteFileAsync(
            long id)
        {
            await DeleteFilesAsync(new[] { id }, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="File"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="File"/> object to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteFileAsync(
            long id,
            CancellationToken cancellationToken)
        {
            await DeleteFilesAsync(new[] { id }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="File"/> objects.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteFilesAsync(
            IEnumerable<File> files)
        {
            IEnumerable<long> ids = files?.Select(t => t.Id);

            await DeleteFilesAsync(ids, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="File"/> objects.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteFilesAsync(
            IEnumerable<File> files,
            CancellationToken cancellationToken)
        {
            IEnumerable<long> ids = files?.Select(t => t.Id);

            await DeleteFilesAsync(ids, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="File"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="File"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteFilesAsync(
            IEnumerable<long> ids)
        {
            await DeleteFilesAsync(ids, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Files, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="File"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="File"/> objects to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteFilesAsync(
            IEnumerable<long> ids,
            CancellationToken cancellationToken)
        {
            var context = new DeleteContext<File>(EndpointName.Files, ids);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
