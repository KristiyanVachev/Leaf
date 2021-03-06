﻿using System.Collections.Generic;
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
    public class AddAnswerTests
    {
        [TestCase(232)]
        [TestCase(12)]
        public void AddAnswer_ShouldNotThrow_WhenTestIsNotFound(int testId)
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
            Assert.DoesNotThrow(() => utility.AddAnswers(testId, It.IsAny<ICollection<AnsweredQuestionHelper>>()));
        }

        [Test]
        public void AddAnswer_ShouldAddAmountOfAnsweredQuestionsToRepository()
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

            var fakeTest = new Mock<Test>();
            fakeTest.Setup(x => x.AnsweredQuestions).Returns(new List<AnsweredQuestion>());

            mockTestRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(fakeTest.Object);

            var fakeAnsweredQuestions = new List<AnsweredQuestionHelper>
            {
                new AnsweredQuestionHelper(1, 2),
                new AnsweredQuestionHelper(3, 4),
                new AnsweredQuestionHelper(5, 6)
            };

            //Act
            utility.AddAnswers(It.IsAny<int>(), fakeAnsweredQuestions);

            //Assert
            mockAnsweredQuestionRepository.Verify(x => x.Add(It.IsAny<AnsweredQuestion>()), Times.Exactly(3));
        }
    }
}
