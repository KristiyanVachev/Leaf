using System.Collections.Generic;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
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
        public void GetTestById_ShouldCallTestRepository(string userId)
        {
            //Arrange
            var mockQuestionRepository = new Mock<IRepository<Question>>();
            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();

            var fakeTest = new Test();

            var mockTestRepository = new Mock<IRepository<Test>>();
            mockTestRepository.Setup(x => x.Entities).Returns(new List<Test> { fakeTest });

            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new FullGameService(mockQuestionRepository.Object,
                mockAnswerRepository.Object,
                mockCategoryRepository.Object,
                mockTestRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockUnitOfWork.Object
            );

            //Act 
            service.HasUnfinishedTest(userId);

            //Assert
            mockTestRepository.Verify(x => x.Entities, Times.Once);
        }

        [TestCase("4")]
        [TestCase("ndasfsa")]
        public void GetTestById_ShouldReturnFalse_WhenNoUserTestIsFound(string userId)
        {
            //Arrange
            var mockQuestionRepository = new Mock<IRepository<Question>>();
            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();

            var fakeTest = new Test
            {
                UserId = userId + "something else",
            };

            var mockTestRepository = new Mock<IRepository<Test>>();
            mockTestRepository.Setup(x => x.Entities).Returns(new List<Test> { fakeTest });

            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new FullGameService(mockQuestionRepository.Object,
                mockAnswerRepository.Object,
                mockCategoryRepository.Object,
                mockTestRepository.Object,
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
