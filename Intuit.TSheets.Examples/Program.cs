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
    using System;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Example TSheets App, for getting a quick start learning the SDK.
    /// </summary>
    public class Program
    {
        // To Use:
        // 1) Obtain an TSheets API access token (See https://tsheetsteam.github.io/api_docs/#getting-started)
        // 2) Paste your API access token into the AuthToken constant below.
        // 3) Set a breakpoint on the first line of the Demonstrate() method in the ExampleApp class.
        // 4) Debug the code, stepping into each of the demonstration methods. Note the log output in the console window.
        // 5) Try changing the logging level in the ConfigureServices() method to "Debug" or "Trace" to see increased log verbosity.

        private const string AuthToken = "<YOUR_AUTH_TOKEN>";

        /// <summary>
        /// Entry point for the TSheets SDK Example App.
        /// </summary>
        public static void Main()
        {
            try
            {
                // retrieve and configure the service collection
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);

                // create service provider
                var serviceProvider = serviceCollection.BuildServiceProvider();

                // run the demonstration app
                serviceProvider.GetService<ExampleApp>().Run(AuthToken);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                Console.Write("Done. <Enter> to exit...");
                Console.ReadLine();
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole().AddFilter(l => l >= LogLevel.Information);
            });

            // add services
            serviceCollection.AddTransient<IExampleAppService, ExampleAppService>();

            // add the app itself
            serviceCollection.AddTransient<ExampleApp>();
        }
    }
}
