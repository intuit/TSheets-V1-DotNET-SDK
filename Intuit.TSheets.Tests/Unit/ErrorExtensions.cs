﻿// *******************************************************************************
// <copyright file="ErrorExtensions.cs" company="Intuit">
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
    using Intuit.TSheets.Api;

    internal static class ErrorExtensions
    {
        internal static bool StatusIsEqualTo<T>(this ErrorItem<T> error, ErrorItem<T> otherError)
            => GetStatusHashCode(error) == GetStatusHashCode(otherError);


        internal static int GetStatusHashCode<T>(ErrorItem<T> error)
            => $"{error.Id}_{error.Code}_{error.Message}_{error.Extra}".GetHashCode();
    }
}
