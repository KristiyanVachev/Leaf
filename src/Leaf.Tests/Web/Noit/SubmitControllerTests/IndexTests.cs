using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Noit.SubmitControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void Index_ShouldRenderDefaultView()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new SubmitController(mockSubmitService.Object, mockAuthenticationProvider.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        }
    }
}
