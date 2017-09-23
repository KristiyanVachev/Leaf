using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Services;
using Leaf.Services.Utilities.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.TestServiceTests
{
    [TestFixture]
    public class UserIsOwnerTests
    {
        [TestCase("dsaf32r-dffd23")]
        [TestCase("423rwds3")]
        public void UserIsOwner_ShouldReturnTrue_UserIdEqualsTestsUserId(string userId)
        {
            //Arrange
            var mockTestUtility = new Mock<ITestUtility>();
            var mockQuestionUtility = new Mock<IQuestionUtility>();
            var mockUserUtility = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var fakeTest = new Test { Id = 0, UserId = userId };
            mockTestUtility.Setup(x => x.GetTestById(It.IsAny<int>())).Returns(fakeTest);

            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(userId);

            var service = new TestService(mockTestUtility.Object,
                mockQuestionUtility.Object,
                mockUserUtility.Object,
                mockAuthenticationProvider.Object);

            //Act 
            var result = service.UserIsOwner(It.IsAny<int>());

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("dsaf32r-dffd23", "2wdsf3redsf")]
        [TestCase("423rwds3", "sd24ewd03")]
        public void UserIsOwner_ShouldReturnFalse_WhenUserIdDoesNotEqualTestsUserId(string userId, string testUserId)
        {
            //Arrange
            var mockTestUtility = new Mock<ITestUtility>();
            var mockQuestionUtility = new Mock<IQuestionUtility>();
            var mockUserUtility = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var fakeTest = new Test { Id = 0, UserId = testUserId };
            mockTestUtility.Setup(x => x.GetTestById(It.IsAny<int>())).Returns(fakeTest);

            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(userId);

            var service = new TestService(mockTestUtility.Object,
                mockQuestionUtility.Object,
                mockUserUtility.Object,
                mockAuthenticationProvider.Object);

            //Act 
            var result = service.UserIsOwner(It.IsAny<int>());

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void UserIsOwner_ShouldReturnFalse_WhenTestIsNotFound()
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
            var result = service.UserIsOwner(It.IsAny<int>());

            //Assert
            Assert.IsFalse(result);
        }
    }
}