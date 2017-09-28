using Leaf.Commom;
using Leaf.Commom.Contracts;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Helpers;
using Leaf.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Utilities.TestUtilityTests
{
    [TestFixture]
    public class GetTestByIdTests
    {
        [TestCase(21)]
        [TestCase(2)]
        public void GetTestById_ShouldCallTestRepositoryGetById_WithCorrectData(int testId)
        {
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockHelperFactory = new Mock<IHelperFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var utility = new TestUtility(mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockHelperFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            //Act
            utility.GetTestById(testId);

            //Assert
            mockTestRepository.Verify(x => x.GetById(testId), Times.Once);
        }
    }
}
