using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
using Leaf.Web.Models.Tests;
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
            var mockFullTestService = new Mock<ITestService>();
            mockFullTestService.Setup(x => x.HasUnfinishedTest(TestType.Test)).Returns(true);

            mockFullTestService.Setup(x => x.ContinueTest(TestType.Test)).Returns(new Test { Id = 0 });

            var controller = new TestsController(mockFullTestService.Object);

            //Act && Assert
            controller.WithCallTo(x => x.GetUserTest()).ShouldRedirectTo(x => x.Test(It.IsAny<TestViewModel>()));
        }
    }
}
