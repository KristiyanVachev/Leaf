﻿using Leaf.Services.Contracts;
using Leaf.Services.Noit;
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
            var mockUserService = new Mock<IUserService>();

            //Act && Assert
            Assert.DoesNotThrow(() => new FullTestService(mockTestService.Object, mockUserService.Object));
        }

        //TODO add tests for each parameter to be null and values assigned correctly
    }
}
