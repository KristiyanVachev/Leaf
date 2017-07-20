﻿using Leaf.Auth.Contracts;
using Leaf.Services;
using Leaf.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullTestServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockUserService = new Mock<IUserService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            //Act && Assert
            Assert.DoesNotThrow(() => new TestsService(mockTestService.Object,
                mockQuestionService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object));
        }

        //TODO add tests for each parameter to be null and values assigned correctly
    }
}
