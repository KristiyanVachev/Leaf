using Leaf.Auth.Managers;
using Leaf.Commom.Contracts;
using Leaf.Tests.Auth.AuthenticationProviderTests.Mocks;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Auth.AuthenticationProviderTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [Test]
        public void TestSignInManager_ShouldCallHttpContextProviderGetUserManager()
        {
            //Arrange
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            var provider = new MockedAuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            provider.GetSignInManager();

            //Assert
            mockedHttpContextProvider.Verify(p => p.GetUserManager<ApplicationSignInManager>(), Times.Once);
        }

        [Test]
        public void TestUserManager_ShouldCallHttpContextProviderGetUserManager()
        {
            //Arrange
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            var provider = new MockedAuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            provider.GetUserManager();

            //Assert
            mockedHttpContextProvider.Verify(p => p.GetUserManager<ApplicationUserManager>(), Times.Once);
        }
    }
}
