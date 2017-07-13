using Leaf.Services.Contracts;
using Leaf.Web.Areas.Moderation.Controllers;
using Leaf.Web.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.ModerationControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void Index_ShouldRenderDefaultView()
        {
            // Arrange
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        }
    }
}
