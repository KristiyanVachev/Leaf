using Leaf.Services.Contracts;
using Leaf.Services.Utilities.Contracts;
using Leaf.Web.Areas.Moderation.Controllers;
using Leaf.Web.Models;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Web.Areas.Moderation.Controllers.ModerationControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockModerationService = new Mock<IModerationService>();
            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new ModerationController(mockModerationService.Object,
                mockQuestionService.Object,
                mockViewModelFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
