using System;
using System.Collections.Generic;
using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Utilities.TestUtilityTests
{
    [TestFixture]
    public class CreateTestTests
    {
        private Mock<IRepository<Test>> mockTestRepository;
        private Mock<IRepository<AnsweredQuestion>> mockAnsweredQuestionRepository;
        private Mock<ITestFactory> mockTestFactory;
        private Mock<IDateTimeProvider> mockDateTimeProvider;
        private Mock<IUnitOfWork> mockUnitOfWork;

        private TestUtility service;

        [SetUp]
        public void Init()
        {
            mockTestRepository = new Mock<IRepository<Test>>();
            mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            mockTestFactory = new Mock<ITestFactory>();
            mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockUnitOfWork = new Mock<IUnitOfWork>();

            service = new TestUtility(mockTestRepository.Object,
               mockAnsweredQuestionRepository.Object,
               mockTestFactory.Object,
               mockDateTimeProvider.Object,
               mockUnitOfWork.Object
           );

        }

        [TestCase("21", TestType.Test)]
        [TestCase("dasd2eds", TestType.Practice)]
        public void CreateTest_ShouldCallTestFactory_WithTheRightArgumets(string userId, TestType type)
        {
            //Arrange
            var fakeTime = new DateTime();
            mockDateTimeProvider.Setup(x => x.GetCurrenTime()).Returns(fakeTime);

            //Act
            var result = service.CreateTest(userId, type, It.IsAny<IEnumerable<Question>>());

            //Assert
            mockTestFactory.Verify(
                x => x.CreateTest(userId, It.IsAny<IEnumerable<Question>>(), fakeTime, type), Times.Once);
        }

        [TestCase("21", TestType.Test)]
        [TestCase("dasd2eds", TestType.Practice)]
        public void CreateTest_ShouldReturnInstanceOfTest(string userId, TestType type)
        {
            //Arrange
            mockTestFactory
                .Setup(x => x.CreateTest(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<Question>>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<TestType>()))
                .Returns(new Test());

            //Act
            var result = service.CreateTest(userId, type, It.IsAny<IEnumerable<Question>>());

            //Assert
            Assert.IsInstanceOf<Test>(result);
        }
    }
}
