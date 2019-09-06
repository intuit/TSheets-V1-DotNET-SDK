<!-- Copyright (c) 2019 Intuit Inc. -->

TSheets-V1-DotNET-SDK
=============
<p align="center">
    <img src="./images/tsheetsbyqb37.svg" width="200" alt="Logo"/>
</p>

**Official C# .NET SDK for TSheets by QuickBooks**<br/><br/>

**License:** [![Apache 2](https://img.shields.io/badge/license-Apache--2-brightgreen)](http://www.apache.org/licenses/LICENSE-2.0)<br/>
**Support:** [![Help](https://img.shields.io/badge/Support-TSheets%20Developer-blue.svg)](https://www.tsheets.com/contact-tsheets)<br/>
**Documentation:** [![User Guide](https://img.shields.io/badge/User%20Guide-SDK%20Docs-blue.svg)](./Documentation/tsheets-sdk.md)<br/>
**Continuous Integration:** [![Build Status](https://travis-ci.com/intuit/TSheets-V1-DotNET-SDK.svg?token=HSEoRBBbbnL3x2dQy3Rm&branch=master)](https://travis-ci.com/intuit/TSheets-V1-DotNET-SDK.svg?token=HSEoRBBbbnL3x2dQy3Rm&branch=master)<br/>
**Binaries:** [![Nuget](https://img.shields.io/badge/Nuget-1.0.2-blue.svg)](https://www.nuget.org/packages/Intuit.TSheets/)<br/>

The TSheets .NET SDK provides class libraries for accessing the TSheets API quickly, easily, and with confidence.
It supports .Net Standard 2.0, and .Net Framework 4.7.2.

Some of the features include:

* Single and batch processing of CRUD operations for all TSheets API endpoints & operations.
* Filter objects for targeting queries.
* Full asynchronous method support (async/await).
* Easy access to the "supplemental data" available in TSheet's API method responses.
* Support for JSON request and response formats.
* Easy configurability to support a variety of API client behaviors.
* Auto-paging for the simple retrieval of entities spanning multiple pages.
* Auto-batching (for creates & updates).
* Automatic retries of transient errors, and the ability to custom configure.
* Common logging framework to support a variety of providers, e.g. Serilog, log4net, nlog, etc.
* Support for OAuth2 bearer tokens
* Quick start examples

## Documentation:
[User Guide](./Documentation/tsheets-sdk.md)<br/>
[API Reference](https://tsheetsteam.github.io/api_docs/#welcome)

## Get Started:
1. Clone this repo locally
2. Open the TSheets.sln solution file in your .NET IDE of choice.
3. See instructions in the Program.cs file of the Intuit.TSheets.Examples project.

## Contribute:
Please refer to [Contribution Guidelines](./.github/CONTRIBUTING.md) for details.
