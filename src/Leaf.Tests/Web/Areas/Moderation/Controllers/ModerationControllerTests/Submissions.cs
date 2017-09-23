using Leaf.Services.Contracts;
using Leaf.Services.Utilities.Contracts;
using Leaf.Web.Areas.Moderation.Controllers;
using Leaf.Web.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Areas.Moderation.Controllers.ModerationControllerTests
{
    [TestFixture]
    public class Submissions
    {
        [Test]
        public void Submissions_ShouldCallModerationService_GetPendingSubmissions()
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionUtility>();
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
            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Submissions(count, page)).ShouldRenderDefaultView();
        }
    }
}
