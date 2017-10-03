using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
using Leaf.Web.Models;
using Leaf.Web.Models.Submit;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Controllers.SubmitControllerTests
{
    [TestFixture]
    public class NewHttpPostTests
    {
        [Test]
        public void CreateSubmission_ShouldCallAuthenticationServiceCurrentUserId()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            var fakeNewSubmitViewModel = new NewSubmitViewModel();

            var fakeSubmission = new Submission
            {
                Id = 0
            };

            mockSubmitService.Setup(x => x.CreateSubmission(It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()))
                .Returns(fakeSubmission);
                
            //Act
            controller.New(fakeNewSubmitViewModel);

            //Assert
            mockAuthenticationProvider.Verify(x => x.CurrentUserId, Times.Once);
        }

        [Test]
        public void CreateSubmission_ShouldCallSubmitServiceCreateSubmission()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            var fakeNewSubmitViewModel = new NewSubmitViewModel();

            var fakeSubmission = new Submission
            {
                Id = 0
            };

            mockSubmitService.Setup(x => x.CreateSubmission(It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()))
                .Returns(fakeSubmission);

            //Act
            controller.New(fakeNewSubmitViewModel);

            //Assert
            mockSubmitService.Verify(x => x.CreateSubmission(It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()), Times.Once);
        }

        [Test]
        public void CreateSubmissin_ShouldRedirectToSubmission()
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            var fakeNewSubmitViewModel = new NewSubmitViewModel();

            var fakeSubmission = new Submission
            {
                Id = 0
            };

            mockSubmitService.Setup(x => x.CreateSubmission(It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()))
                .Returns(fakeSubmission);

            //Act
            controller.WithCallTo(x => x.New(fakeNewSubmitViewModel))
                .ShouldRedirectTo(x => x.Submission);
        }
    }
}
