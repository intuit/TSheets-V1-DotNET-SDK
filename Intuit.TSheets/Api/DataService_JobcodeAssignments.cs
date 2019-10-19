// *******************************************************************************
// <copyright file="DataService_JobcodeAssignments.cs" company="Intuit">
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
    /// This file contains operations specific to the JobcodeAssignments endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Add one or more jobcode assignments to a user.
        /// </remarks>
        /// <param name="jobcodeAssignments">
        /// The set of <see cref="JobcodeAssignment"/> assignments to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="JobcodeAssignment"/> assignments that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<JobcodeAssignment>, ResultsMeta) CreateJobcodeAssignments(IEnumerable<JobcodeAssignment> jobcodeAssignments)
        {
            return AsyncUtil.RunSync(() => CreateJobcodeAssignmentsAsync(jobcodeAssignments));
        }

        /// <summary>
        /// Create Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Add a single jobcode assignment to a user.
        /// </remarks>
        /// <param name="jobcodeAssignment">
        /// The <see cref="JobcodeAssignment"/> assignment to be created.
        /// </param>
        /// <returns>
        /// The <see cref="JobcodeAssignment"/> assignment that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (JobcodeAssignment, ResultsMeta) CreateJobcodeAssignment(JobcodeAssignment jobcodeAssignment)
        {
            (IList<JobcodeAssignment> jobcodeAssignments, ResultsMeta resultsMeta) = CreateJobcodeAssignments(new[] { jobcodeAssignment });

            return (jobcodeAssignments.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Add one or more jobcode assignments to a user.
        /// </remarks>
        /// <param name="jobcodeAssignments">
        /// The set of <see cref="JobcodeAssignment"/> assignments to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="JobcodeAssignment"/> assignments that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> CreateJobcodeAssignmentsAsync(
            IEnumerable<JobcodeAssignment> jobcodeAssignments)
        {
            var context = new CreateContext<JobcodeAssignment>(EndpointName.JobcodeAssignments, jobcodeAssignments);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more jobcode assignments to a user.
        /// </remarks>
        /// <param name="jobcodeAssignments">
        /// The set of <see cref="JobcodeAssignment"/> assignments to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="JobcodeAssignment"/> assignments that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> CreateJobcodeAssignmentsAsync(
            IEnumerable<JobcodeAssignment> jobcodeAssignments,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Create Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Add a single jobcode assignment to a user.
        /// </remarks>
        /// <param name="jobcodeAssignment">
        /// The <see cref="JobcodeAssignment"/> assignment to be created.
        /// </param>
        /// <returns>
        /// The <see cref="JobcodeAssignment"/> assignment that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(JobcodeAssignment, ResultsMeta)> CreateJobcodeAssignmentAsync(
            JobcodeAssignment jobcodeAssignment)
        {
            (IList<JobcodeAssignment> jobcodeAssignments, ResultsMeta resultsMeta) = await CreateJobcodeAssignmentsAsync(new[] { jobcodeAssignment }).ConfigureAwait(false);

            return (jobcodeAssignments.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single jobcode assignment to a user.
        /// </remarks>
        /// <param name="jobcodeAssignment">
        /// The <see cref="JobcodeAssignment"/> assignment to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="JobcodeAssignment"/> assignment that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(JobcodeAssignment, ResultsMeta)> CreateJobcodeAssignmentAsync(
            JobcodeAssignment jobcodeAssignment,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<JobcodeAssignment>, ResultsMeta) GetJobcodeAssignments()
        {
            return AsyncUtil.RunSync(() => GetJobcodeAssignmentsAsync());
        }

        /// <summary>
        /// Retrieve Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<JobcodeAssignment>, ResultsMeta) GetJobcodeAssignments(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetJobcodeAssignmentsAsync(options));
        }

        /// <summary>
        /// Retrieve Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeAssignmentFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<JobcodeAssignment>, ResultsMeta) GetJobcodeAssignments(
            JobcodeAssignmentFilter filter)
        {
            return AsyncUtil.RunSync(() => GetJobcodeAssignmentsAsync(filter));
        }

        /// <summary>
        /// Retrieve Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeAssignmentFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<JobcodeAssignment>, ResultsMeta) GetJobcodeAssignments(
            JobcodeAssignmentFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetJobcodeAssignmentsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync()
        {
            return await GetJobcodeAssignmentsAsync(null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(
            RequestOptions options)
        {
            return await GetJobcodeAssignmentsAsync(null, options).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeAssignmentFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(
            JobcodeAssignmentFilter filter)
        {
            return await GetJobcodeAssignmentsAsync(filter, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeAssignmentFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(
            JobcodeAssignmentFilter filter,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeAssignmentFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(
            JobcodeAssignmentFilter filter,
            RequestOptions options)
        {
            var context = new GetContext<JobcodeAssignment>(EndpointName.JobcodeAssignments, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcode assignments associated with users,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeAssignmentFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="JobcodeAssignment"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(
            JobcodeAssignmentFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="JobcodeAssignment"/> assignment.
        /// </remarks>
        /// <param name="jobcodeAssignment">
        /// The <see cref="JobcodeAssignment"/> assignment object to be deleted.
        /// </param>
        public void DeleteJobcodeAssignment(JobcodeAssignment jobcodeAssignment)
        {
            DeleteJobcodeAssignments(new[] { jobcodeAssignment });
        }

        /// <summary>
        /// Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="JobcodeAssignment"/> assignments.
        /// </remarks>
        /// <param name="jobcodeAssignments">
        /// The set of <see cref="JobcodeAssignment"/> assignment objects to be deleted.
        /// </param>
        public void DeleteJobcodeAssignments(
            IEnumerable<JobcodeAssignment> jobcodeAssignments)
        {
            IEnumerable<int> ids = jobcodeAssignments.Select(j => j.Id);

            DeleteJobcodeAssignments(ids);
        }

        /// <summary>
        /// Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="JobcodeAssignment"/> assignment, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="JobcodeAssignment"/> assignment object to be deleted.
        /// </param>
        public void DeleteJobcodeAssignment(int id)
        {
            DeleteJobcodeAssignments(new[] { id });
        }

        /// <summary>
        /// Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="JobcodeAssignment"/> assignments, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="JobcodeAssignment"/> assignment objects to be deleted.
        /// </param>
        public void DeleteJobcodeAssignments(IEnumerable<int> ids)
        {
            AsyncUtil.RunSync(() => DeleteJobcodeAssignmentsAsync(ids));
        }

        /// <summary>
        /// Asynchronously Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="JobcodeAssignment"/> assignment.
        /// </remarks>
        /// <param name="jobcodeAssignment">
        /// The <see cref="JobcodeAssignment"/> assignment object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteJobcodeAssignmentAsync(
            JobcodeAssignment jobcodeAssignment)
        {
            await DeleteJobcodeAssignmentsAsync(new[] { jobcodeAssignment }).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="JobcodeAssignment"/> assignment.
        /// </remarks>
        /// <param name="jobcodeAssignment">
        /// The <see cref="JobcodeAssignment"/> assignment object to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteJobcodeAssignmentAsync(
            JobcodeAssignment jobcodeAssignment,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="JobcodeAssignment"/> assignments.
        /// </remarks>
        /// <param name="jobcodeAssignments">
        /// The set of <see cref="JobcodeAssignment"/> assignment objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteJobcodeAssignmentsAsync(
            IEnumerable<JobcodeAssignment> jobcodeAssignments)
        {
            IEnumerable<int> ids = jobcodeAssignments.Select(t => t.Id);

            await DeleteJobcodeAssignmentsAsync(ids).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="JobcodeAssignment"/> assignments.
        /// </remarks>
        /// <param name="jobcodeAssignments">
        /// The set of <see cref="JobcodeAssignment"/> assignment objects to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteJobcodeAssignmentsAsync(
            IEnumerable<JobcodeAssignment> jobcodeAssignments,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="JobcodeAssignment"/> assignment, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="JobcodeAssignment"/> assignment object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteJobcodeAssignmentAsync(
            int id)
        {
            await DeleteJobcodeAssignmentsAsync(new[] { id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="JobcodeAssignment"/> assignment, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="JobcodeAssignment"/> assignment object to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteJobcodeAssignmentAsync(
            int id,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Asynchronously Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="JobcodeAssignment"/> assignments, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="JobcodeAssignment"/> assignment objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteJobcodeAssignmentsAsync(
            IEnumerable<int> ids)
        {
            var context = new DeleteContext<JobcodeAssignment>(EndpointName.JobcodeAssignments, ids);

            await ExecuteOperationAsync(context).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Delete Jobcode Assignments, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="JobcodeAssignment"/> assignments, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="JobcodeAssignment"/> assignment objects to be deleted.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        public async Task DeleteJobcodeAssignmentsAsync(
            IEnumerable<int> ids,
            CancellationToken cancellationToken)
        {
            // TODO
            await Task.Run(() => { });
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
