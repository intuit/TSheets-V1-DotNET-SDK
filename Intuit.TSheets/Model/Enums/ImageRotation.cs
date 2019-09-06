// *******************************************************************************
// <copyright file="ImageRotation.cs" company="Intuit">
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

namespace Intuit.TSheets.Model.Enums
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Used with <see cref="FileMetadata"/> to specify the
    /// orientation of an image.
    /// </summary>
    public enum ImageRotation
    {
        /// <summary>
        /// An image rotated 0 degrees.
        /// </summary>
        [EnumMember(Value = "0")]
        Top,

        /// <summary>
        /// An image rotated 90 degrees.
        /// </summary>
        [EnumMember(Value = "90")]
        Right,

        /// <summary>
        /// An image rotated 180 degrees.
        /// </summary>
        [EnumMember(Value = "180")]
        Bottom,

        /// <summary>
        /// An image rotated 270 degrees.
        /// </summary>
        [EnumMember(Value = "270")]
        Left
    }
}
