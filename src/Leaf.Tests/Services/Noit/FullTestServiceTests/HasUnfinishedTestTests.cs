using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
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

            var service = new FullTestService(mockTestService.Object);

            //Act 
            service.HasUnfinishedTest(userId);

            //Assert
            mockTestService.Verify(x => x.GetLastTestByUserId(userId), Times.Once);
        }

        [TestCase("4")]
        [TestCase("ndasfsa")]
        public void HasUnfinishedTestTests_ShouldReturnTrue_WhenIsNullOrFinishedReturnsFalse(string userId)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            mockTestService.Setup(x => x.IsNullOrFinished(It.IsAny<Test>())).Returns(false);

            var service = new FullTestService(mockTestService.Object);

            //Act 
            var result = service.HasUnfinishedTest(userId);

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

            var service = new FullTestService(mockTestService.Object);

            //Act 
            var result = service.HasUnfinishedTest(userId);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
