using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class TestTests
    {
        [TestCase(2)]
        [TestCase(422)]
        public void Test_ShouldCallServiceGetNextQuestion_WithCorrectTestId(int testId)
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.Test(testId);

            //Assert
            mockFullTestService.Verify(x => x.GetNextQuestion(testId), Times.Once);
        }

        [TestCase(4)]
        [TestCase(532)]
        public void Test_ShouldReturnView_WhenGetNextQuestionRetursAQuestion(int testId)
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            mockFullTestService.Setup(x => x.GetNextQuestion(testId)).Returns(new Question());

            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.Test(testId);

            //Assert
            controller.WithCallTo(x => x.Test(testId)).ShouldRenderView("Test");
        }

        [TestCase(8)]
        [TestCase(52432)]
        public void Test_ShouldCallServiceGetTestById_WhenTestIsFinished(int testId)
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.Test(testId);

            //Assert
            mockFullTestService.Verify(x => x.GetTestById(testId), Times.Once);
        }

        [TestCase(16)]
        [TestCase(2342)]
        public void Test_ShouldReturnView_WhenTestIsFinsihed(int testId)
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.Test(testId);

            //Assert
            controller.WithCallTo(x => x.Test(testId)).ShouldRenderView("FinishedTest");
        }
    }
}
