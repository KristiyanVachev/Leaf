using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullGameServiceTests
{
    [TestFixture]
    public class HasUnfinishedTestTests
    {
        [TestCase("4")]
        [TestCase("ndasfsa")]
        public void HasUnfinishedTestTests_ShouldCallTestRepository(string userId)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new FullGameService(mockTestService.Object,
                mockAnswerRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockUnitOfWork.Object
            );

            //Act 
            service.HasUnfinishedTest(userId);

            //Assert
            mockTestService.Verify(x => x.GetLastTestByUserId(userId), Times.Once);
        }

        [TestCase("4")]
        [TestCase("ndasfsa")]
        public void HasUnfinishedTestTests_ShouldReturnTrue_WhenIsNullOrFinishedIsFalse(string userId)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            mockTestService.Setup(x => x.IsNullOrFinished(It.IsAny<Test>())).Returns(true);

            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new FullGameService(mockTestService.Object,
                mockAnswerRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockUnitOfWork.Object
            );

            //Act 
            var result = service.HasUnfinishedTest(userId);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("4")]
        [TestCase("ndasfsa")]
        public void HasUnfinishedTestTests_ShouldReturnFalse_WhenIsNullOrFinishedIsTrue(string userId)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            mockTestService.Setup(x => x.IsNullOrFinished(It.IsAny<Test>())).Returns(true);

            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new FullGameService(mockTestService.Object,
                mockAnswerRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockUnitOfWork.Object
            );

            //Act 
            var result = service.HasUnfinishedTest(userId);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
