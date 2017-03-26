using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullTestServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();

            //Act && Assert
            Assert.DoesNotThrow(() => new FullTestService(mockTestService.Object));
        }

        //TODO add tests for each parameter to be null and values assigned correctly
    }
}
