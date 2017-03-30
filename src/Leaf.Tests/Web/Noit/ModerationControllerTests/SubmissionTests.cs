using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Leaf.Web.Areas.Noit.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.ModerationControllerTests
{
    [TestFixture]
    public class SubmissionTests
    {
        [TestCase(0)]
        [TestCase(241)]
        public void Submission_ShouldCallModerationService_GetSubmissionById(int id)
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act
            controller.Submission(id);

            //Assert
            mockModerationService.Verify(x => x.GetSubmissionById(id), Times.Once);
        }

        [TestCase(0)]
        [TestCase(241)]
        public void Submission_ShouldRenderView(int id)
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Submission(id)).ShouldRenderDefaultView();
        }
    }
}
