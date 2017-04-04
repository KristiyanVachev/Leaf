using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullTestServiceTests
{
    [TestFixture]
    public class GetTestByIdTests
    {
        [TestCase(4)]
        [TestCase(53242)]
        public void GetTestById_ShouldCallTestRepositoryGetById(int id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            var mockUserService = new Mock<IUserService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var service = new FullTestService(mockTestService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object);

            //Act 
            service.GetTestById(id);

            //Assert
            mockTestService.Verify(x => x.GetTestById(id), Times.Once);
        }
    }
}
