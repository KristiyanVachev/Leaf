using Leaf.Auth.Contracts;
using Leaf.Services;
using Leaf.Services.Utilities.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.TestServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockTestService = new Mock<ITestUtility>();
            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockUserService = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            //Act && Assert
            Assert.DoesNotThrow(() => new TestService(mockTestService.Object,
                mockQuestionService.Object,
                mockUserService.Object,
                mockAuthenticationProvider.Object));
        }

        //TODO add tests for each parameter to be null and values assigned correctly
    }
}
