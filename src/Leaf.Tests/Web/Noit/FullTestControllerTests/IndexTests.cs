using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
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
            var mockFullTestService = new Mock<ITestsService>();
            var controller = new TestsController(mockFullTestService.Object);

            //Act
            controller.Index();

            //Assert
            mockFullTestService.Verify(x => x.HasUnfinishedTest(TestType.Test), Times.Once);
        }

        [Test]
        public void Index_ShouldRenderView()
        {
            //Arrange
            var mockFullTestService = new Mock<ITestsService>();
            var controller = new TestsController(mockFullTestService.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Index()).ShouldRenderView("FullTest");
        }
    }
}
