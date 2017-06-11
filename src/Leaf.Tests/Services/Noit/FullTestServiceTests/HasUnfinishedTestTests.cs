using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullTestServiceTests
{
    [TestFixture]
    public class HasUnfinishedTestTests
    {
        [TestCase("4")]
        [TestCase("ndasfsa")]
        public void HasUnfinishedTestTests_ShouldCallTestRepository(string userId)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            var mockUserService = new Mock<IUserService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(userId);

            var service = new FullTestService(mockTestService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object);
         
            //Act 
            service.HasUnfinishedTest(TestType.Test);

            //Assert
            mockTestService.Verify(x => x.GetLastTest(userId, It.IsAny<TestType>()), Times.Once);
        }

        [TestCase("4")]
        [TestCase("ndasfsa")]
        public void HasUnfinishedTestTests_ShouldReturnTrue_WhenIsNullOrFinishedReturnsFalse(string userId)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            mockTestService.Setup(x => x.IsNullOrFinished(It.IsAny<Test>())).Returns(false);

            var mockUserService = new Mock<IUserService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var service = new FullTestService(mockTestService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object);           
            
            //Act 
            var result = service.HasUnfinishedTest(TestType.Test);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("4")]
        [TestCase("ndasfsa")]
        public void HasUnfinishedTestTests_ShouldReturnFalse_WhenIsNullOrFinishedReturnsTrue(string userId)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            mockTestService.Setup(x => x.IsNullOrFinished(It.IsAny<Test>())).Returns(true);

            var mockUserService = new Mock<IUserService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var service = new FullTestService(mockTestService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object);

            //Act 
            var result = service.HasUnfinishedTest(TestType.Test);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
