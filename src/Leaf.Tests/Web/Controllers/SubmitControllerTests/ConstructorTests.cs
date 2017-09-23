using System;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
using Leaf.Web.Models;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Web.Controllers.SubmitControllerTests
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
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object, 
                mockViewModelFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void Constructor_ShouldThrowNullArgumentException_WhenServiceIsNull()
        {
            //Arrange
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new SubmitController(null, mockAuthenticationProvider.Object, mockViewModelFactory.Object));
        }

        [Test]
        public void Constructor_ShouldThrowNullArgumentException_WhenAuthenticationProviderIsNull()
        {
            //Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new SubmitController(mockSubmitService.Object, null, mockViewModelFactory.Object));
        }
    }
}
