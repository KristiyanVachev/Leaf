using System;
using System.Collections.Generic;
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
    public class CreateTestTests
    {
        [TestCase("21")]
        [TestCase("dasd2eds")]
        public void CreateTest_ShouldCallQuestionServiceCreateTest_WithCorrectUserId(string userId)
        {
            //Arrange
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
            service.CreateTest(userId);

            //Assert
            mockQuestionService.Verify(x => x.GetQuestions(), Times.Once);
        }

        [TestCase("21")]
        [TestCase("dasd2eds")]
        public void CreateTest_ShouldCallDateTimeProviderGetCurrentTime_WithCorrectUserId(string userId)
        {
            //Arrange
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
            service.CreateTest(userId);

            //Assert
            mockDateTimeProvider.Verify(x => x.GetCurrenTime(), Times.Once);
        }

        [TestCase("21")]
        [TestCase("dasd2eds")]
        public void CreateTest_ShouldCallTestFactoryCreateTest_WithCorrectUserId(string userId)
        {
            //Arrange
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
            service.CreateTest(userId);

            //Assert
            mockTestFactory.Verify(x => x.CreateTest(userId, It.IsAny<IEnumerable<Question>>(), It.IsAny<DateTime>(), It.IsAny<string>()), Times.Once());
        }


        [TestCase("21")]
        [TestCase("dasd2eds")]
        public void CreateTest_ShouldCallTestRepositoryAdd_WithCorrectTest(string userId)
        {
            //Arrange
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
            service.CreateTest(userId);

            //Assert
            mockTestRepository.Verify(x => x.Add(It.IsAny<Test>()), Times.Once());
        }

        [TestCase("21")]
        [TestCase("dasd2eds")]
        public void CreateTest_ShouldCallUnitOfWork(string userId)
        {
            //Arrange
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
            service.CreateTest(userId);

            //Assert
            mockUnitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [TestCase("21")]
        [TestCase("dasd2eds")]
        public void CreateTest_ShouldReturnTestFromTestFactory(string userId)
        {
            //Arrange
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();

            var fakeTest = new Test();

            mockTestFactory.Setup(x => x.CreateTest(It.IsAny<string>(), It.IsAny<IEnumerable<Question>>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(fakeTest);

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
            var result = service.CreateTest(userId);

            //Assert
            Assert.AreSame(fakeTest, result);
        }
    }
}
