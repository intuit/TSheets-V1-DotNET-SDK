// *******************************************************************************
// <copyright file="DataService_Jobcodes.cs" company="Intuit">
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
    /// This file contains operations specific to the Jobcodes endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Jobcodes.
        /// </summary>
        /// <remarks>
        /// Add one or more jobcodes to your company.
        /// </remarks>
        /// <param name="jobcodes">
        /// The set of <see cref="Jobcode"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Jobcode"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Jobcode>, ResultsMeta) CreateJobcodes(IEnumerable<Jobcode> jobcodes)
        {
            return AsyncUtil.RunSync(() => CreateJobcodesAsync(jobcodes));
        }

        /// <summary>
        /// Create Jobcodes.
        /// </summary>
        /// <remarks>
        /// Add a single jobcode to your company.
        /// </remarks>
        /// <param name="jobcode">
        /// The <see cref="Jobcode"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Jobcode"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Jobcode, ResultsMeta) CreateJobcode(Jobcode jobcode)
        {
            (IList<Jobcode> jobcodes, ResultsMeta resultsMeta) = CreateJobcodes(new[] { jobcode });

            return (jobcodes.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Jobcodes.
        /// </summary>
        /// <remarks>
        /// Add one or more jobcodes to your company.
        /// </remarks>
        /// <param name="jobcodes">
        /// The set of <see cref="Jobcode"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Jobcode"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Jobcode>, ResultsMeta)> CreateJobcodesAsync(IEnumerable<Jobcode> jobcodes)
        {
            var context = new CreateContext<Jobcode>(EndpointName.Jobcodes, jobcodes);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Jobcodes.
        /// </summary>
        /// <remarks>
        /// Add a single jobcode to your company.
        /// </remarks>
        /// <param name="jobcode">
        /// The <see cref="Jobcode"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Jobcode"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Jobcode, ResultsMeta)> CreateJobcodeAsync(Jobcode jobcode)
        {
            (IList<Jobcode> jobcodes, ResultsMeta resultsMeta) = await CreateJobcodesAsync(new[] { jobcode }).ConfigureAwait(false);

            return (jobcodes.FirstOrDefault(), resultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve Jobcodes.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcodes associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Jobcode"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Jobcode>, ResultsMeta) GetJobcodes()
        {
            return AsyncUtil.RunSync(() => GetJobcodesAsync());
        }

        /// <summary>
        /// Retrieve Jobcodes.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcodes associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Jobcode"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Jobcode>, ResultsMeta) GetJobcodes(
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetJobcodesAsync(options));
        }

        /// <summary>
        /// Retrieve Jobcodes.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcodes associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Jobcode"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Jobcode>, ResultsMeta) GetJobcodes(
            JobcodeFilter filter)
        {
            return AsyncUtil.RunSync(() => GetJobcodesAsync(filter));
        }

        /// <summary>
        /// Retrieve Jobcodes.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcodes associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Jobcode"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<Jobcode>, ResultsMeta) GetJobcodes(
            JobcodeFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetJobcodesAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcodes.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcodes associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An enumerable set of <see cref="Jobcode"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Jobcode>, ResultsMeta)> GetJobcodesAsync()
        {
            return await GetJobcodesAsync(null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcodes.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcodes associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Jobcode"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Jobcode>, ResultsMeta)> GetJobcodesAsync(
            RequestOptions options)
        {
            return await GetJobcodesAsync(null, options).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcodes.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcodes associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Jobcode"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Jobcode>, ResultsMeta)> GetJobcodesAsync(
            JobcodeFilter filter)
        {
            return await GetJobcodesAsync(filter, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve Jobcodes.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all jobcodes associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="JobcodeFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Jobcode"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<Jobcode>, ResultsMeta)> GetJobcodesAsync(
            JobcodeFilter filter,
            RequestOptions options)
        {
            var context = new GetContext<Jobcode>(EndpointName.Jobcodes, filter, options);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update Jobcodes.
        /// </summary>
        /// <remarks>
        /// Edit one or more jobcodes in your company.
        /// </remarks>
        /// <param name="jobcodes">
        /// The set of <see cref="Jobcode"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Jobcode"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Jobcode>, ResultsMeta) UpdateJobcodes(
            IEnumerable<Jobcode> jobcodes)
        {
            return AsyncUtil.RunSync(() => UpdateJobcodesAsync(jobcodes));
        }

        /// <summary>
        /// Update Jobcodes.
        /// </summary>
        /// <remarks>
        /// Edit a single jobcode in your company.
        /// </remarks>
        /// <param name="jobcode">
        /// The <see cref="Jobcode"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Jobcode"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Jobcode, ResultsMeta) UpdateJobcode(Jobcode jobcode)
        {
            (IList<Jobcode> jobcodes, ResultsMeta resultsMeta) =
                UpdateJobcodes(new[] { jobcode });

            return (jobcodes.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Jobcodes.
        /// </summary>
        /// <remarks>
        /// Edit one or more jobcodes in your company.
        /// </remarks>
        /// <param name="jobcodes">
        /// The set of <see cref="Jobcode"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Jobcode"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Jobcode>, ResultsMeta)> UpdateJobcodesAsync(IEnumerable<Jobcode> jobcodes)
        {
            var context = new UpdateContext<Jobcode>(EndpointName.Jobcodes, jobcodes);

            await ExecuteOperationAsync(context).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        /// <summary>
        /// Asynchronously Update Jobcodes.
        /// </summary>
        /// <remarks>
        /// Edit a single jobcode in your company.
        /// </remarks>
        /// <param name="jobcode">
        /// The <see cref="Jobcode"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Jobcode"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Jobcode, ResultsMeta)> UpdateJobcodeAsync(Jobcode jobcode)
        {
            (IList<Jobcode> jobcodes, ResultsMeta resultsMeta) =
                await UpdateJobcodesAsync(new[] { jobcode }).ConfigureAwait(false);

            return (jobcodes.FirstOrDefault(), resultsMeta);
        }

        #endregion
    }
}
