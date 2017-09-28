using Leaf.Auth;
using Leaf.Auth.Managers;
using Leaf.Commom.Contracts;
using Leaf.Models;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Auth.AuthenticationProviderTests
{
    [TestFixture]
    public class IsInRoleTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "koala")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", "kangaroo")]
        public void TestIsInRole_ShouldCallUserManagerIsInRole(string userId, string role)
        {
            //Arrange
            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            provider.IsInRole(userId, role);

            //Assert
            mockedUserManager.Verify(m => m.IsInRoleAsync(userId, role), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "stupidpanda", true)]
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "tandakapanda", false)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", "dolphin", true)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", "whale", false)]
        public void TestIsInRole_ShouldReturnCorrectly(string userId, string role, bool isInRole)
        {
            //Arrange
            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);
            mockedUserManager.Setup(m => m.IsInRoleAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(isInRole);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            var result = provider.IsInRole(userId, role);

            //Assert
            Assert.AreEqual(isInRole, result);
        }

        [TestCase("koala")]
        [TestCase("rabbit")]
        [TestCase("wombat")]
        [TestCase("justABat")]
        public void TestIsInRole_UserIdIsNull_ShouldReturnFalse(string role)
        {
            //Arrange
            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            var result = provider.IsInRole(null, role);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
