using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Controllers;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Web.Noit.FullTestControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        
        public void Index_ShouldCallAutnenticationProviderCurrentUserId()
        {
            //Arrange
            var mockFullTestService = new Mock<IFullGameService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(It.IsAny<string>);

            //Act
             new FullTestController(mockFullTestService.Object, mockAuthenticationProvider.Object);

            //Assert
            mockAuthenticationProvider.Verify(x => x.CurrentUserId, Times.Once);
        }
    }
}
