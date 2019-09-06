// *******************************************************************************
// <copyright file="IOAuth2.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Core
{
    /// <summary>
    /// Interface for the OAuth2 access token information needed for API access
    /// </summary>
    public interface IOAuth2
    {
        /// <summary>
        /// Called by the client API class to retrieve a token that can be used for authentication.
        /// Implementation should handle obtaining a new token/refreshing token if necessary.
        /// </summary>
        /// <returns>Access token</returns>
        string GetAccessToken();
    }
}
