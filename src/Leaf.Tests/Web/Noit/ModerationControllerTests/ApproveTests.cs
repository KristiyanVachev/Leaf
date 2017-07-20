using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Utilities.Contracts;
using Leaf.Web.Areas.Moderation.Controllers;
using Leaf.Web.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.ModerationControllerTests
{
    [TestFixture]
    public class ApproveTests
    {
        [TestCase(0)]
        [TestCase(241)]
        public void Approve_ShouldCallModerationService_Approve(int id)
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            mockModerationService.Setup(x => x.Approve(id)).Returns(new Question {Id = 0});

            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act
            controller.Approve(id);

            //Assert
            mockModerationService.Verify(x => x.Approve(id), Times.Once);
        }

        [TestCase(0)]
        [TestCase(241)]
        public void Approve_ShouldRenderView(int id)
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            mockModerationService.Setup(x => x.Approve(id)).Returns(new Question { Id = 0 });

            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Approve(id)).ShouldRedirectTo(x => x.Question);
        }
    }
}
