using System;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Web.Noit.SubmitControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new SubmitController(mockSubmitService.Object, mockAuthenticationProvider.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void Constructor_ShouldThrowNullArgumentException_WhenServiceIsNull()
        {
            //Arrange
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new SubmitController(null, mockAuthenticationProvider.Object));
        }

        [Test]
        public void Constructor_ShouldThrowNullArgumentException_WhenAuthenticationProviderIsNull()
        {
            //Arrange
            var mockSubmitService = new Mock<ISubmitService>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new SubmitController(mockSubmitService.Object, null));
        }
    }
}
