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
    public class ContinueTestTests
    {
        [Test]
        public void ContinueTest_ShouldCallGetUserId()
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
            service.ContinueTest(TestType.Test);

            //Assert
            mockAuthenticationProvider.Verify(x => x.CurrentUserId, Times.Once);
        }

        [TestCase("3")]
        [TestCase("dsdws")]
        public void ContinueTest_ShouldCallGetLastTestByUserId_WithCorrectId(string id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            var mockUserService = new Mock<IUserService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(id);

            var service = new FullTestService(mockTestService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object);

            //Act 
            service.ContinueTest(TestType.Test);

            //Assert
            mockTestService.Verify(x => x.GetLastTest(id, It.IsAny<TestType>()), Times.Once);
        }

        [TestCase("4")]
        [TestCase("fasfs")]
        public void ContinueTest_ShouldReturnLastTest(string id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            var mockTest = new Mock<Test>();
            mockTestService.Setup(x => x.GetLastTest(id, It.IsAny<TestType>())).Returns(mockTest.Object);

            var mockUserService = new Mock<IUserService>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(id);

            var service = new FullTestService(mockTestService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object);

            //Act 
            var result = service.ContinueTest(TestType.Test);

            //Assert
            Assert.AreSame(mockTest.Object, result);
        }
    }
}
