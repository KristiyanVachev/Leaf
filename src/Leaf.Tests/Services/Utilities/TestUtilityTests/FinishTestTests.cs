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
    public class FinishTestTests
    {
        [TestCase(232)]
        [TestCase(12)]
        public void FinishTest_ShouldNotThrow_WhenTestIsNotFound(int testId)
        {
            //Arrange
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

            //Act & Assert
            Assert.DoesNotThrow(() => utility.FinishTest(testId));
        }

        [TestCase(232)]
        [TestCase(12)]
        public void FinishTest_ShouldSetUpIsFinished_WhenTestIdIsFound(int testId)
        {
            //Arrange
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

            //TODO testing on real objects... not good.                
            var fakeTest = new Test();
            mockTestRepository.Setup(x => x.GetById(testId)).Returns(fakeTest);

            //Act 
            utility.FinishTest(testId);

            //Assert
            Assert.IsTrue(fakeTest.IsFinished);
        }
    }
}
