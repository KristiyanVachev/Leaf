using System;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void Constructor_ShouldThrowNullArgumentException_WhenServiceIsNull()
        {
            //Arrange
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new FullTestController(null, mockAuthenticationProvider.Object));
        }

        [Test]
        public void Constructor_ShouldThrowNullArgumentException_WhenAuthenticationProviderIsNull()
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new FullTestController(mockFullTestService.Object, null));
        }
    }
}
