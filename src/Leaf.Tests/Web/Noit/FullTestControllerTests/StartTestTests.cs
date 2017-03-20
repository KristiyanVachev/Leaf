using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Leaf.Web.Areas.Noit.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class StartTestTests
    {
        [Test]
        public void StartTest_ShouldCallAutnenticationProviderCurrentUserId()
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            mockFullTestService.Setup(x => x.GetUserTest(It.IsAny<string>())).Returns(new Test { Id = 0 });

            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.StartTest();

            //Assert
            mockAuthenticationProvider.Verify(x => x.CurrentUserId, Times.Once);
        }

        [TestCase("das34qwd-dsa2dws")]
        public void StartTest_ShouldCallServiceGetUserTest(string userId)
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            mockFullTestService.Setup(x => x.GetUserTest(It.IsAny<string>())).Returns(new Test { Id = 0 });

            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(userId);

            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.StartTest();

            //Assert
            mockFullTestService.Verify(x => x.GetUserTest(userId), Times.Once);
        }

        [Test]
        public void StartTest_ShouldRedirectToTestActionMethod()
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            mockFullTestService.Setup(x => x.GetUserTest(It.IsAny<string>())).Returns(new Test { Id = 0 });

            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act && Assert
            controller.WithCallTo(x => x.StartTest()).ShouldRedirectTo(x => x.Test(It.IsAny<TestViewModel>()));
        }
    }
}
