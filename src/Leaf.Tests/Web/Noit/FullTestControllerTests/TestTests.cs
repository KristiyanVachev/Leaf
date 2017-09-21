using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
using Leaf.Web.Models.Tests;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class TestTests
    {
        [TestCase(8)]
        [TestCase(52432)]
        public void Test_ShouldCallServiceGetTestById_WhenTestIsFinished(int testId)
        {
            //Arrange
            var mockFullTestService = new Mock<ITestService>();
            var fakeTest = new Test { CorrectCount = 0 };
            mockFullTestService.Setup(x => x.GetTestById(It.IsAny<int>())).Returns(fakeTest);
            mockFullTestService.Setup(x => x.UserIsOwner(It.IsAny<int>())).Returns(true);

            var controller = new TestsController(mockFullTestService.Object);
            var fakeTestViewModel = new TestViewModel(testId);

            //Act
            controller.Test(fakeTestViewModel);

            //Assert
            mockFullTestService.Verify(x => x.GetTestById(testId), Times.Once);
        }

        [TestCase(16)]
        [TestCase(2342)]
        public void Test_ShouldReturnView_WhenTestIsFinsihed(int testId)
        {
            //Arrange
            var mockFullTestService = new Mock<ITestService>();
            var fakeTest = new Test { CorrectCount = 0 };
            mockFullTestService.Setup(x => x.GetTestById(It.IsAny<int>())).Returns(fakeTest);
            mockFullTestService.Setup(x => x.UserIsOwner(It.IsAny<int>())).Returns(true);

            var controller = new TestsController(mockFullTestService.Object);
            var fakeTestViewModel = new TestViewModel(testId);

            //Act
            controller.Test(fakeTestViewModel);

            //Assert
            controller.WithCallTo(x => x.Test(fakeTestViewModel)).ShouldRenderView("FinishedTest");
        }
    }
}
