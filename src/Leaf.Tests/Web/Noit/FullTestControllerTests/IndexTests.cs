using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void Index_ShouldCallServiceHasUnfinishedTests()
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.Index();

            //Assert
            mockFullTestService.Verify(x => x.HasUnfinishedTest(), Times.Once);
        }

        [Test]
        public void Index_ShouldRenderView()
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Index()).ShouldRenderView("FullTest");
        }
    }
}
