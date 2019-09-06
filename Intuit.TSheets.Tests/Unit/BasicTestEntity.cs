// *******************************************************************************
// <copyright file="BasicTestEntity.cs" company="Intuit">
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
    using Intuit.TSheets.Model;
    using Newtonsoft.Json;

    [JsonObject]
    public class BasicTestEntity : IIdentifiable
    {
        public BasicTestEntity()
        {
        }

        public BasicTestEntity(int id)
        {
            Id = id;
        }

        public BasicTestEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            var other = (BasicTestEntity)obj;

            return other != null
                && Id.Equals(other.Id)
                && Name.Equals(other.Name);
        }

        public override int GetHashCode()
            => $"{Id}_{Name}".GetHashCode();
    }

}
