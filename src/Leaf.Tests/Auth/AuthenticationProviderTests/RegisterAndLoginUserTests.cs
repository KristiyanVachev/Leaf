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
    public class RegisterAndLoginUserTests
    {
        [TestCase("password", true, true)]
        public void TestRegisterAndLoginUser_ShouldCallUserManagerCreate(string password, bool isPersistent, bool rememberBrowser)
        {
            //Arrange
            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);
            mockedUserManager.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(new IdentityResult());

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            var user = new User();

            //Act
            provider.RegisterAndLoginUser(user, password, isPersistent, rememberBrowser);

            //Assert
            mockedUserManager.Verify(m => m.CreateAsync(user, password), Times.Once);
        }

        [TestCase("password", true, true)]
        public void TestRegisterAndLoginUser_ShouldReturnCorrectly(string password, bool isPersistent, bool rememberBrowser)
        {
            //Arrange
            var result = new IdentityResult();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);
            mockedUserManager.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(result);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            var user = new User();

            //Act
            var actualResult = provider.RegisterAndLoginUser(user, password, isPersistent, rememberBrowser);

            //Assert
            Assert.AreSame(result, actualResult);
        }
    }
}
