// *******************************************************************************
// <copyright file="IDataService.cs" company="Intuit">
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
    using System.Threading.Tasks;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;
    using CustomFieldItemFilter = Intuit.TSheets.Model.CustomFieldItemFilter;

    /// <summary>
    /// Top-level interface defining all TSheets API operations.
    /// </summary>
    public interface IDataService
    {
        #region CurrentUser

        /// <summary>
        /// Retrieve the Current User.
        /// </summary>
        /// <remarks>
        /// Retrieves the user object for the currently authenticated user. This is the
        /// user that authenticated to TSheets during the OAuth2 authentication process.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="User"/> class, representing the current user, along
        /// with an output instance of the <see cref="ResultsMeta"/> class containing additional
        /// data.
        /// </returns>
        (User, ResultsMeta) GetCurrentUser(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve the Current User.
        /// </summary>
        /// <remarks>
        /// Retrieves the user object for the currently authenticated user. This is the
        /// user that authenticated to TSheets during the OAuth2 authentication process.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="User"/> class, representing the current user, along
        /// with an output instance of the <see cref="ResultsMeta"/> class containing additional
        /// data.
        /// </returns>
        Task<(User, ResultsMeta)> GetCurrentUserAsync(RequestOptions options = null);

        #endregion

        #region CustomFields

        /// <summary>
        /// Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<CustomField>, ResultsMeta) GetCustomFields(
            RequestOptions options = null);

        /// <summary>
        /// Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<CustomField>, ResultsMeta) GetCustomFields(
            CustomFieldFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Fields.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom fields associated with your company,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="CustomField"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<CustomField>, ResultsMeta)> GetCustomFieldsAsync(
            CustomFieldFilter filter,
            RequestOptions options = null);

        #endregion

        #region CustomFieldItems

        /// <summary>
        /// Create Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="CustomFieldItem"/> objects to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItem>, ResultsMeta resultsMeta) CreateCustomFieldItems(
            IEnumerable<CustomFieldItem> customFieldItems);

        /// <summary>
        /// Create Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomFieldItem"/> object to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (CustomFieldItem, ResultsMeta) CreateCustomFieldItem(CustomFieldItem customFieldItem);

        /// <summary>
        /// Asynchronously Create Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add one or more <see cref="CustomFieldItem"/> objects to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItem>, ResultsMeta resultsMeta)> CreateCustomFieldItemsAsync(
            IEnumerable<CustomFieldItem> customFieldItems);

        /// <summary>
        /// Asynchronously Create Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomFieldItem"/> object to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(CustomFieldItem, ResultsMeta)> CreateCustomFieldItemAsync(
            CustomFieldItem customFieldItem);

        /// <summary>
        /// Retrieve Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field items associated with a custom field,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="Model.Filters.CustomFieldItemFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItem>, ResultsMeta) GetCustomFieldItems(
            Model.Filters.CustomFieldItemFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field items associated with a custom field,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="Model.Filters.CustomFieldItemFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItem>, ResultsMeta)> GetCustomFieldItemsAsync(
            Model.Filters.CustomFieldItemFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Update Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="CustomFieldItem"/> objects on a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItem>, ResultsMeta resultsMeta) UpdateCustomFieldItems(
            IEnumerable<CustomFieldItem> customFieldItems);

        /// <summary>
        /// Update Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Update a single <see cref="CustomFieldItem"/> object on a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (CustomFieldItem, ResultsMeta) UpdateCustomFieldItem(
            CustomFieldItem customFieldItem);

        /// <summary>
        /// Asynchronously Update Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Update one or more <see cref="CustomFieldItem"/> objects on a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItems">
        /// The set of <see cref="CustomFieldItem"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItem"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItem>, ResultsMeta resultsMeta)> UpdateCustomFieldItemsAsync(
            IEnumerable<CustomFieldItem> customFieldItems);

        /// <summary>
        /// Asynchronously Update Custom Field Items.
        /// </summary>
        /// <remarks>
        /// Add a single <see cref="CustomFieldItem"/> object to a <see cref="CustomField"/>.
        /// </remarks>
        /// <param name="customFieldItem">
        /// The <see cref="CustomFieldItem"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="CustomFieldItem"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(CustomFieldItem, ResultsMeta)> UpdateCustomFieldItemAsync(
            CustomFieldItem customFieldItem);

        #endregion

        #region CustomFieldItemFilters

        /// <summary>
        /// Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Model.CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItemFilter>, ResultsMeta) GetCustomFieldItemFilters(RequestOptions options = null);

        /// <summary>
        /// Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItemFilter>, ResultsMeta) GetCustomFieldItemFilters(
            CustomFieldItemFilterFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItemFilter>, ResultsMeta)> GetCustomFieldItemFiltersAsync(
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a jobcode, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItemFilter>, ResultsMeta)> GetCustomFieldItemFiltersAsync(
            CustomFieldItemFilterFilter filter,
            RequestOptions options = null);

        #endregion

        #region CustomFieldItemJobcodeFilters

        /// <summary>
        /// Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItemJobcodeFilter>, ResultsMeta) GetCustomFieldItemJobcodeFilters(RequestOptions options = null);

        /// <summary>
        /// Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemJobcodeFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItemJobcodeFilter>, ResultsMeta) GetCustomFieldItemJobcodeFilters(
            CustomFieldItemJobcodeFilterFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItemJobcodeFilter>, ResultsMeta)> GetCustomFieldItemJobcodeFiltersAsync(
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item Jobcode Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemJobcodeFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemJobcodeFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItemJobcodeFilter>, ResultsMeta)> GetCustomFieldItemJobcodeFiltersAsync(
            CustomFieldItemJobcodeFilterFilter filter,
            RequestOptions options = null);

        #endregion

        #region CustomFieldItemUserFilters

        /// <summary>
        /// Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItemUserFilter>, ResultsMeta) GetCustomFieldItemUserFilters(RequestOptions options = null);

        /// <summary>
        /// Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemUserFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<CustomFieldItemUserFilter>, ResultsMeta) GetCustomFieldItemUserFilters(
            CustomFieldItemUserFilterFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItemUserFilter>, ResultsMeta)> GetCustomFieldItemUserFiltersAsync(
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Custom Field Item User Filters.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all custom field item filters associated with a user, user, or group,
        /// with options to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CustomFieldItemUserFilterFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// The set of the <see cref="CustomFieldItemUserFilter"/> objects retrieved, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<CustomFieldItemUserFilter>, ResultsMeta)> GetCustomFieldItemUserFiltersAsync(
            CustomFieldItemUserFilterFilter filter,
            RequestOptions options = null);

        #endregion

        #region EffectiveSettings

        /// <summary>
        /// Retrieve Effective Settings.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        EffectiveSettings GetEffectiveSettings();

        /// <summary>
        /// Retrieve Effective Settings.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="EffectiveSettingsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        EffectiveSettings GetEffectiveSettings(EffectiveSettingsFilter filter);

        /// <summary>
        /// Asynchronously Retrieve Effective Settings.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        Task<EffectiveSettings> GetEffectiveSettingsAsync();

        /// <summary>
        /// Asynchronously Retrieve Effective Settings.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all effective settings associated with a single user,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="EffectiveSettingsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="EffectiveSettings"/> class.
        /// </returns> 
        Task<EffectiveSettings> GetEffectiveSettingsAsync(EffectiveSettingsFilter filter);

        #endregion

        #region Files

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
        (IList<File>, ResultsMeta resultsMeta) UploadFiles(IEnumerable<File> files);

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
        (File, ResultsMeta) UploadFile(File file);

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
        Task<(IList<File>, ResultsMeta)> UploadFilesAsync(IEnumerable<File> files);

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
        Task<(File, ResultsMeta)> UploadFileAsync(File file);

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
        (IList<File>, ResultsMeta) GetFiles(RequestOptions options = null);

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
        (IList<File>, ResultsMeta) GetFiles(
            FileFilter filter,
            RequestOptions options = null);

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
        Task<(IList<File>, ResultsMeta)> GetFilesAsync(RequestOptions options = null);

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
        Task<(IList<File>, ResultsMeta)> GetFilesAsync(
            FileFilter filter,
            RequestOptions options = null);

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
        (IList<File>, ResultsMeta resultsMeta) UpdateFiles(
            IEnumerable<File> files);

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
        (File, ResultsMeta) UpdateFile(File file);

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
        Task<(IList<File>, ResultsMeta)> UpdateFilesAsync(IEnumerable<File> files);

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
        Task<(File, ResultsMeta)> UpdateFileAsync(File file);

        /// <summary>
        /// Download the raw bytes of an image file.
        /// </summary>
        /// <param name="id">The id the of the image file to download.</param>
        /// <returns>An array of bytes, representing the image content.</returns>
        byte[] DownloadFile(int id);

        /// <summary>
        /// Asynchronously download the raw bytes of an image file.
        /// </summary>
        /// <param name="id">The id the of the image file to download.</param>
        /// <returns>An array of bytes, representing the image content.</returns>
        Task<byte[]> DownloadFileAsync(int id);

        /// <summary>
        /// Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="File"/> object.
        /// </remarks>
        /// <param name="file">
        /// The <see cref="File"/> object to be deleted.
        /// </param>
        void DeleteFile(File file);

        /// <summary>
        /// Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="File"/> objects.
        /// </remarks>
        /// <param name="files">
        /// The set of <see cref="File"/> objects to be deleted.
        /// </param>
        void DeleteFiles(IEnumerable<File> files);

        /// <summary>
        /// Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="File"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="File"/> object to be deleted.
        /// </param>
        void DeleteFile(int id);

        /// <summary>
        /// Delete Files.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="File"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="File"/> objects to be deleted.
        /// </param>
        void DeleteFiles(IEnumerable<int> ids);

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
        Task DeleteFileAsync(File file);

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
        Task DeleteFilesAsync(IEnumerable<File> files);

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
        Task DeleteFileAsync(int id);

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
        Task DeleteFilesAsync(IEnumerable<int> ids);

        #endregion

        #region GeofenceConfigs

        /// <summary>
        /// Retrieve Geofence Configurations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all geofence configurations, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="GeofenceConfig"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<GeofenceConfig>, ResultsMeta) GetGeofenceConfigs(RequestOptions options = null);

        /// <summary>
        /// Retrieve Geofence Configurations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all geofence configurations, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GeofenceConfigFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="GeofenceConfig"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<GeofenceConfig>, ResultsMeta) GetGeofenceConfigs(
            GeofenceConfigFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Geofence Configurations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all geofence configurations, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="GeofenceConfig"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<GeofenceConfig>, ResultsMeta)> GetGeofenceConfigsAsync(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Geofence Configurations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all geofence configurations, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GeofenceConfigFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="GeofenceConfig"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<GeofenceConfig>, ResultsMeta)> GetGeofenceConfigsAsync(
            GeofenceConfigFilter filter,
            RequestOptions options = null);

        #endregion

        #region Geolocations

        /// <summary>
        /// Create Geolocations.
        /// </summary>
        /// <param name="geolocations">
        /// The set of <see cref="Geolocation"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Geolocation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Geolocation>, ResultsMeta) CreateGeolocations(IEnumerable<Geolocation> geolocations);

        /// <summary>
        /// Create Geolocations.
        /// </summary>
        /// <param name="geolocation">
        /// The <see cref="Geolocation"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Geolocation"/> object that was created, along with as output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Geolocation, ResultsMeta) CreateGeolocation(Geolocation geolocation);

        /// <summary>
        /// Asynchronously Create Geolocations.
        /// </summary>
        /// <param name="geolocations">
        /// The set of <see cref="Geolocation"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Geolocation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Geolocation>, ResultsMeta)> CreateGeolocationsAsync(IEnumerable<Geolocation> geolocations);

        /// <summary>
        /// Asynchronously Create Geolocations.
        /// </summary>
        /// <param name="geolocation">
        /// The <see cref="Geolocation"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Geolocation"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Geolocation, ResultsMeta)> CreateGeolocationAsync(Geolocation geolocation);

        /// <summary>
        /// Retrieve Geolocations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of geolocations associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GeolocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Geolocation"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Geolocation>, ResultsMeta) GetGeolocations(
            GeolocationFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Geolocations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of geolocations associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GeolocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Geolocation"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Geolocation>, ResultsMeta)> GetGeolocationsAsync(
            GeolocationFilter filter,
            RequestOptions options = null);

        #endregion

        #region Groups

        /// <summary>
        /// Create Groups.
        /// </summary>
        /// <remarks>
        /// Add one or more groups to your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Group>, ResultsMeta) CreateGroups(IEnumerable<Group> groups);

        /// <summary>
        /// Create Groups.
        /// </summary>
        /// <remarks>
        /// Add a single group to your company.
        /// </remarks> 
        /// <param name="group">
        /// The <see cref="Group"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Group, ResultsMeta) CreateGroup(Group group);

        /// <summary>
        /// Asynchronously Create Groups.
        /// </summary>
        /// <remarks>
        /// Add one or more groups to your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Group>, ResultsMeta)> CreateGroupsAsync(IEnumerable<Group> groups);

        /// <summary>
        /// Asynchronously Create Groups.
        /// </summary>
        /// <remarks>
        /// Add a single group to your company.
        /// </remarks>
        /// <param name="group">
        /// The <see cref="Group"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Group, ResultsMeta)> CreateGroupAsync(Group group);

        /// <summary>
        /// Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Group>, ResultsMeta) GetGroups(RequestOptions options = null);

        /// <summary>
        /// Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GroupFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Group>, ResultsMeta) GetGroups(
            GroupFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Groups.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of groups associated with your company, with
        /// optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="GroupFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Group"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Group>, ResultsMeta)> GetGroupsAsync(
            GroupFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Update Groups.
        /// </summary>
        /// <remarks>
        /// Edit one or more groups in your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Group>, ResultsMeta) UpdateGroups(IEnumerable<Group> groups);

        /// <summary>
        /// Update Groups.
        /// </summary>
        /// <remarks>
        /// Edit a single group in your company.
        /// </remarks>
        /// <param name="group">
        /// The <see cref="Group"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Group, ResultsMeta) UpdateGroup(Group group);

        /// <summary>
        /// Asynchronously Update Groups.
        /// </summary>
        /// <remarks>
        /// Edit one or more groups in your company.
        /// </remarks>
        /// <param name="groups">
        /// The set of <see cref="Group"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Group"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Group>, ResultsMeta)> UpdateGroupsAsync(IEnumerable<Group> groups);

        /// <summary>
        /// Asynchronously Update Groups.
        /// </summary>
        /// <remarks>
        /// Edit a single group in your company.
        /// </remarks>
        /// <param name="group">
        /// The <see cref="Group"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Group"/> object that was updated, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Group, ResultsMeta)> UpdateGroupAsync(Group group);

        #endregion

        #region Invitations

        /// <summary>
        /// Create Invitations.
        /// </summary>
        /// <remarks>
        /// Invite one or more users to your company.
        /// </remarks>
        /// <param name="invitations">
        /// The set of <see cref="Invitation"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Invitation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Invitation>, ResultsMeta) CreateInvitations(IEnumerable<Invitation> invitations);

        /// <summary>
        /// Create Invitations.
        /// </summary>
        /// <remarks>
        /// Invite a single user to your company.
        /// </remarks> 
        /// <param name="invitation">
        /// The <see cref="Invitation"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Invitation"/> object that was created, along with as output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Invitation, ResultsMeta) CreateInvitation(Invitation invitation);

        /// <summary>
        /// Asynchronously Create Invitations.
        /// </summary>
        /// <remarks>
        /// Invite one or more users to your company.
        /// </remarks>
        /// <param name="invitations">
        /// The set of <see cref="Invitation"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Invitation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Invitation>, ResultsMeta)> CreateInvitationsAsync(IEnumerable<Invitation> invitations);

        /// <summary>
        /// Asynchronously Create Invitations.
        /// </summary>
        /// <remarks>
        /// Invite a single user to your company.
        /// </remarks>
        /// <param name="invitation">
        /// The <see cref="Invitation"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Invitation"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Invitation, ResultsMeta)> CreateInvitationAsync(Invitation invitation);

        #endregion

        #region Jobcodes

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
        (IList<Jobcode>, ResultsMeta) CreateJobcodes(IEnumerable<Jobcode> jobcodes);

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
        (Jobcode, ResultsMeta) CreateJobcode(Jobcode jobcode);

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
        Task<(IList<Jobcode>, ResultsMeta)> CreateJobcodesAsync(IEnumerable<Jobcode> jobcodes);

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
        Task<(Jobcode, ResultsMeta)> CreateJobcodeAsync(Jobcode jobcode);

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
        (IList<Jobcode>, ResultsMeta) GetJobcodes(RequestOptions options = null);

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
        (IList<Jobcode>, ResultsMeta) GetJobcodes(
            JobcodeFilter filter,
            RequestOptions options = null);

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
        Task<(IList<Jobcode>, ResultsMeta)> GetJobcodesAsync(RequestOptions options = null);

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
        Task<(IList<Jobcode>, ResultsMeta)> GetJobcodesAsync(
            JobcodeFilter filter,
            RequestOptions options = null);

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
        (IList<Jobcode>, ResultsMeta) UpdateJobcodes(
            IEnumerable<Jobcode> jobcodes);

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
        (Jobcode, ResultsMeta) UpdateJobcode(Jobcode jobcode);

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
        Task<(IList<Jobcode>, ResultsMeta)> UpdateJobcodesAsync(IEnumerable<Jobcode> jobcodes);

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
        Task<(Jobcode, ResultsMeta)> UpdateJobcodeAsync(Jobcode jobcode);

        #endregion

        #region JobcodeAssignments

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
        (IList<JobcodeAssignment>, ResultsMeta) CreateJobcodeAssignments(IEnumerable<JobcodeAssignment> jobcodeAssignments);

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
        (JobcodeAssignment, ResultsMeta) CreateJobcodeAssignment(JobcodeAssignment jobcodeAssignment);

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
        Task<(IList<JobcodeAssignment>, ResultsMeta)> CreateJobcodeAssignmentsAsync(IEnumerable<JobcodeAssignment> jobcodeAssignments);

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
        Task<(JobcodeAssignment, ResultsMeta)> CreateJobcodeAssignmentAsync(JobcodeAssignment jobcodeAssignment);

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
        (IList<JobcodeAssignment>, ResultsMeta) GetJobcodeAssignments(RequestOptions options = null);

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
        (IList<JobcodeAssignment>, ResultsMeta) GetJobcodeAssignments(
            JobcodeAssignmentFilter filter,
            RequestOptions options = null);

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
        Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(RequestOptions options = null);

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
        Task<(IList<JobcodeAssignment>, ResultsMeta)> GetJobcodeAssignmentsAsync(
            JobcodeAssignmentFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="JobcodeAssignment"/> assignment.
        /// </remarks>
        /// <param name="jobcodeAssignment">
        /// The <see cref="JobcodeAssignment"/> assignment object to be deleted.
        /// </param>
        void DeleteJobcodeAssignment(JobcodeAssignment jobcodeAssignment);

        /// <summary>
        /// Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="JobcodeAssignment"/> assignments.
        /// </remarks>
        /// <param name="jobcodeAssignments">
        /// The set of <see cref="JobcodeAssignment"/> assignment objects to be deleted.
        /// </param>
        void DeleteJobcodeAssignments(
            IEnumerable<JobcodeAssignment> jobcodeAssignments);

        /// <summary>
        /// Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="JobcodeAssignment"/> assignment, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="JobcodeAssignment"/> assignment object to be deleted.
        /// </param>
        void DeleteJobcodeAssignment(int id);

        /// <summary>
        /// Delete Jobcode Assignments.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="JobcodeAssignment"/> assignments, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="JobcodeAssignment"/> assignment objects to be deleted.
        /// </param>
        void DeleteJobcodeAssignments(IEnumerable<int> ids);

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
        Task DeleteJobcodeAssignmentAsync(JobcodeAssignment jobcodeAssignment);

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
        Task DeleteJobcodeAssignmentsAsync(IEnumerable<JobcodeAssignment> jobcodeAssignments);

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
        Task DeleteJobcodeAssignmentAsync(int id);

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
        Task DeleteJobcodeAssignmentsAsync(IEnumerable<int> ids);

        #endregion

        #region LastModifiedTimestamps

        /// <summary>
        /// Retrieve Last Modified Timestamps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of last modified timestamps associated with each requested API endpoint. 
        /// </remarks>
        /// <returns>
        /// An instance of a <see cref="LastModifiedTimestamps"/> class.
        /// </returns>
        LastModifiedTimestamps GetLastModifiedTimestamps();

        /// <summary>
        /// Retrieve Last Modified Timestamps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of last modified timestamps associated with each requested API endpoint. 
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LastModifiedTimestampsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of a <see cref="LastModifiedTimestamps"/> class.
        /// </returns>
        LastModifiedTimestamps GetLastModifiedTimestamps(LastModifiedTimestampsFilter filter);

        /// <summary>
        /// Asynchronously Retrieve Last Modified Timestamps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of last modified timestamps associated with each requested API endpoint. 
        /// </remarks>
        /// <returns>
        /// An instance of a <see cref="LastModifiedTimestamps"/> class.
        /// </returns>
        Task<LastModifiedTimestamps> GetLastModifiedTimestampsAsync();

        /// <summary>
        /// Asynchronously Retrieve Last Modified Timestamps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of last modified timestamps associated with each requested API endpoint. 
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LastModifiedTimestampsFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of a <see cref="LastModifiedTimestamps"/> class.
        /// </returns>
        Task<LastModifiedTimestamps> GetLastModifiedTimestampsAsync(LastModifiedTimestampsFilter filter);

        #endregion

        #region Locations

        /// <summary>
        /// Create Locations.
        /// </summary>
        /// <remarks>
        /// Add one or more locations to your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Location>, ResultsMeta) CreateLocations(IEnumerable<Location> locations);

        /// <summary>
        /// Create Locations.
        /// </summary>
        /// <remarks>
        /// Add a single location to your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Location, ResultsMeta) CreateLocation(Location location);

        /// <summary>
        /// Asynchronously Create Locations.
        /// </summary>
        /// <remarks>
        /// Add one or more locations to your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Location>, ResultsMeta)> CreateLocationsAsync(IEnumerable<Location> locations);

        /// <summary>
        /// Asynchronously Create Locations.
        /// </summary>
        /// <remarks>
        /// Add a single location to your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Location, ResultsMeta)> CreateLocationAsync(Location location);

        /// <summary>
        /// Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Location>, ResultsMeta) GetLocations(RequestOptions options = null);

        /// <summary>
        /// Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Location>, ResultsMeta) GetLocations(
            LocationFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Locations.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Location>, ResultsMeta)> GetLocationsAsync(
            LocationFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Update Locations.
        /// </summary>
        /// <remarks>
        /// Edit one or more locations in your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Location>, ResultsMeta) UpdateLocations(IEnumerable<Location> locations);

        /// <summary>
        /// Update Locations.
        /// </summary>
        /// <remarks>
        /// Edit a single location in your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Location, ResultsMeta) UpdateLocation(Location location);

        /// <summary>
        /// Asynchronously Update Locations.
        /// </summary>
        /// <remarks>
        /// Edit one or more locations in your company.
        /// </remarks>
        /// <param name="locations">
        /// The set of <see cref="Location"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Location"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Location>, ResultsMeta)> UpdateLocationsAsync(IEnumerable<Location> locations);

        /// <summary>
        /// Asynchronously Update Locations.
        /// </summary>
        /// <remarks>
        /// Edit a single location in your company.
        /// </remarks>
        /// <param name="location">
        /// The <see cref="Location"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Location, ResultsMeta)> UpdateLocationAsync(Location location);

        #endregion

        #region LocationsMaps

        /// <summary>
        /// Retrieve Locations Maps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations maps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="LocationsMap"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<LocationsMap>, ResultsMeta) GetLocationsMaps(RequestOptions options = null);

        /// <summary>
        /// Retrieve Locations Maps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locations maps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationsMapFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="LocationsMap"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<LocationsMap>, ResultsMeta) GetLocationsMaps(
            LocationsMapFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve LocationsMaps.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all locationsMaps associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="LocationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Location"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<LocationsMap>, ResultsMeta)> GetLocationsMapsAsync(
            LocationsMapFilter filter,
            RequestOptions options = null);

        #endregion

        #region ManagedClients

        /// <summary>
        /// Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<ManagedClient>, ResultsMeta) GetManagedClients(RequestOptions options = null);

        /// <summary>
        /// Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ManagedClientFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<ManagedClient>, ResultsMeta) GetManagedClients(
            ManagedClientFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Managed Clients.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of managed clients available from your account,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ManagedClientFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ManagedClient"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<ManagedClient>, ResultsMeta)> GetManagedClientsAsync(
            ManagedClientFilter filter,
            RequestOptions options = null);

        #endregion

        #region Notifications

        /// <summary>
        /// Create Notifications.
        /// </summary>
        /// <remarks>
        /// Add one or more notifications.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Notification"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Notification>, ResultsMeta) CreateNotifications(IEnumerable<Notification> notifications);

        /// <summary>
        /// Create Notifications.
        /// </summary>
        /// <remarks>
        /// Add a single notification.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Notification"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Notification, ResultsMeta) CreateNotification(Notification notification);

        /// <summary>
        /// Asynchronously Create Notifications.
        /// </summary>
        /// <remarks>
        /// Add one or more notifications.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Notification"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Notification>, ResultsMeta)> CreateNotificationsAsync(IEnumerable<Notification> notifications);

        /// <summary>
        /// Asynchronously Create Notifications.
        /// </summary>
        /// <remarks>
        /// Add a single notification.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Notification"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Notification, ResultsMeta)> CreateNotificationAsync(Notification notification);

        /// <summary>
        /// Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Notification>, ResultsMeta) GetNotifications(RequestOptions options = null);

        /// <summary>
        /// Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="NotificationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Notification>, ResultsMeta) GetNotifications(
            NotificationFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Notifications.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all notifications associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="NotificationFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Notification"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Notification>, ResultsMeta)> GetNotificationsAsync(
            NotificationFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be deleted.
        /// </param>
        void DeleteNotification(Notification notification);

        /// <summary>
        /// Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be deleted.
        /// </param>
        void DeleteNotifications(IEnumerable<Notification> notifications);

        /// <summary>
        /// Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Notification"/> object to be deleted.
        /// </param>
        void DeleteNotification(int id);

        /// <summary>
        /// Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Notification"/> objects to be deleted.
        /// </param>
        void DeleteNotifications(IEnumerable<int> ids);

        /// <summary>
        /// Asynchronously Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object.
        /// </remarks>
        /// <param name="notification">
        /// The <see cref="Notification"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        Task DeleteNotificationAsync(Notification notification);

        /// <summary>
        /// Asynchronously Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects.
        /// </remarks>
        /// <param name="notifications">
        /// The set of <see cref="Notification"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        Task DeleteNotificationsAsync(IEnumerable<Notification> notifications);

        /// <summary>
        /// Asynchronously Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Notification"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Notification"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        Task DeleteNotificationAsync(int id);

        /// <summary>
        /// Asynchronously Delete Notifications.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Notification"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Notification"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        Task DeleteNotificationsAsync(IEnumerable<int> ids);

        #endregion

        #region Reminders

        /// <summary>
        /// Create Reminders.
        /// </summary>
        /// <remarks>
        /// Add one or more user-specific or company-wide reminders.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Reminder>, ResultsMeta) CreateReminders(IEnumerable<Reminder> reminders);

        /// <summary>
        /// Create Reminders.
        /// </summary>
        /// <remarks>
        /// Add a single user-specific or company-wide reminder.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Reminder, ResultsMeta) CreateReminder(Reminder reminder);

        /// <summary>
        /// Asynchronously Create Reminders.
        /// </summary>
        /// <remarks>
        /// Add one or more user-specific or company-wide reminders.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Reminder>, ResultsMeta)> CreateRemindersAsync(IEnumerable<Reminder> reminders);

        /// <summary>
        /// Asynchronously Create Reminders.
        /// </summary>
        /// <remarks>
        /// Add a single user-specific or company-wide reminder.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Reminder, ResultsMeta)> CreateReminderAsync(Reminder reminder);

        /// <summary>
        /// Retrieve Reminders.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all reminders associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ReminderFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Reminder"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Reminder>, ResultsMeta) GetReminders(
            ReminderFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Reminders.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all reminders associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ReminderFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Reminder"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Reminder>, ResultsMeta)> GetRemindersAsync(
            ReminderFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Update Reminders.
        /// </summary>
        /// <remarks>
        /// Edit one or more reminders for employees within your company.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Reminder>, ResultsMeta) UpdateReminders(IEnumerable<Reminder> reminders);

        /// <summary>
        /// Update Reminders.
        /// </summary>
        /// <remarks>
        /// Edit a single reminder for employees within your company.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Reminder, ResultsMeta) UpdateReminder(Reminder reminder);

        /// <summary>
        /// Asynchronously Update Reminders.
        /// </summary>
        /// <remarks>
        /// Edit one or more reminders for employees within your company.
        /// </remarks>
        /// <param name="reminders">
        /// The set of <see cref="Reminder"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Reminder"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Reminder>, ResultsMeta)> UpdateRemindersAsync(
            IEnumerable<Reminder> reminders);

        /// <summary>
        /// Asynchronously Update Reminders.
        /// </summary>
        /// <remarks>
        /// Edit a single reminder for employees within your company.
        /// </remarks>
        /// <param name="reminder">
        /// The <see cref="Reminder"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Reminder"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Reminder, ResultsMeta)> UpdateReminderAsync(Reminder reminder);

        #endregion

        #region CurrentTotalsReport

        /// <summary>
        /// Retrieve Current Totals Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a snapshot report for the current totals (shift and day) along with additional
        /// information provided for those who are currently on the clock.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="CurrentTotalsReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (CurrentTotalsReport, ResultsMeta) GetCurrentTotalsReport();

        /// <summary>
        /// Retrieve Current Totals Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a snapshot report for the current totals (shift and day) along with additional
        /// information provided for those who are currently on the clock.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CurrentTotalsReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="CurrentTotalsReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (CurrentTotalsReport, ResultsMeta) GetCurrentTotalsReport(CurrentTotalsReportFilter filter);

        /// <summary>
        /// Asynchronously Retrieve Current Totals Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a snapshot report for the current totals (shift and day) along with additional
        /// information provided for those who are currently on the clock.
        /// </remarks>
        /// <returns>
        /// An instance of the <see cref="CurrentTotalsReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(CurrentTotalsReport, ResultsMeta)> GetCurrentTotalsReportAsync();

        /// <summary>
        /// Asynchronously Retrieve Current Totals Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a snapshot report for the current totals (shift and day) along with additional
        /// information provided for those who are currently on the clock.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="CurrentTotalsReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="CurrentTotalsReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(CurrentTotalsReport, ResultsMeta)> GetCurrentTotalsReportAsync(CurrentTotalsReportFilter filter);

        #endregion

        #region PayrollReport

        /// <summary>
        /// Retrieve Payroll Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a payroll report associated with a time frame,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="PayrollReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PayrollReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (PayrollReport, ResultsMeta) GetPayrollReport(PayrollReportFilter filter);

        /// <summary>
        /// Asynchronously Retrieve Payroll Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a payroll report associated with a time frame,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="PayrollReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PayrollReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(PayrollReport, ResultsMeta)> GetPayrollReportAsync(PayrollReportFilter filter);

        #endregion

        #region PayrollByJobCodeReport
        /// <summary>
        /// Retrieve Payroll by Jobcode Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a payroll report, broken down by jobcode,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="PayrollByJobcodeReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PayrollByJobcodeReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (PayrollByJobcodeReport, ResultsMeta) GetPayrollByJobcodeReport(PayrollByJobcodeReportFilter filter);

        /// <summary>
        /// Asynchronously Retrieve Payroll by Jobcode Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a payroll report, broken down by jobcode,
        /// with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="PayrollByJobcodeReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="PayrollByJobcodeReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(PayrollByJobcodeReport, ResultsMeta)> GetPayrollByJobcodeReportAsync(PayrollByJobcodeReportFilter filter);

        #endregion

        #region ProjectReport

        /// <summary>
        /// Retrieve Project Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a project report with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ProjectReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="ProjectReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (ProjectReport, ResultsMeta) GetProjectReport(ProjectReportFilter filter);

        /// <summary>
        /// Asynchronously Retrieve Project Report.
        /// </summary>
        /// <remarks>
        /// Retrieves a project report with filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ProjectReportFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="ProjectReport"/> class, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(ProjectReport, ResultsMeta)> GetProjectReportAsync(ProjectReportFilter filter);

        #endregion

        #region ScheduleCalendars

        /// <summary>
        /// Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<ScheduleCalendar>, ResultsMeta) GetScheduleCalendars(RequestOptions options = null);

        /// <summary>
        /// Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleCalendarFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<ScheduleCalendar>, ResultsMeta) GetScheduleCalendars(
            ScheduleCalendarFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<ScheduleCalendar>, ResultsMeta)> GetScheduleCalendarsAsync(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Schedule Calendars.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule calendars associated with your
        /// employees, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleCalendarFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleCalendar"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<ScheduleCalendar>, ResultsMeta)> GetScheduleCalendarsAsync(
            ScheduleCalendarFilter filter,
            RequestOptions options = null);

        #endregion

        #region ScheduleEvents

        /// <summary>
        /// Create Schedule Events.
        /// </summary>
        /// <remarks>
        /// Add one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<ScheduleEvent>, ResultsMeta) CreateScheduleEvents(IEnumerable<ScheduleEvent> scheduleEvents);

        /// <summary>
        /// Create ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Add a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (ScheduleEvent, ResultsMeta) CreateScheduleEvent(ScheduleEvent scheduleEvent);

        /// <summary>
        /// Asynchronously Create Schedule Events.
        /// </summary>
        /// <remarks>
        /// Add one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<ScheduleEvent>, ResultsMeta)> CreateScheduleEventsAsync(IEnumerable<ScheduleEvent> scheduleEvents);

        /// <summary>
        /// Asynchronously Create ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Add a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(ScheduleEvent, ResultsMeta)> CreateScheduleEventAsync(ScheduleEvent scheduleEvent);

        /// <summary>
        /// Retrieve Schedule Events.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule events associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleEventFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleEvent"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<ScheduleEvent>, ResultsMeta) GetScheduleEvents(
            ScheduleEventFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Schedule Events.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all schedule events associated with your employees
        /// or company, with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="ScheduleEventFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="ScheduleEvent"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<ScheduleEvent>, ResultsMeta)> GetScheduleEventsAsync(
            ScheduleEventFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Update Schedule Events.
        /// </summary>
        /// <remarks>
        /// Edit one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<ScheduleEvent>, ResultsMeta) UpdateScheduleEvents(IEnumerable<ScheduleEvent> scheduleEvents);

        /// <summary>
        /// Update ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Edit a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (ScheduleEvent, ResultsMeta) UpdateScheduleEvent(
            ScheduleEvent scheduleEvent);

        /// <summary>
        /// Asynchronously Update ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Edit one or more schedule events.
        /// </remarks>
        /// <param name="scheduleEvents">
        /// The set of <see cref="ScheduleEvent"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="ScheduleEvent"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<ScheduleEvent>, ResultsMeta)> UpdateScheduleEventsAsync(
            IEnumerable<ScheduleEvent> scheduleEvents);

        /// <summary>
        /// Asynchronously Update ScheduleEvents.
        /// </summary>
        /// <remarks>
        /// Edit a single schedule event.
        /// </remarks>
        /// <param name="scheduleEvent">
        /// The <see cref="ScheduleEvent"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="ScheduleEvent"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(ScheduleEvent, ResultsMeta)> UpdateScheduleEventAsync(
            ScheduleEvent scheduleEvent);

        #endregion

        #region Timesheets 

        /// <summary>
        /// Create Timesheets.
        /// </summary>
        /// <remarks>
        /// Add one or more timesheets to your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Timesheet>, ResultsMeta) CreateTimesheets(IEnumerable<Timesheet> timesheets);

        /// <summary>
        /// Create Timesheets.
        /// </summary>
        /// <remarks>
        /// Add a single timesheet to your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Timesheet, ResultsMeta) CreateTimesheet(Timesheet timesheet);

        /// <summary>
        /// Asynchronously Create Timesheets.
        /// </summary>
        /// <remarks>
        /// Add one or more timesheets to your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Timesheet>, ResultsMeta)> CreateTimesheetsAsync(IEnumerable<Timesheet> timesheets);

        /// <summary>
        /// Asynchronously Create Timesheets.
        /// </summary>
        /// <remarks>
        /// Add a single timesheet to your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Timesheet, ResultsMeta)> CreateTimesheetAsync(Timesheet timesheet);

        /// <summary>
        /// Retrieve Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Timesheet"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<Timesheet>, ResultsMeta) GetTimesheets(
            TimesheetFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="Timesheet"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<Timesheet>, ResultsMeta)> GetTimesheetsAsync(
            TimesheetFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Update Timesheets.
        /// </summary>
        /// <remarks>
        /// Edit one or more timesheets in your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<Timesheet>, ResultsMeta) UpdateTimesheets(IEnumerable<Timesheet> timesheets);

        /// <summary>
        /// Update Timesheets.
        /// </summary>
        /// <remarks>
        /// Edit a single timesheet in your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (Timesheet, ResultsMeta) UpdateTimesheet(
            Timesheet timesheet);

        /// <summary>
        /// Asynchronously Update Timesheets.
        /// </summary>
        /// <remarks>
        /// Edit one or more timesheets in your company.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Timesheet"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<Timesheet>, ResultsMeta)> UpdateTimesheetsAsync(
            IEnumerable<Timesheet> timesheets);

        /// <summary>
        /// Asynchronously Update Timesheets.
        /// </summary>
        /// <remarks>
        /// Edit a single timesheet in your company.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="Timesheet"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(Timesheet, ResultsMeta)> UpdateTimesheetAsync(
            Timesheet timesheet);

        /// <summary>
        /// Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be deleted.
        /// </param>
        void DeleteTimesheet(Timesheet timesheet);

        /// <summary>
        /// Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        void DeleteTimesheets(IEnumerable<Timesheet> timesheets);

        /// <summary>
        /// Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Timesheet"/> object to be deleted.
        /// </param>
        void DeleteTimesheet(int id);

        /// <summary>
        /// Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        void DeleteTimesheets(IEnumerable<int> ids);

        /// <summary>
        /// Asynchronously Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object.
        /// </remarks>
        /// <param name="timesheet">
        /// The <see cref="Timesheet"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        Task DeleteTimesheetAsync(Timesheet timesheet);

        /// <summary>
        /// Asynchronously Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects.
        /// </remarks>
        /// <param name="timesheets">
        /// The set of <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        Task DeleteTimesheetsAsync(IEnumerable<Timesheet> timesheets);

        /// <summary>
        /// Asynchronously Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete a single <see cref="Timesheet"/> object, by id.
        /// </remarks>
        /// <param name="id">
        /// The id of the <see cref="Timesheet"/> object to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        Task DeleteTimesheetAsync(int id);

        /// <summary>
        /// Asynchronously Delete Timesheets.
        /// </summary>
        /// <remarks>
        /// Delete one or more <see cref="Timesheet"/> objects, by id.
        /// </remarks>
        /// <param name="ids">
        /// The set of ids for the <see cref="Timesheet"/> objects to be deleted.
        /// </param>
        /// <returns>The asynchronous task.</returns>
        Task DeleteTimesheetsAsync(IEnumerable<int> ids);

        #endregion

        #region TimesheetsDeleted

        /// <summary>
        /// Retrieve Deleted Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all deleted timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetsDeletedFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimesheetsDeleted"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<TimesheetsDeleted>, ResultsMeta) GetTimesheetsDeleted(
            TimesheetsDeletedFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Retrieve Deleted Timesheets.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all deleted timesheets associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimesheetsDeletedFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimesheetsDeleted"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<TimesheetsDeleted>, ResultsMeta)> GetTimesheetsDeletedAsync(
            TimesheetsDeletedFilter filter,
            RequestOptions options = null);

        #endregion

        #region Users

        /// <summary>
        /// Create Users.
        /// </summary>
        /// <remarks>
        /// Add one or more users to your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<User>, ResultsMeta) CreateUsers(IEnumerable<User> users);

        /// <summary>
        /// Create Users.
        /// </summary>
        /// <remarks>
        /// Add a single user to your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (User, ResultsMeta) CreateUser(User user);

        /// <summary>
        /// Asynchronously Create Users.
        /// </summary>
        /// <remarks>
        /// Add one or more users to your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<User>, ResultsMeta)> CreateUsersAsync(IEnumerable<User> users);

        /// <summary>
        /// Asynchronously Create Users.
        /// </summary>
        /// <remarks>
        /// Add a single user to your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(User, ResultsMeta)> CreateUserAsync(User user);

        /// <summary>
        /// Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<User>, ResultsMeta) GetUsers(RequestOptions options = null);

        /// <summary>
        /// Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="UserFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        (IList<User>, ResultsMeta) GetUsers(
            UserFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<User>, ResultsMeta)> GetUsersAsync(RequestOptions options = null);

        /// <summary>
        /// Asynchronously Retrieve Users.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all users associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="UserFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="User"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        Task<(IList<User>, ResultsMeta)> GetUsersAsync(
            UserFilter filter,
            RequestOptions options = null);

        /// <summary>
        /// Update Users.
        /// </summary>
        /// <remarks>
        /// Edit one or more users in your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (IList<User>, ResultsMeta) UpdateUsers(IEnumerable<User> users);

        /// <summary>
        /// Update Users.
        /// </summary>
        /// <remarks>
        /// Edit a single user in your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        (User, ResultsMeta) UpdateUser(User user);

        /// <summary>
        /// Asynchronously Update Users.
        /// </summary>
        /// <remarks>
        /// Edit one or more users in your company.
        /// </remarks>
        /// <param name="users">
        /// The set of <see cref="User"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="User"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(IList<User>, ResultsMeta)> UpdateUsersAsync(IEnumerable<User> users);

        /// <summary>
        /// Asynchronously Update Users.
        /// </summary>
        /// <remarks>
        /// Edit a single user in your company.
        /// </remarks>
        /// <param name="user">
        /// The <see cref="User"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        Task<(User, ResultsMeta)> UpdateUserAsync(User user);

        #endregion
    }
}