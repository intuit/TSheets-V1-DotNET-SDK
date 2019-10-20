// *******************************************************************************
// <copyright file="RestClientTests.cs" company="Intuit">
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
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class FakeLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class RestClientTests
    {
        private readonly static Uri ExpectedUri = new Uri("https://rest.tsheets.com/api/v1/tests");
        private DataServiceContext dummyServiceContext;
        private Mock<ILogger> mockLogger;

        [TestInitialize]
        public void Initialize()
        {
            this.dummyServiceContext = new DataServiceContext("token");
            this.mockLogger = new Mock<ILogger>();
        }

        [TestMethod, TestCategory("Unit")]
        public void RestClient_HttpClientIsCorrectlyInitialized()
        {
            var httpClient = new HttpClient();

            var restClient = new RestClient(
                this.dummyServiceContext,
                httpClient,
                this.mockLogger.Object);

            Assert.AreEqual(
                this.dummyServiceContext.ConnectionInfo.BaseUri,
                httpClient.BaseAddress,
                "Expected the base URI to be set");

            string expectedToken = this.dummyServiceContext.AuthProvider.GetAccessToken();

            Assert.AreEqual(
                $"Bearer {expectedToken}",
                httpClient.DefaultRequestHeaders.GetValues("Authorization").FirstOrDefault(),
                "Expected the Authorization header to be set");

            Assert.AreEqual(
                $"application/json",
                httpClient.DefaultRequestHeaders.GetValues("Accept").FirstOrDefault(),
                "Expected the Accept header to be set");

            Assert.AreEqual(
                $"TSheets-V1-DotNET-SDK",
                httpClient.DefaultRequestHeaders.UserAgent.FirstOrDefault().Product.Name,
                "Expected the UserAgent header to be set with product name.");
        }

        [TestMethod, TestCategory("Unit")]
        public void RestClient_HttpClientIsCorrectlyInitializedWithManagedClient()
        {
            var httpClient = new HttpClient();

            DataServiceContext dummyServiceContext = this.dummyServiceContext;
            dummyServiceContext.ManagedClientId = 123;

            var restClient = new RestClient(
                this.dummyServiceContext,
                httpClient,
                this.mockLogger.Object);

            Assert.AreEqual(
                $"123",
                httpClient.DefaultRequestHeaders.GetValues("vnd.tsheets.ManagedClientId").FirstOrDefault(),
                "Expected the managed client header to be set");
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateAsync_ReturnsExpectedResponse()
        {
            string expectedResponse = "success";

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.CreateAsync(EndpointName.Tests, "input data", new LogContext(), default).ConfigureAwait(false);

            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task CreateAsync_IsCalledWithExpectedInputs()
        {
            string expectedRequest = "input data";

            var mockHttpClient = GetMockHttpClient(
                (HttpRequestMessage request, CancellationToken token) =>
                {
                    Assert.AreEqual(HttpMethod.Post, request.Method);
                    Assert.AreEqual(ExpectedUri, request.RequestUri);
                    Assert.IsInstanceOfType(request.Content, typeof(StringContent));
                    Assert.AreEqual(expectedRequest, request.Content.ReadAsStringAsync().Result);
                },
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("success"),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            await restClient.CreateAsync(EndpointName.Tests, expectedRequest, new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ExpectationFailedException))]
        public async Task CreateAsync_ThrowsOnError()
        {
            string expectedResponse = "expectation failed";

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(expectedResponse),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.CreateAsync(EndpointName.Tests, "input data", new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateAsync_ReturnsExpectedResponse()
        {
            string expectedResponse = "success";

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.UpdateAsync(EndpointName.Tests, "input data", new LogContext(), default).ConfigureAwait(false);

            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task UpdateAsync_IsCalledWithExpectedInputs()
        {
            string expectedRequest = "input data";

            var mockHttpClient = GetMockHttpClient(
                (HttpRequestMessage request, CancellationToken token) =>
                {
                    Assert.AreEqual(HttpMethod.Put, request.Method);
                    Assert.AreEqual(ExpectedUri, request.RequestUri);
                    Assert.IsInstanceOfType(request.Content, typeof(StringContent));
                    Assert.AreEqual(expectedRequest, request.Content.ReadAsStringAsync().Result);
                },
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("success"),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            await restClient.UpdateAsync(EndpointName.Tests, expectedRequest, new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ExpectationFailedException))]
        public async Task UpdateAsync_ThrowsOnError()
        {
            string expectedResponse = "expectation failed";

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(expectedResponse),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.UpdateAsync(EndpointName.Tests, "input data", new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetAsync_ReturnsExpectedResponse()
        {
            string expectedResponse = "success";

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.GetAsync(EndpointName.Tests, null, new LogContext(), default).ConfigureAwait(false);

            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task GetAsync_IsCalledWithExpectedInputs()
        {
            Uri expectedUri = new Uri("https://rest.tsheets.com/api/v1/tests?key1=value1&key2=value2");
            var filters = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            var mockHttpClient = GetMockHttpClient(
                (HttpRequestMessage request, CancellationToken token) =>
                {
                    Assert.AreEqual(HttpMethod.Get, request.Method);
                    Assert.AreEqual(expectedUri, request.RequestUri);
                },
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("success"),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            await restClient.GetAsync(EndpointName.Tests, filters, new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task GetAsync_ThrowsOnError()
        {
            var filters = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("unauthorized"),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.GetAsync(EndpointName.Tests, filters, new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DownloadAsync_ReturnsExpectedResponse()
        {
            byte[] expectedResponse = new byte[]{ 255 };

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ByteArrayContent(expectedResponse)
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.DownloadAsync(EndpointName.Tests, null, new LogContext(), default).ConfigureAwait(false);

            Assert.IsTrue(expectedResponse.SequenceEqual(actualResponse));
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DownloadAsync_IsCalledWithExpectedInputs()
        {
            Uri expectedUri = new Uri("https://rest.tsheets.com/api/v1/tests?key1=value1&key2=value2");
            var filters = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            var mockHttpClient = GetMockHttpClient(
                (HttpRequestMessage request, CancellationToken token) =>
                {
                    Assert.AreEqual(HttpMethod.Get, request.Method);
                    Assert.AreEqual(expectedUri, request.RequestUri);
                },
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("success"),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            await restClient.DownloadAsync(EndpointName.Tests, filters, new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task DownloadAsync_ThrowsOnError()
        {
            var filters = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("unauthorized"),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.DownloadAsync(EndpointName.Tests, filters, new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteAsync_ReturnsExpectedResponse()
        {
            var expectedRequest = new int[] { 1, 2, 3 };
            string expectedResponse = "success";

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.DeleteAsync(EndpointName.Tests, expectedRequest, new LogContext(), default).ConfigureAwait(false);

            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestMethod, TestCategory("Unit")]
        public async Task DeleteAsync_IsCalledWithExpectedInputs()
        {
            Uri expectedUri = new Uri("https://rest.tsheets.com/api/v1/tests?ids=1%2C2%2C3");
            var expectedRequest = new int[] { 1, 2, 3 };

            var mockHttpClient = GetMockHttpClient(
                (HttpRequestMessage request, CancellationToken token) =>
                {
                    Assert.AreEqual(HttpMethod.Delete, request.Method);
                    Assert.AreEqual(expectedUri, request.RequestUri);
                },
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("success"),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            await restClient.DeleteAsync(EndpointName.Tests, expectedRequest, new LogContext(), default).ConfigureAwait(false);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ExpectationFailedException))]
        public async Task DeleteAsync_ThrowsOnError()
        {
            var expectedRequest = new int[] { 1, 2, 3 };

            var mockHttpClient = GetMockHttpClient(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent("expectation failed"),
                });

            var restClient = new RestClient(
                this.dummyServiceContext,
                mockHttpClient,
                this.mockLogger.Object);

            var actualResponse = await restClient.DeleteAsync(EndpointName.Tests, expectedRequest, new LogContext(), default).ConfigureAwait(false);
        }

        private HttpClient GetMockHttpClient(
            Action<HttpRequestMessage, CancellationToken> callback,
            HttpResponseMessage response)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .Callback(callback)
               .ReturnsAsync(response)
               .Verifiable();

            return new HttpClient(mockMessageHandler.Object);
        }

        private HttpClient GetMockHttpClient(HttpResponseMessage response)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response)
               .Verifiable();

            return new HttpClient(mockMessageHandler.Object);
        }
    }
}
