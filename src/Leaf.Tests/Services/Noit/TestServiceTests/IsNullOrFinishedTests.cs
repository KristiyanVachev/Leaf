using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services;
using Leaf.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.TestServiceTests
{
    [TestFixture]
    public class IsNullOrFinishedTests
    {
        [Test]
        public void IsNullOrFinished_ShouldReturnTrue_WhenTestIsNull()
        {
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestService(mockQuestionService.Object,
                mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            //Act
            var result = service.IsNullOrFinished(null);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrFinished_ShouldReturnTrue_WhenTestIsUnfinished()
        {
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestService(mockQuestionService.Object,
                mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            var fakeTest = new Test {IsFinished = true};

            //Act
            var result = service.IsNullOrFinished(fakeTest);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrFinished_ShouldReturnFalse_WhenTestIsNotFinished()
        {
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestService(mockQuestionService.Object,
                mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            var fakeTest = new Test { IsFinished = false };

            //Act
            var result = service.IsNullOrFinished(fakeTest);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
