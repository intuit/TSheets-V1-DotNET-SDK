// *******************************************************************************
// <copyright file="Program.cs" company="Intuit">
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

namespace Intuit.TSheets.Examples
{
    using Microsoft.Extensions.Logging;
    using System;

    internal class ExampleApp
    {
        private readonly IExampleAppService appService;
        private readonly ILogger<ExampleApp> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleApp"/> class.
        /// </summary>
        /// <param name="authToken">The authentication token.</param>
        public ExampleApp(IExampleAppService appService, ILogger<ExampleApp> logger)
        {
            this.appService = appService;
            this.logger = logger;
        }
        /// <summary>
        /// Runs the demonstration code in the app service.
        /// </summary>
        /// <param name="authToken">The OAuth token string to use for authentication.</param>
        public void Run(string authToken)
        {
            if (authToken.StartsWith("<"))
            {
                throw new InvalidOperationException(
                    "Replace AuthToken constant with a valid OAuth token.");
            }

            try
            {
                this.appService.Run(authToken, this.logger);
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "Error");
            }
        }
    }
}
