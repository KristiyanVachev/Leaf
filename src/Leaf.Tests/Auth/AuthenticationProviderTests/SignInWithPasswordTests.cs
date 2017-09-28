using Leaf.Auth;
using Leaf.Auth.Managers;
using Leaf.Commom.Contracts;
using Leaf.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Auth.AuthenticationProviderTests
{
    [TestFixture]
    public class SignInWithPasswordTests
    {
        [TestCase("koala@eucalyptus.au", "iloveeucalyptus", true, false)]
        public void TestSignInWithPassword_ShouldCallSignInManagerPasswordSignIn(string email, string password,
            bool remember, bool shouldLockout)
        {
            //Arrange
            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationSignInManager>()).Returns(mockedSignInManager.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            provider.SignInWithPassword(email, password, remember, shouldLockout);

            //Assert
            mockedSignInManager.Verify(m => m.PasswordSignInAsync(email, password, remember, shouldLockout));
        }

        [TestCase("koala@eucalyptus.au", "iloveeucalyptus", true, false, SignInStatus.Success)]
        [TestCase("kangaoo@australia.com", "pouchyy", true, false, SignInStatus.Failure)]
        [TestCase("eagle@sky.com", "yummymouse", true, false, SignInStatus.RequiresVerification)]
        [TestCase("ant@auntyant.com", "aaaaaaaaaaaaaaaaa!!!!anteater", true, false, SignInStatus.LockedOut)]
        public void TestSignInWithPassword_ShouldReturnCorrectly(string email, string password,
            bool remember, bool shouldLockout, SignInStatus signInStatus)
        {
            //Arrange
            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);
            mockedSignInManager.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                It.IsAny<bool>())).ReturnsAsync(signInStatus);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationSignInManager>()).Returns(mockedSignInManager.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            var result = provider.SignInWithPassword(email, password, remember, shouldLockout);

            //Assert
            Assert.AreEqual(signInStatus, result);
        }
    }
}
