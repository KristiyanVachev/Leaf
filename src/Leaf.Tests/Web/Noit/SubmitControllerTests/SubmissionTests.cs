using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Web.Noit.SubmitControllerTests
{
    [TestFixture]
    public class SubmissionTests
    {
        //TODO add viewModel factory
        public void New_ShouldCallSubmitService_GetCategories(int id)
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            mockSubmitService.Setup(x => x.GetSubmissionById(id)).Returns(It.IsAny<Submission>());

            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new SubmitController(mockSubmitService.Object, mockAuthenticationProvider.Object);

            //Act
            controller.Submission(id);

            //Assert
            mockSubmitService.Verify(x => x.GetSubmissionById(id), Times.Once);
        }
    }
}
