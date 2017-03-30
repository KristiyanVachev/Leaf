using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Leaf.Web.Areas.Noit.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.ModerationControllerTests
{
    [TestFixture]
    public class Submissions
    {
        [Test]
        public void Submissions_ShouldCallModerationService_GetPendingSubmissions()
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act
            controller.Submissions();

            //Assert
            mockModerationService.Verify(x => x.GetPendingSubmissions(), Times.Once);
        }

        [TestCase(2, 1)]
        [TestCase(241, 23)]
        public void Submissions_ShouldRenderView(int count, int page)
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Submissions(count, page)).ShouldRenderDefaultView();
        }
    }
}
