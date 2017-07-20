using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services;
using Leaf.Services.Contracts;
using Leaf.Services.Utilities.Contracts;
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
            var mockTestService = new Mock<ITestUtility>();
            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockUserService = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var service = new TestService(mockTestService.Object,
                mockQuestionService.Object,
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
            var mockTestService = new Mock<ITestUtility>();
            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockUserService = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(id);

            var service = new TestService(mockTestService.Object,
                mockQuestionService.Object,
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
            var mockTestService = new Mock<ITestUtility>();
            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockUserService = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var mockTest = new Mock<Test>();
            mockTestService.Setup(x => x.GetLastTest(id, It.IsAny<TestType>())).Returns(mockTest.Object);

            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(id);

            var service = new TestService(mockTestService.Object,
                mockQuestionService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object);

            //Act 
            var result = service.ContinueTest(TestType.Test);

            //Assert
            Assert.AreSame(mockTest.Object, result);
        }
    }
}
