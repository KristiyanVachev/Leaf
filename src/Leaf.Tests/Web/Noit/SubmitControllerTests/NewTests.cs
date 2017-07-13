using System.Collections.Generic;
using System.Web.Mvc;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
using Leaf.Web.Models;
using Leaf.Web.Models.Submit;
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
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            //Act
            controller.New();

            //Assert
            mockSubmitService.Verify(x => x.GetCategories(), Times.Once);
        }

        [Test]
        public void New_ShouldCallViewModelFactory()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            //Act
            controller.New();

            //Assert
            mockViewModelFactory.Verify(x => x.CreateNewSubmitViewModel(It.IsAny<IEnumerable<SelectListItem>>(), It.IsAny<string[]>()), Times.Once);
        }

        [Test]
        public void New_ShouldRenderView_WithViewModel()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var fakeNewSubmitVieModel = new NewSubmitViewModel();

            mockViewModelFactory.Setup(x => x.CreateNewSubmitViewModel(
                    It.IsAny<IEnumerable<SelectListItem>>(),
                    It.IsAny<string[]>()))
                .Returns(fakeNewSubmitVieModel);

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            //Act && Assert
            controller.WithCallTo(x => x.New()).ShouldRenderDefaultView().WithModel<NewSubmitViewModel>();
        }
    }
}
