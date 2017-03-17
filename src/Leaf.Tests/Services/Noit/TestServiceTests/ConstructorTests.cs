using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.TestServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            //Act && Assert
            Assert.DoesNotThrow(() =>
                new TestService(mockQuestionService.Object,
                    mockTestRepository.Object,
                    mockTestFactory.Object,
                    mockUnitOfWork.Object
                    )
            );
        }
    }
}
