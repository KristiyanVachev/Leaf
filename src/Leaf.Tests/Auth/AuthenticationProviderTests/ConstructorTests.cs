using Leaf.Auth;
using Leaf.Commom.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Auth.AuthenticationProviderTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            //Arrange
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            //Act
            var provider = new AuthenticationProvider( mockedHttpContextProvider.Object);

            //Assert
            Assert.IsNotNull(provider);
        }
    }
}
