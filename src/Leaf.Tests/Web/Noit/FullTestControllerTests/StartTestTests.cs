using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Leaf.Web.Areas.Noit.Models.FullTest;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class StartTestTests
    {
        [Test]
        public void StartTest_ShouldRedirectToTestActionMethod()
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            mockFullTestService.Setup(x => x.HasUnfinishedTest()).Returns(true);

            mockFullTestService.Setup(x => x.ContinueTest()).Returns(new Test { Id = 0 });

            var controller = new FullTestController(mockFullTestService.Object);

            //Act && Assert
            controller.WithCallTo(x => x.GetUserTest()).ShouldRedirectTo(x => x.Test(It.IsAny<TestViewModel>()));
        }
    }
}
