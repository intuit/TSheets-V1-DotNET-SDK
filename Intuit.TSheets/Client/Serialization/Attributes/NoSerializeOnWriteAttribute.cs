﻿// *******************************************************************************
// <copyright file="NoSerializeOnWriteAttribute.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Serialization.Attributes
{
    using System;

    /// <summary>
    /// A custom attribute used to prevent selected entity properties
    /// from being serialized prior to either a POST or PUT call.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class NoSerializeOnWriteAttribute : Attribute
    {
    }
}
