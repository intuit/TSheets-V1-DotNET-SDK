// *******************************************************************************
// <copyright file="Program.cs" company="Intuit">
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

namespace Intuit.TSheets.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Enums;
    using Intuit.TSheets.Model.Exceptions;
    using Intuit.TSheets.Model.Filters;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// This example class demonstrates a sampling of some of the key features of this SDK.
    /// It is meant to be a "quick-start" helper, and does not represent the comprehensive
    /// functionality of the SDK or API.
    /// </summary>
    internal class ExampleAppService : IExampleAppService
    {
        private ILogger logger;
        private DataService apiClient;

        /// <summary>
        /// A demonstration of a variety of get, create, and update calls to the TSheets API.
        /// Represents the basic steps to create users and clock them into a jobcode on a
        /// timesheet.
        /// </summary>
        /// <param name="authToken">
        /// The OAuth token value to use for authentication.
        /// </param>
        /// <param name="logger">
        /// An instance of a see <see cref="ILogger"/>, for logging.
        /// </param>
        public void Run(string authToken, ILogger logger)
        {
            this.logger = logger;
            this.apiClient = ExampleDataServiceFactory.CreateDataService(authToken, this.logger);

            // Cleanup data from a previous run of this example app (if applicable).
            // It's an idempotent method, so not a problem to run if cleanup has
            // already taken place.
            Cleanup();

            // Create some new users.
            CreateSingleUser();
            CreateMultipleUsers();
            GetUsers();

            // Assign users to a group.
            CreateANewGroupAndAssignUsers();
            ShowUserGroupAssignments();

            // Create some new jobcodes.
            CreateMultipleJobcodes();
            CreateSingleJobcode();

            // Create some new jobcodes with two-way sync enabled.
            // Two-way sync is a beta feature that will sync changes immediately to QBO.
            if (this.IsTwoWaySyncEnabled())
            {
                CreateSharedJobcode();
                CreateNotSharedJobcode();
            }
            else
            {
                try
                {
                    CreateSharedJobcode();
                }
                catch (MultiStatusException<Jobcode> e) {
                    this.logger.LogInformation("Caught expected exception for setting connect_with_quickbooks when two-way sync is not enabled.", e);
                }
            }

            // Create some new custom fields.
            CreateMultipleCustomFields();
            CreateSingleCustomField();

            // Clock one of the new users into one of the new jobcodes.
            (User user, Timesheet timesheet) = ClockAUserIntoATimesheet();
            SeeIfUserIsOnTheClock(user);
            ClockUserOutOfTimesheet(timesheet);
            SeeIfUserIsOnTheClock(user);

            // Retrieve some of the data we created.
            GetAsyncExample();

            // Retrieve users, but this time with a cancellation token.
            // An OperationCanceledException will be thrown if the
            // operation takes longer than 200ms to complete.
            try
            {
                var tokenSource = new CancellationTokenSource();
                tokenSource.CancelAfter(200);

                this.apiClient.GetUsersAsync(
                    new RequestOptions { PerPage = 1 },
                    tokenSource.Token).GetAwaiter().GetResult();
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation canceled.");
            }

            // Cleanup everything that was added.
            Cleanup();

            this.logger.LogInformation("Complete");
        }

        /// <summary>
        /// Remove (archive) all newly created users, groups, & jobcodes
        /// by updating the active state to false, if exists.
        /// </summary>
        private void Cleanup()
        {
            // Retrieve a list of users to archive (i.e. "soft delete")
            (IList<User> users, ResultsMeta resultsMeta) = this.apiClient.GetUsers(new UserFilter
            {
                UserNames = new[] { "bobsmith", "patrobbins", "raviagarwal" }
            });

            // De-activate all users returned
            if (users.Count > 0)
            {
                // First, retrieve any timesheet(s) for these users...
                (IList<Timesheet> timesheets, _) = this.apiClient.GetTimesheets(
                    new TimesheetFilter
                    {
                        UserIds = users.Select(u => u.Id),
                        ModifiedBefore = DateTimeOffset.Now
                    },
                    new RequestOptions { IncludeSupplementalData = false });

                // ...and delete them.
                if (timesheets.Count > 0)
                {
                    this.apiClient.DeleteTimesheets(timesheets);
                }

                users.ToList().ForEach(u => u.Active = false);
                this.apiClient.UpdateUsers(users);

                // Get the list of group ids to which these users belonged, from supplemental data. Archive them as well.
                IReadOnlyList<Group> groups = resultsMeta.SupplementalData.GetAll<Group>();

                if (groups.Count > 0)
                {
                    groups.ToList().ForEach(u => u.Active = false);
                    this.apiClient.UpdateGroups(groups);
                }
            }

            // Do the same for custom fields. Discard ResultsMeta since we won't be using it.
            (IList<CustomField> customFields, _) = this.apiClient.GetCustomFields(
                new RequestOptions { IncludeSupplementalData = false });

            List<CustomField> testCustomFields = customFields.Where(cf => cf.Name.StartsWith("TestCF")).ToList();
            if (testCustomFields.Count > 0)
            {
                testCustomFields.ForEach(cf => cf.Active = false);

                this.apiClient.UpdateCustomFields(testCustomFields);
            }

            // And also for jobcodes.
            (IList<Jobcode> jobcodes, _) = this.apiClient.GetJobcodes(
                new JobcodeFilter { Name = "TestJobcode*" },
                new RequestOptions { IncludeSupplementalData = false });

            if (jobcodes.Count > 0)
            {
                jobcodes.ToList().ForEach(j => j.Active = false);
                this.apiClient.UpdateJobcodes(jobcodes);
            }
        }

        /// <summary>
        /// Create a single new user.
        /// </summary>
        private void CreateSingleUser()
        {
            User newUser = this.apiClient.CreateUser(
                new User("patrobbins", "Pat", "Robbins")).Item1;

            this.logger.LogInformation("New user {UserName} created, id = {UserId}", newUser.Name, newUser.Id);
        }

        /// <summary>
        /// Create several new users.
        /// </summary>
        /// <remarks>
        /// This example demonstrates how to handle failures within a create or update batch.
        /// </remarks>
        private void CreateMultipleUsers()
        {
            try
            {
                this.apiClient.CreateUsers(new List<User>
                {
                    new User("bobsmith", "Bob", "Smith"),
                    new User("patrobbins", "Pat", "Robbins"),
                    new User("raviagarwal", "Ravi", "Agarwal"),

                    // intentional duplicate to cause an exception
                    new User("bobsmith", "Bob", "Smith")
                });
            }
            catch (MultiStatusException<User> e)
            {
                this.logger.LogInformation("The following items in the batch failed:");  // and the others succeeded.
                foreach (ErrorItem<User> error in e.FailureResults)
                {
                    this.logger.LogInformation(
                        "At index {Index}: {ErrorCode} ({ErrorMessage}) {ErrorExtra}",
                        error.Index,
                        error.Code,
                        error.Message,
                        error.Extra);
                }
            }
        }

        /// <summary>
        /// Create a new group and add a couple of new users to it.
        /// </summary>
        private void CreateANewGroupAndAssignUsers()
        {
            // First, create the new group
            Group newGroup = this.apiClient.CreateGroup(
                new Group("Plumbers")).Item1;

            // Find the users to be added to the group
            var filter = new UserFilter
            {
                UserNames = new[] { "bobsmith", "raviagarwal" }
            };
            IList<User> users = this.apiClient.GetUsers(filter).Item1;

            // Assign the new group id to each of the users
            foreach (User user in users)
            {
                user.GroupId = newGroup.Id;
            }

            // Update with the new group assignments
            this.apiClient.UpdateUsers(users);
        }

        /// <summary>
        /// Retrieve all users.
        /// </summary>
        /// <remarks>
        /// Note the different ways of handling the tuple return values, depending on your
        /// needs for supplemental data and pagination info. For more info, see:
        /// https://tsheetsteam.github.io/api_docs/#handling-supplemental-timesheet-data
        /// </remarks>
        private void GetUsers()
        {
            // If you'll be using the results metadata, use this format:
            (IList<User> usersA, ResultsMeta meta) = this.apiClient.GetUsers();

            //// BUT, if it's not needed, you can discard it, like this:
            (IList<User> usersB, _) = this.apiClient.GetUsers();

            // OR even like this:
            IList<User> usersC = this.apiClient.GetUsers().Item1;
        }

        /// <summary>
        /// Create multiple jobcodes.
        /// </summary>
        private void CreateMultipleJobcodes()
        {
            var jobcodes = new List<Jobcode>
            {
                new Jobcode { Name = "TestJobcode1" },
                new Jobcode { Name = "TestJobcode2" }
            };

            this.apiClient.CreateJobcodes(jobcodes);
        }

        /// <summary>
        /// Create a single jobcode, and then link an address to it.
        /// </summary>
        private void CreateSingleJobcode()
        {
            var jobcode = this.apiClient.CreateJobcode(
                new Jobcode { Name = "TestJobcode3" }).Item1;

            var location = new Location
            {
                Addr1 = "235 E Colchester Dr.",
                City = "Eagle",
                State = "ID",
                Zip = "83616",
                LinkedObjects = new LocationLinkedObjectIds
                {
                    Jobcodes = new List<int> { jobcode.Id }
                }
            };

            this.apiClient.CreateLocation(location);
        }

        /// <summary>
        /// Create multiple custom fields.
        /// </summary>
        private void CreateMultipleCustomFields()
        {
            // names of custom fields and short codes in TSheets cannot be repeated, so we need
            // to generate unique values for each invocation of the app.
            long runId = DateTimeOffset.Now.ToUnixTimeSeconds();

            var customFields = new List<CustomField>
            {
                new CustomField($"TestCF_A{runId}", CustomFieldValueType.Freeform)
                {
                    Active = true,
                    // short codes must be limited to 8 characters
                    ShortCode = $"TA{runId % 1000000}",
                    ShowToAll = true,
                    Required = false
                },
                new CustomField($"TestCF_B{runId}", CustomFieldValueType.ManagedList)
                {
                    Active = true,
                    ShortCode = $"TB{runId % 1000000}",
                    ShowToAll = true,
                    Required = false
                }
            };

            this.apiClient.CreateCustomFields(customFields);
        }

        /// <summary>
        /// Create a jobcode that is shared with QuickBooks.
        /// </summary>
        private void CreateSharedJobcode()
        {
            this.apiClient.CreateJobcode(
                new Jobcode
                {
                    Name = "TestJobcode4",
                    ConnectWithQuickBooks = true
                });
        }

        /// <summary>
        /// Create a jobcode that is not shared with QuickBooks.
        /// </summary>
        private void CreateNotSharedJobcode()
        {
            this.apiClient.CreateJobcode(
                new Jobcode
                {
                    Name = "TestJobcode5",
                    ConnectWithQuickBooks = false
                });
        }

        /// <summary>
        /// Create a single custom field.
        /// </summary>
        private void CreateSingleCustomField()
        {
            // names of custom fields and short codes in TSheets cannot be repeated, so we need
            // to generate unique values for each invocation of the app.
            long runId = DateTimeOffset.Now.ToUnixTimeSeconds();

            var customField = new CustomField($"TestCF_C{runId}", CustomFieldValueType.Freeform)
            {
                Active = true,

                // short codes must be limited to 8 characters
                ShortCode = $"TC{runId % 1000000}",
                ShowToAll = true,
                Required = false
            };

            this.apiClient.CreateCustomField(customField);
        }

        /// <summary>
        /// Clock a user into a jobcode, on a timesheet.
        /// </summary>
        /// <returns>A tuple of the user and timesheet.</returns>
        private (User, Timesheet) ClockAUserIntoATimesheet()
        {
            // Get the user id
            var userFilter = new UserFilter { UserNames = new[] { "bobsmith" } };
            IList<User> users = this.apiClient.GetUsers(userFilter).Item1;

            User user = users.First();

            // Now get the jobcode id.
            var jobcodeFilter = new JobcodeFilter { Name = "TestJobcode3" };
            IList<Jobcode> jobcodes = this.apiClient.GetJobcodes(jobcodeFilter).Item1;

            Jobcode jobcode = jobcodes.First();

            // Now clock the user into the jobcode. Note that active (i.e. "on-the-clock") timesheets
            // are created with an End time of DateTimeOffset.MinValue. The dedicated constructor
            // we're using here does that for you automatically.
            var timesheetToCreate = new Timesheet(user.Id, jobcode.Id, DateTimeOffset.Now);
            var createdTimesheet = this.apiClient.CreateTimesheet(timesheetToCreate).Item1;

            return (user, createdTimesheet);
        }

        /// <summary>
        /// Check to see if a particular user is currently clocked-in to a timesheet.
        /// </summary>
        /// <remarks>
        /// See also https://tsheetsteam.github.io/api_docs/#recipes-for-some-common-workflows
        /// </remarks>
        /// <param name="user">The user to check.</param>
        private void SeeIfUserIsOnTheClock(User user)
        {
            // Note how we're disabling the return of supplemental data, since it won't be used.
            IEnumerable<Timesheet> timesheets = this.apiClient.GetTimesheets(
                new TimesheetFilter
                {
                    UserIds = new[] { user.Id },
                    OnTheClock = TristateChoice.Yes,
                    StartDate = DateTimeOffset.Now.AddDays(-7)
                },
                new RequestOptions
                {
                    IncludeSupplementalData = false
                }).Item1;

            string status = timesheets.Any() ? "IS" : "IS NOT";

            this.logger.LogInformation(
                "User {UserName} {Status} on the clock.",
                user.Name,
                status);
        }

        /// <summary>
        /// Clock the user out of the timesheet by updating the End time.
        /// </summary>
        /// <param name="timesheet">The timesheet to update.</param>
        private void ClockUserOutOfTimesheet(Timesheet timesheet)
        {
            timesheet.End = DateTimeOffset.Now;
            this.apiClient.UpdateTimesheet(timesheet);
        }

        /// <summary>
        /// Show the group to which each user belongs (if any).
        /// </summary>
        /// <remarks>
        /// This method demonstrates how to access supplemental data.
        /// </remarks>
        private void ShowUserGroupAssignments()
        {
            // Retrieve all users
            (IEnumerable<User> users, ResultsMeta resultsMeta) = this.apiClient.GetUsers();

            foreach (User user in users)
            {
                // If the user's GroupId property has a valid value, index it into the supplemental data
                // object to retrieve the Group object.
                if (user.GroupId.HasValue && user.GroupId.Value > 0)
                {
                    Group group = resultsMeta.SupplementalData.GetById<Group>(user.GroupId.Value);

                    this.logger.LogInformation(
                        "User '{UserName}' belongs to group '{GroupName}'.",
                        user.Name,
                        group.Name);

                }
                else
                {
                    this.logger.LogInformation(
                        "User '{UserName}' does not belong to a group.",
                        user.Name);
                }
            }
        }

        /// <summary>
        /// Retrieve data from multiple endpoints in parallel, using asynchronous methods.
        /// Also demonstrates auto and manual paging.
        /// </summary>
        private void GetAsyncExample()
        {
            // Setup async tasks to retrieve our data and execute in parallel

            // Reduce the page size to demonstrate the auto-paging feature. See the logs
            // for the multiple calls to retrieve users (provided your account contains
            // more than two).
            Task<(IList<User>, ResultsMeta)> getUsersTask = this.apiClient.GetUsersAsync(
                new RequestOptions { PerPage = 2 });

            // Disable auto-paging to take direct control over results.  Retrieve a subset
            // of jobcodes, starting with page 2.
            Task<(IList<Jobcode>, ResultsMeta)> getJobcodesTask = this.apiClient.GetJobcodesAsync(
                new RequestOptions { AutoPaging = false, Page = 2, PerPage = 1 });

            // Block until both are finished
            Task.WaitAll(getUsersTask, getJobcodesTask);

            // And now access the results.
            IList<User> users = getUsersTask.Result.Item1;
            IList<Jobcode> jobcodes = getJobcodesTask.Result.Item1;

            this.logger.LogInformation(
                "Retrieved {UserCount} user(s) and {JobcodeCount} jobcode(s).",
                users.Count(),
                jobcodes.Count());
        }

        /// <summary>
        /// Determine if two-way sync is enabled.
        /// Two-way sync is a beta feature that will sync changes immediately to QBO.
        /// </summary>
        private bool IsTwoWaySyncEnabled()
        {
            EffectiveSettings effectiveSettings = this.apiClient.GetEffectiveSettings();
            var quickBooksSettings = effectiveSettings.Sections.FirstOrDefault(a => a.Key.Equals("quickbooks"));
            if (quickBooksSettings.Key != null)
            {
                var twoWaySyncEnabled = quickBooksSettings.Value.Settings.FirstOrDefault(a => a.Key.Equals("two_way_sync_enabled_for_user"));
                if (twoWaySyncEnabled.Value != null)
                {
                    return twoWaySyncEnabled.Value.ToString() == "1";
                }
            }
            return false;
        }
    }
}
