﻿using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullGameServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockQuestionRepository = new Mock<IRepository<Question>>();
            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            //Act && Assert
            Assert.DoesNotThrow(() =>
                new FullGameService(mockQuestionRepository.Object,
                    mockAnswerRepository.Object,
                    mockCategoryRepository.Object,
                    mockTestRepository.Object,
                    mockAnsweredQuestionRepository.Object,
                    mockTestFactory.Object,
                    mockUnitOfWork.Object
                    )
            );
        }

        //TODO add tests for each parameter to be null and values assigned correctly
    }
}