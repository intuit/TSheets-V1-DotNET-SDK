// *******************************************************************************
// <copyright file="File.cs" company="Intuit">
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
    using System;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Newtonsoft.Json;

    /// <summary>
    /// An image file that can be attached to Timesheets. This is especially useful for workers in the field,
    /// for example, who may need to provide visual proof of completion of a job, or to document exceptional
    /// conditions which may arise while on the clock.
    /// </summary>
    [DataEntity]
    [JsonObject]
    public class File : IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        public File()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class,
        /// with minimal required parameters to create the new entity.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file.
        /// </param>
        /// <param name="fileData">
        /// The base64 encoded string of this file.
        /// </param>
        public File(string fileName, string fileData)
        {
            FileName = fileName;
            FileData = fileData;
        }

        /// <summary>
        /// Gets the id of this file.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the name of this file.
        /// </summary>
        [JsonProperty("file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the base64 encoded string of this file.
        /// </summary>
        /// <remarks>
        /// May only be set when adding a file. Not displayed in response
        /// to a request to list files or in supplemental data.
        /// </remarks>
        [JsonProperty("file_data")]
        public string FileData { get; set; }

        /// <summary>
        /// Gets the id of the user that uploaded this file.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("uploaded_by_user_id")]
        public int? UploadedByUserId { get; internal set; }

        /// <summary>
        /// Gets the value indicating whether this file is considered deleted.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("active")]
        public bool? Active { get; internal set; }

        /// <summary>
        /// Gets the size of the file in bytes.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("size")]
        public int? Size { get; internal set; }

        /// <summary>
        /// Gets the date/time when this file was created.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// Gets the date/time when this file was last modified.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonProperty("last_modified")]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Gets the key/value map of all the types linked to this file and the corresponding object ids.
        /// </summary>
        [NoSerializeOnWrite]
        [JsonConverter(typeof(EmptyArrayObjectConverter))]
        [JsonProperty("linked_objects")]
        public FileLinkedObjectIds LinkedObjects { get; internal set; }

        /// <summary>
        /// Gets or sets the additional data associated with this file.
        /// </summary>
        [JsonConverter(typeof(EmptyArrayObjectConverter))]
        [JsonProperty("meta_data")]
        public FileMetadata Metadata { get; set; }
    }
}
