using System.Security.Principal;
using Leaf.Auth;
using Leaf.Commom.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Auth.AuthenticationProviderTests
{
    [TestFixture]
    public class CurrentUserIdTests
    {
        [Test]
        public void TestCurrentUserId_ShouldCallHttpContextProviderCurrentIdentity()
        {
            //Arrange
            var mockedIdentity = new Mock<IIdentity>();

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentIdentity).Returns(mockedIdentity.Object);

            var provider = new AuthenticationProvider(mockedHttpContextProvider.Object);

            //Act
            var result = provider.CurrentUserId;

            //Assert
            mockedHttpContextProvider.Verify(p => p.CurrentIdentity, Times.Once);
        }
    }
}
