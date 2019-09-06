// *******************************************************************************
// <copyright file="FileMetadata.cs" company="Intuit">
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
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Additional data associated with a file.
    /// </summary>
    [JsonObject]
    public class FileMetadata
    {
        /// <summary>
        /// Gets or sets the description of this file.
        /// </summary>
        [JsonProperty("file_description")]
        public string FileDescription { get; set; }

        /// <summary>
        /// Gets or sets the image orientation in degrees.
        /// </summary>
        /// <remarks>
        /// See <see cref="ImageRotation"/> for allowable values.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("image_rotation")]
        public ImageRotation? ImageRotation { get; set; }
    }
}
