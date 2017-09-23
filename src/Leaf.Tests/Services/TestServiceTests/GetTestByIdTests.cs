using Leaf.Auth.Contracts;
using Leaf.Services;
using Leaf.Services.Utilities.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.TestServiceTests
{
    [TestFixture]
    public class GetTestByIdTests
    {
        [TestCase(4)]
        [TestCase(53242)]
        public void GetTestById_ShouldCallTestUtility_WithCorrectId(int id)
        {
            //Arrange
            var mockTestUtility = new Mock<ITestUtility>();
            var mockQuestionUtility = new Mock<IQuestionUtility>();
            var mockUserUtility = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var service = new TestService(mockTestUtility.Object,
                mockQuestionUtility.Object,
                mockUserUtility.Object,
                mockAuthenticationProvider.Object);

            //Act 
            service.GetTestById(id);

            //Assert
            mockTestUtility.Verify(x => x.GetTestById(id), Times.Once);
        }

        [TestCase(4)]
        [TestCase(53242)]
        public void GetTestById_ShouldReturnNull_WhenTestWithIdDoenstExist(int id)
        {
            //Arrange
            var mockTestUtility = new Mock<ITestUtility>();
            var mockQuestionUtility = new Mock<IQuestionUtility>();
            var mockUserUtility = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var service = new TestService(mockTestUtility.Object,
                mockQuestionUtility.Object,
                mockUserUtility.Object,
                mockAuthenticationProvider.Object);

            //Act 
            var test = service.GetTestById(id);

            //Assert
            Assert.IsNull(test);
        }
    }
}