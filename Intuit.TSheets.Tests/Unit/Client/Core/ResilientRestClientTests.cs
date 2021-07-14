// *******************************************************************************
// <copyright file="ResilientRestClientTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Polly;

    [TestClass]
    public class ResilientRestClientTests : UnitTestBase
    {
        private const int RetryCount = 3;
        private const float RetryExponent = 0.0f;
        private const float RetryMultiplier = 0.1f;
        private const string SuccessResult = "Done.";

        private EndpointName endpointName;
        private string inputData;
        private Dictionary<string, string> inputFilter;
        private List<long> deleteIds;
        private LogContext logContext;
        private Mock<IRestClient> mockRestClient;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            this.endpointName = EndpointName.Tests;
            this.inputData = "{ \"input\": \"data\" }";
            this.inputFilter = new Dictionary<string, string> { { "ids", "1,2,3"} };
            this.deleteIds = new List<long>{1, 2, 3};
            this.logContext = new LogContext();
            this.mockRestClient = new Mock<IRestClient>();
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateAsync_ExecutesRetryPolicyAsExpected()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.CreateAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<string>(j => j.Equals(this.inputData)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, string jd, LogContext lc, CancellationToken ct)
                    => throw new ServiceUnavailableException("Something went wrong."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.CreateAsync(this.endpointName, this.inputData, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (ServiceUnavailableException)
            {
            }

            // Verify our inner rest client was called 4 times (original invocation + retries)
            this.mockRestClient.Verify(m => m.CreateAsync(this.endpointName, this.inputData, this.logContext, default),
                Times.Exactly(RetryCount + 1));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateAsync_SucceedsOnFirstTryWhenNoExceptionIsThrown()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.CreateAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<string>(j => j.Equals(this.inputData)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("Done."));

            IRestClient restClient = GetRestClientWithRetries();
            
            string result = await restClient.CreateAsync(this.endpointName, this.inputData, this.logContext, default);

            Assert.AreEqual(SuccessResult, result, $"Expected result: '{SuccessResult}'.");

            // Verify our inner rest client was called only once.
            this.mockRestClient.Verify(m => m.CreateAsync(this.endpointName, this.inputData, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateAsync_FailsOnFirstTryWhenExceptionIsNotHandledByPolicy()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.CreateAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<string>(j => j.Equals(this.inputData)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, string jd, LogContext lc, CancellationToken ct)
                    => throw new BadRequestException("Bad request."));

            IRestClient restClient = GetRestClientWithRetries();

            try
            {
                await restClient.CreateAsync(this.endpointName, this.inputData, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (BadRequestException)
            {
            }

            // Verify our inner rest client was called exactly once.
            this.mockRestClient.Verify(m => m.CreateAsync(this.endpointName, this.inputData, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetAsync_ExecutesRetryPolicyAsExpected()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.GetAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<Dictionary<string, string>>(j => j.Equals(this.inputFilter)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, Dictionary<string, string> fi, LogContext lc, CancellationToken ct)
                    => throw new ServiceUnavailableException("Something went wrong."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.GetAsync(this.endpointName, this.inputFilter, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (ServiceUnavailableException)
            {
            }

            // Verify our inner rest client was called 4 times (original invocation + retries)
            this.mockRestClient.Verify(m => m.GetAsync(this.endpointName, this.inputFilter, this.logContext, default),
                Times.Exactly(RetryCount + 1));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetAsync_SucceedsOnFirstTryWhenNoExceptionIsThrown()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.GetAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<Dictionary<string, string>>(j => j.Equals(this.inputFilter)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("Done."));

            IRestClient restClient = GetRestClientWithRetries();

            string result = await restClient.GetAsync(this.endpointName, this.inputFilter, this.logContext, default);

            Assert.AreEqual(SuccessResult, result, $"Expected result: '{SuccessResult}'.");

            // Verify our inner rest client was called only once.
            this.mockRestClient.Verify(m => m.GetAsync(this.endpointName, this.inputFilter, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetAsync_FailsOnFirstTryWhenExceptionIsNotHandledByPolicy()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.GetAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<Dictionary<string, string>>(j => j.Equals(this.inputFilter)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, Dictionary<string, string> fi, LogContext lc, CancellationToken ct)
                    => throw new BadRequestException("Bad request."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.GetAsync(this.endpointName, this.inputFilter, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (BadRequestException)
            {
            }

            // Verify our inner rest client was called exactly once.
            this.mockRestClient.Verify(m => m.GetAsync(this.endpointName, this.inputFilter, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DownloadAsync_ExecutesRetryPolicyAsExpected()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.DownloadAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<Dictionary<string, string>>(j => j.Equals(this.inputFilter)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, Dictionary<string, string> fi, LogContext lc, CancellationToken ct)
                    => throw new ServiceUnavailableException("Something went wrong."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.DownloadAsync(this.endpointName, this.inputFilter, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (ServiceUnavailableException)
            {
            }

            // Verify our inner rest client was called 4 times (original invocation + retries)
            this.mockRestClient.Verify(m => m.DownloadAsync(this.endpointName, this.inputFilter, this.logContext, default),
                Times.Exactly(RetryCount + 1));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DownloadAsync_SucceedsOnFirstTryWhenNoExceptionIsThrown()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.DownloadAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<Dictionary<string, string>>(j => j.Equals(this.inputFilter)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Encoding.UTF8.GetBytes(SuccessResult)));

            IRestClient restClient = GetRestClientWithRetries();

            byte[] result = await restClient.DownloadAsync(this.endpointName, this.inputFilter, this.logContext, default);
            string resultString = Encoding.UTF8.GetString(result);

            Assert.AreEqual(SuccessResult, resultString, $"Expected result: '{SuccessResult}'.");

            // Verify our inner rest client was called only once.
            this.mockRestClient.Verify(m => m.DownloadAsync(this.endpointName, this.inputFilter, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DownloadAsync_FailsOnFirstTryWhenExceptionIsNotHandledByPolicy()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.DownloadAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<Dictionary<string, string>>(j => j.Equals(this.inputFilter)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, Dictionary<string, string> fi, LogContext lc, CancellationToken ct)
                    => throw new BadRequestException("Bad request."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.DownloadAsync(this.endpointName, this.inputFilter, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (BadRequestException)
            {
            }

            // Verify our inner rest client was called exactly once.
            this.mockRestClient.Verify(m => m.DownloadAsync(this.endpointName, this.inputFilter, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateAsync_ExecutesRetryPolicyAsExpected()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.UpdateAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<string>(j => j.Equals(this.inputData)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, string jd, LogContext lc, CancellationToken ct)
                    => throw new ServiceUnavailableException("Something went wrong."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.UpdateAsync(this.endpointName, this.inputData, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (ServiceUnavailableException)
            {
            }

            // Verify our inner rest client was called 4 times (original invocation + retries)
            this.mockRestClient.Verify(m => m.UpdateAsync(this.endpointName, this.inputData, this.logContext, default),
                Times.Exactly(RetryCount + 1));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateAsync_SucceedsOnFirstTryWhenNoExceptionIsThrown()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.UpdateAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<string>(j => j.Equals(this.inputData)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("Done."));

            IRestClient restClient = GetRestClientWithRetries();
            
            string result = await restClient.UpdateAsync(this.endpointName, this.inputData, this.logContext, default);

            Assert.AreEqual(SuccessResult, result, $"Expected result: '{SuccessResult}'.");

            // Verify our inner rest client was called only once.
            this.mockRestClient.Verify(m => m.UpdateAsync(this.endpointName, this.inputData, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateAsync_FailsOnFirstTryWhenExceptionIsNotHandledByPolicy()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.UpdateAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<string>(j => j.Equals(this.inputData)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, string jd, LogContext lc, CancellationToken ct)
                    => throw new BadRequestException("Bad request."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.UpdateAsync(this.endpointName, this.inputData, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (BadRequestException)
            {
            }

            // Verify our inner rest client was called exactly once.
            this.mockRestClient.Verify(m => m.UpdateAsync(this.endpointName, this.inputData, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteAsync_ExecutesRetryPolicyAsExpected()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.DeleteAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<IEnumerable<long>>(j => j.Equals(this.deleteIds)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, IEnumerable<long> di, LogContext lc, CancellationToken ct)
                    => throw new ServiceUnavailableException("Something went wrong."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.DeleteAsync(this.endpointName, this.deleteIds, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (ServiceUnavailableException)
            {
            }

            // Verify our inner rest client was called 4 times (original invocation + retries)
            this.mockRestClient.Verify(m => m.DeleteAsync(this.endpointName, this.deleteIds, this.logContext, default),
                Times.Exactly(RetryCount + 1));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteAsync_SucceedsOnFirstTryWhenNoExceptionIsThrown()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.DeleteAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<IEnumerable<long>>(j => j.Equals(this.deleteIds)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult("Done."));

            IRestClient restClient = GetRestClientWithRetries();

            string result = await restClient.DeleteAsync(this.endpointName, this.deleteIds, this.logContext, default);

            Assert.AreEqual(SuccessResult, result, $"Expected result: '{SuccessResult}'.");

            // Verify our inner rest client was called only once.
            this.mockRestClient.Verify(m => m.DeleteAsync(this.endpointName, this.deleteIds, this.logContext, default),
                Times.Once);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteAsync_FailsOnFirstTryWhenExceptionIsNotHandledByPolicy()
        {
            // Expect the parameters to be passed to the method of the inner rest client.
            // We'll throw an exception from within the callback method to trigger retries.
            this.mockRestClient
                .Setup(c => c.DeleteAsync(
                    It.Is<EndpointName>(e => e.Equals(this.endpointName)),
                    It.Is<IEnumerable<long>>(j => j.Equals(this.deleteIds)),
                    It.Is<LogContext>(l => l.Equals(this.logContext)),
                    It.IsAny<CancellationToken>()))
                .Callback((EndpointName en, IEnumerable<long> di, LogContext lc, CancellationToken ct)
                    => throw new BadRequestException("Bad request."));

            try
            {
                IRestClient restClient = GetRestClientWithRetries();
                await restClient.DeleteAsync(this.endpointName, this.deleteIds, this.logContext, default);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (BadRequestException)
            {
            }

            // Verify our inner rest client was called exactly once.
            this.mockRestClient.Verify(m => m.DeleteAsync(this.endpointName, this.deleteIds, this.logContext, default),
                Times.Once);
        }

        private IRestClient GetRestClientWithRetries()
        {
            // configure to retry 3 times with 100ms between attempts, and no backoff.
            var retrySettings = new RetrySettings(
                RetryCount,
                RetryExponent,
                RetryMultiplier,
                new[] { typeof(ServiceUnavailableException) });

            return new ResilientRestClient(
                retrySettings,
                this.mockRestClient.Object,
                MockLogger.Object);
        }
    }
}
