using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Leaf.Web.Areas.Noit.Models;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Web.Noit.SubmitControllerTests
{
    [TestFixture]
    public class SubmissionTests
    {
        //[TestCase(2)]
        //[TestCase(2342)]
        public void New_ShouldCallSubmitService_GetCategories(int id)
        {
            // Arrange
            var mockSubmitService = new Mock<ISubmitService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new SubmitController(mockSubmitService.Object,
                mockAuthenticationProvider.Object,
                mockViewModelFactory.Object);

            //Act
            controller.Submission(id);

            //Assert
            mockSubmitService.Verify(x => x.GetSubmissionById(id), Times.Once);
        }
    }
}
