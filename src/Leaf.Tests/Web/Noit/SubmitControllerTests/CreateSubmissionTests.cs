using Leaf.Auth.Contracts;
using Leaf.Models;
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
    public class CreateSubmissionTests
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
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()))
                .Returns(fakeSubmission);
                
            //Act
            controller.CreateSubmission(fakeNewSubmitViewModel);

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
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()))
                .Returns(fakeSubmission);

            //Act
            controller.CreateSubmission(fakeNewSubmitViewModel);

            //Assert
            mockSubmitService.Verify(x => x.CreateSubmission(It.IsAny<string>(),
                    It.IsAny<string>(),
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
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()))
                .Returns(fakeSubmission);

            //Act
            controller.WithCallTo(x => x.CreateSubmission(fakeNewSubmitViewModel))
                .ShouldRedirectTo(x => x.Submission);
        }
    }
}
