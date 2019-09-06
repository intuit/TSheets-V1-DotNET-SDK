// *******************************************************************************
// <copyright file="TestEntity.cs" company="Intuit">
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
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Intuit.TSheets.Model;
    using Newtonsoft.Json;

    [DataEntity]
    [JsonObject]
    public class TestEntity : IIdentifiable
    {
        public TestEntity()
        {
        }

        public TestEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("employee_id")]
        public int EmployeeId { get; set; }

        [JsonProperty("manager_of_ids")]
        public IList<int> ManagerOfIds { get; set; }

        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }
    }

}
