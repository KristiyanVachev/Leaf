using System.Collections.Generic;
using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Web.Controllers;
using Leaf.Web.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Leaf.Tests.Web.Controllers.SubmitControllerTests
{
    [TestFixture]
    public class SubmissionTests
    {
        [TestCase(2)]
        [TestCase(2342)]
        public void Submission_ShouldCallSubmitService_GetCategories(int id)
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            var fakeSubmission = new Submission
            {
                CategoryId = 0,
                Condition = "",
                Answers = new List<SubmissionAnswer>()
            };

            mockSubmitService.Setup(x => x.GetSubmissionById(id)).Returns(fakeSubmission);

            //Act
            controller.Submission(id);

            //Assert
            mockSubmitService.Verify(x => x.GetSubmissionById(id), Times.Once);
        }

        [TestCase(2)]
        [TestCase(2342)]
        public void Submission_ShouldRenderDefaultView(int id)
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            var fakeSubmission = new Submission
            {
                CategoryId = 0,
                Condition = "",
                Answers = new List<SubmissionAnswer>()
            };

            mockSubmitService.Setup(x => x.GetSubmissionById(id)).Returns(fakeSubmission);


            //Act && Assert
            controller.WithCallTo(x => x.Submission(id)).ShouldRenderDefaultView();
        }
    }
}
