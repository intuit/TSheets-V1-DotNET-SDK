// *******************************************************************************
// <copyright file="EffectiveSettings.cs" company="Intuit">
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

namespace Intuit.TSheets.Model
{
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// All combined, cascaded settings that apply to a given user are contained in the effective settings object.
    /// The effective settings object consists of a series of sections.  Each section contains a settings and a
    /// last modified property.  The settings property is a list of key/value pairs, and the last modified property
    /// gets updated any time a key/value pair within a section has changed.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class EffectiveSettings
    {
        /// <summary>
        /// Gets the set of sections, along with the setting values for each
        /// </summary>
        [JsonProperty("effective_settings")]
        public IReadOnlyDictionary<string, EffectiveSettingsSection> Sections { get; internal set; }
    }
}