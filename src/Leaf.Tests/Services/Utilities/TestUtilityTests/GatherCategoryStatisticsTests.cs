using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class GatherCategoryStatisticsTests
    {
        [TestCase(21)]
        [TestCase(2)]
        public void GatherCategoryStatistics_ShouldNotThrow_WhenNoAnsweredQuestionsFound(int testId)
        {
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockHelperFactory = new Mock<IHelperFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestUtility(mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockHelperFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            mockAnsweredQuestionRepository
                .Setup(x => x.QueryObjectGraph(It.IsAny<Expression<Func<AnsweredQuestion, bool>>>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<AnsweredQuestion>());

            //Act && Assert
            Assert.DoesNotThrow(() => service.GatherCategoryStatistics(testId));
        }

        [TestCase(24)]
        [TestCase(5353)]
        public void GatherCategoryStatistics_ShouldReturnListWithRightCount(int testId)
        {
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockHelperFactory = new Mock<IHelperFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestUtility(mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockHelperFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            mockAnsweredQuestionRepository
                .Setup(x => x.QueryObjectGraph(It.IsAny<Expression<Func<AnsweredQuestion, bool>>>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<AnsweredQuestion>()
                {
                    new AnsweredQuestion {Question = new Question {CategoryId = 1}, Answer = new Answer() }
                });

            mockHelperFactory.Setup(x =>
                    x.CreateCategoryStatisticHelper(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new CategoryStatisticHelper(0));

            //Act
            var result = service.GatherCategoryStatistics(testId);

            //Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestCase(24)]
        [TestCase(5353)]
        public void GatherCategoryStatistics_ShouldReturnWithCorrectCorrectsCount(int testId)
        {
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockHelperFactory = new Mock<IHelperFactory>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestUtility(mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockHelperFactory.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            mockAnsweredQuestionRepository
                .Setup(x => x.QueryObjectGraph(It.IsAny<Expression<Func<AnsweredQuestion, bool>>>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<AnsweredQuestion>()
                {
                    new AnsweredQuestion {Question = new Question {CategoryId = 1}, Answer = new Answer() {IsCorrect = true} },
                    new AnsweredQuestion {Question = new Question {CategoryId = 1}, Answer = new Answer() {IsCorrect = false} },
                    new AnsweredQuestion {Question = new Question {CategoryId = 1}, Answer = new Answer() {IsCorrect = true} }
                });

            var categoryStatisticHelper = new CategoryStatisticHelper(0);
            mockHelperFactory.Setup(x =>
                    x.CreateCategoryStatisticHelper(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(categoryStatisticHelper);

            //Act
            var result = service.GatherCategoryStatistics(testId);

            //Assert
            Assert.AreEqual(2, categoryStatisticHelper.Correct);
        }
    }
}
