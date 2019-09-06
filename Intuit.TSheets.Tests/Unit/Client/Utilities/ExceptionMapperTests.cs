// *******************************************************************************
// <copyright file="ExceptionMapperTests.cs" company="Intuit">
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

namespace Intuit.TSheets.Tests.Unit.Client.Utilities
{
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExceptionMapperTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ExceptionMapper_MapsClientExceptionsAsExpected()
        {
            Assert.IsInstanceOfType(ExceptionMapper.Map(400), typeof(BadRequestException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(401), typeof(UnauthorizedException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(402), typeof(BillingNotCurrentException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(404), typeof(NotFoundException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(405), typeof(MethodNotAllowedException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(406), typeof(NotAcceptableException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(409), typeof(ConflictException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(413), typeof(MaxItemsExceededException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(417), typeof(ExpectationFailedException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(429), typeof(TooManyRequestsException));
        }

        [TestMethod, TestCategory("Unit")]
        public void ExceptionMapper_MapsServerExceptionsAsExpected()
        {
            Assert.IsInstanceOfType(ExceptionMapper.Map(500), typeof(InternalServerException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(501), typeof(MethodNotImplementedException));
            Assert.IsInstanceOfType(ExceptionMapper.Map(503), typeof(ServiceUnavailableException));
        }

        [TestMethod, TestCategory("Unit")]
        public void ExceptionMapper_MapsUnmappedExceptionsAsExpected()
        {
            Assert.IsInstanceOfType(ExceptionMapper.Map(999), typeof(UnmappedApiException));
        }
    }
}
