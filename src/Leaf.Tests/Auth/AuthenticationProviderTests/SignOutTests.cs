using Leaf.Auth;
using Leaf.Commom.Contracts;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Auth.AuthenticationProviderTests
{
    [TestFixture]
    public class SignOutTests
    {
        [Test]
        public void TestSignOut_ShouldCallHttpContextProviderCurrentOwinContext()
        {
            //Arrange
            var mockedAuthManager = new Mock<IAuthenticationManager>();

            var mockedOwinContext = new Mock<IOwinContext>();
            mockedOwinContext.Setup(c => c.Authentication).Returns(mockedAuthManager.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentOwinContext).Returns(mockedOwinContext.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            provider.SignOut();

            //Assert
            mockedHttpContextProvider.Verify(p => p.CurrentOwinContext, Times.Once);
        }

        [Test]
        public void TestSignOut_ShouldCallAuthenticationManagerSignOut()
        {
            //Arrange
            var mockedAuthManager = new Mock<IAuthenticationManager>();

            var mockedOwinContext = new Mock<IOwinContext>();
            mockedOwinContext.Setup(c => c.Authentication).Returns(mockedAuthManager.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentOwinContext).Returns(mockedOwinContext.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            provider.SignOut();

            //Assert
            mockedAuthManager.Verify(m => m.SignOut(It.IsAny<string>()), Times.Once);
        }
    }
}
