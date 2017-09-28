using System.Security.Principal;
using Leaf.Auth;
using Leaf.Commom.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Auth.AuthenticationProviderTests
{
    [TestFixture]
    public class IsAuthenticatedTests
    {
        [Test]
        public void TestIsAuthenticated_ShouldCallHttpContextProviderCurrentIdentity()
        {
            //Arrange
            var mockedIdentity = new Mock<IIdentity>();

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentIdentity).Returns(mockedIdentity.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            var result = provider.IsAuthenticated;

            //Assert
            mockedHttpContextProvider.Verify(p => p.CurrentIdentity, Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestIsAuthenticated_ShouldReturnCorrectly(bool isAuthenticated)
        {
            //Arrange
            var mockedIdentity = new Mock<IIdentity>();
            mockedIdentity.Setup(i => i.IsAuthenticated).Returns(isAuthenticated);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentIdentity).Returns(mockedIdentity.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            var result = provider.IsAuthenticated;

            //Assert
            Assert.AreEqual(isAuthenticated, result);
        }
    }
}
