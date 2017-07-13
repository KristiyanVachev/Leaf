using Leaf.Services.Contracts;
using Leaf.Web.Areas.Moderation.Controllers;
using Leaf.Web.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.ModerationControllerTests
{
    [TestFixture]
    public class QuestionTests
    {
        [TestCase(0)]
        [TestCase(241)]
        public void Question_ShouldCallQuestionService_GetById(int id)
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act
            controller.Question(id);

            //Assert
            mockQuestionService.Verify(x => x.GetById(id), Times.Once);
        }

        [TestCase(0)]
        [TestCase(241)]
        public void Question_ShouldRenderView(int id)
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Question(id)).ShouldRenderDefaultView();
        }
    }
}
