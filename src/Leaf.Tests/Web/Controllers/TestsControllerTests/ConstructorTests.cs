﻿using System;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Web.Controllers.TestsControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockFullTestService = new Mock<ITestService>();

            // Act
            var controller = new TestsController(mockFullTestService.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void Constructor_ShouldThrowNullArgumentException_WhenServiceIsNull()
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new TestsController(null));
        }
    }
}