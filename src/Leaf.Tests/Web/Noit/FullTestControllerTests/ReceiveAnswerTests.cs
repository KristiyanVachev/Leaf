using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Leaf.Web.Areas.Noit.Models.FullTest;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class ReceiveAnswerTests
    {
        [TestCase(4, 2, 3, "das34qwd-dsa2dws")]
        [TestCase(532, 2412, 42, "dsad34d-253s2ewds")]
        public void ReceiveAnswer_ShouldCallServiceSendAnswer(int questionId, int answerId, int testId, string userId)
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            mockFullTestService.Setup(x => x.UserIsOwner(It.IsAny<int>())).Returns(true);

            var controller = new TestsController(mockFullTestService.Object);

            //Act
            controller.ReceiveAnswer(testId, questionId, answerId);

            //Assert
            mockFullTestService.Verify(x => x.SendAnswer(testId, questionId, answerId), Times.Once);
        }

        [TestCase(0, 0, 0)]
        [TestCase(215, 124321, 4214242)]
        public void ReceiveAnswer_ShouldRedirectToTestActionMethod(int testId, int questionId, int answerId)
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            mockFullTestService.Setup(x => x.UserIsOwner(It.IsAny<int>())).Returns(true);

            var controller = new TestsController(mockFullTestService.Object);

            //Act && Assert
            controller.WithCallTo(x => x.ReceiveAnswer(testId, questionId, answerId)).ShouldRedirectTo(x => x.Test(It.IsAny<TestViewModel>()));
        }

    }
}
