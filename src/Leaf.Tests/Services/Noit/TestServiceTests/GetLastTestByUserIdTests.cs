using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Utilities;
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
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestUtility(mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            //Act
            service.GetLastTest(userId, It.IsAny<TestType>());

            //Assert
            mockTestRepository.Verify(x => x.Entities, Times.Once);
        }
    }
}
