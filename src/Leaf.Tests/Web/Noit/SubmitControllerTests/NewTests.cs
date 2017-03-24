using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Leaf.Web.Areas.Noit.Models.Submit;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.SubmitControllerTests
{
    [TestFixture]
    public class NewTests
    {
        [Test]
        public void New_ShouldCallSubmitService_GetCategories()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new SubmitController(mockSubmitService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.New();

            //Assert
            mockSubmitService.Verify(x => x.GetCategories(), Times.Once);
        }

        [Test]
        public void New_ShouldRenderView_WithViewModel()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new SubmitController(mockSubmitService.Object, mockAuthenticationProvider.Object);

            //Act && Assert
            controller.WithCallTo(x => x.New()).ShouldRenderDefaultView().WithModel<NewSubmitViewModel>();
        }
    }
}
