using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
using Leaf.Web.Models;
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
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object, 
                mockViewModelFactory.Object);

            //Act && Assert
            controller.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        }
    }
}
