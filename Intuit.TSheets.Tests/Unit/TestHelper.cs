// *******************************************************************************
// <copyright file="TestHelper.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Intuit.TSheets.Client.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    internal static class TestHelper
    {
        internal static EndpointName GetEndpoint(string methodName)
        {
            if (methodName.Contains("Report"))
            {
                if (methodName.Contains("CurrentTotalsReport"))
                {
                    return EndpointName.CurrentTotalsReports;
                }

                if (methodName.Contains("PayrollReport"))
                {
                    return EndpointName.PayrollReports;
                }

                if (methodName.Contains("PayrollByJobcodeReport"))
                {
                    return EndpointName.PayrollByJobcodeReports;
                }

                if (methodName.Contains("ProjectReport"))
                {
                    return EndpointName.ProjectReports;
                }

                throw new Exception($"Can't determine report endpoint from method name '{methodName}'.");
            }

            if (methodName.Contains("CurrentUser"))
            {
                return EndpointName.CurrentUser;
            }

            if (methodName.Contains("CustomFieldItem"))
            {
                return EndpointName.CustomFieldItems;
            }

            if (methodName.Contains("CustomField"))
            {
                return EndpointName.CustomFields;
            }

            if (methodName.Contains("EffectiveSetting"))
            {
                return EndpointName.EffectiveSettings;
            }

            if (methodName.Contains("File"))
            {
                return EndpointName.Files;
            }

            if (methodName.Contains("GeofenceConfig"))
            {
                return EndpointName.GeofenceConfigs;
            }

            if (methodName.Contains("Geolocation"))
            {
                return EndpointName.Geolocations;
            }

            if (methodName.Contains("Group"))
            {
                return EndpointName.Groups;
            }

            if (methodName.Contains("Invitation"))
            {
                return EndpointName.Invitations;
            }

            if (methodName.Contains("JobcodeAssignment"))
            {
                return EndpointName.JobcodeAssignments;
            }

            if (methodName.Contains("Jobcode"))
            {
                return EndpointName.Jobcodes;
            }

            if (methodName.Contains("LastModifiedTimestamp"))
            {
                return EndpointName.LastModifiedTimestamps;
            }

            if (methodName.Contains("LocationsMap"))
            {
                return EndpointName.LocationsMaps;
            }

            if (methodName.Contains("Location"))
            {
                return EndpointName.Locations;
            }

            if (methodName.Contains("ManagedClients"))
            {
                return EndpointName.ManagedClients;
            }

            if (methodName.Contains("Notification"))
            {
                return EndpointName.Notifications;
            }

            if (methodName.Contains("Reminder"))
            {
                return EndpointName.Reminders;
            }

            if (methodName.Contains("ScheduleCalendar"))
            {
                return EndpointName.ScheduleCalendars;
            }

            if (methodName.Contains("ScheduleEvent"))
            {
                return EndpointName.ScheduleEvents;
            }

            if (methodName.Contains("TimesheetsDeleted"))
            {
                return EndpointName.TimesheetsDeleted;
            }

            if (methodName.Contains("Timesheet"))
            {
                return EndpointName.Timesheets;
            }

            if (methodName.Contains("User"))
            {
                return EndpointName.Users;
            }
            
            throw new Exception($"Can't determine endpoint from method name '{methodName}'.");
        }

        internal static void AssertJsonEqual(string expected, string actual)
        {
            expected = $"{{ \"value\": {expected} }}";
            actual = $"{{ \"value\": {actual} }}";

            if (JToken.DeepEquals(JObject.Parse(expected), JObject.Parse(actual)))
            {
                return;
            }

            JObject diff = ExplainJsonDiff(JObject.Parse(expected), JObject.Parse(actual));
            Assert.Fail("Json Objects Differ:\n\n" + diff);
        }

        internal static JObject ExplainJsonDiff(JToken expected, JToken actual)
        {
            var diff = new JObject();
            if (JToken.DeepEquals(expected, actual)) return diff;

            switch (expected.Type)
            {
                case JTokenType.Object:
                    {
                        if (actual is JObject actualJObject && expected is JObject expectedJObject)
                        {
                            IEnumerable<string> addedKeys = expectedJObject.Properties().Select(c => c.Name).Except(actualJObject.Properties().Select(c => c.Name));
                            IEnumerable<string> removedKeys = actualJObject.Properties().Select(c => c.Name).Except(expectedJObject.Properties().Select(c => c.Name));
                            IEnumerable<string> unchangedKeys = expectedJObject.Properties().Where(c => JToken.DeepEquals(c.Value, actual[c.Name])).Select(c => c.Name);

                            IEnumerable<string> enumerable = addedKeys as string[] ?? addedKeys.ToArray();
                            foreach (string k in enumerable)
                            {
                                diff[k] = new JObject
                                {
                                    ["<EXPECTED>"] = expected[k]
                                };
                            }
                            foreach (string k in removedKeys)
                            {
                                diff[k] = new JObject
                                {
                                    ["<ACTUAL>"] = actual[k]
                                };
                            }
                            IEnumerable<string> keysToCheck = expectedJObject.Properties().Select(c => c.Name).Except(enumerable).Except(unchangedKeys);
                            foreach (string k in keysToCheck)
                            {
                                diff[k] = ExplainJsonDiff(expectedJObject[k], actualJObject[k]);
                            }
                        }
                    }
                    break;
                case JTokenType.Array:
                    {
                        var expectedJArray = expected as JArray;
                        var actualJArray = actual as JArray;

                        diff["<EXPECTED>"] = actualJArray != null
                            ? new JArray(expectedJArray?.Except(actualJArray))
                            : expectedJArray;

                        diff["<ACTUAL>"] = expectedJArray != null
                            ? new JArray(actualJArray?.Except(expectedJArray))
                            : actualJArray;
                    }
                    break;
                default:
                    diff["<EXPECTED>"] = expected;
                    diff["<ACTUAL>"] = actual;
                    break;
            }

            return diff;
        }
    }
}
