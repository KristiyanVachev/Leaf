using Leaf.Commom;
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
    public class GetLastTestByUserIdTests
    {
        [TestCase("2e2qewdas")]
        [TestCase("2")]
        public void GetLastTestByUserId_ShouldCallTestRepositoryEntities(string userId)
        {
            //Arrange
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestService(mockQuestionService.Object,
                mockTestRepository.Object,
                mockTestFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            //Act
            service.GetLastTestByUserId(userId);

            //Assert
            mockTestRepository.Verify(x => x.Entities, Times.Once);
        }
    }
}
