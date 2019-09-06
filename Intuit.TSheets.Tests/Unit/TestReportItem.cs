// *******************************************************************************
// <copyright file="TestReportItem.cs" company="Intuit">
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
    using Newtonsoft.Json;

    [JsonObject]
    public class TestReportItem
    {
        public TestReportItem(int id, string name, float sum)
        {
            Id = id;
            Name = name;
            Sum = sum;
        }

        [JsonProperty("id")]
        public int Id { get; }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("sum")]
        public float Sum { get; }

        public override bool Equals(object obj)
        {
            var other = (TestReportItem)obj;

            return other != null
                && Id.Equals(other.Id)
                && Name.Equals(other.Name)
                && Sum.Equals(other.Sum);
        }

        public override int GetHashCode()
            => $"{Id}_{Name}_{Sum}".GetHashCode();
    }

}
