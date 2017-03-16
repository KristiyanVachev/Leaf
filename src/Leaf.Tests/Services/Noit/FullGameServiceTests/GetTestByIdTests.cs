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
    public class GetTestByIdTests
    {
        [TestCase(4)]
        [TestCase(53242)]
        public void GetTestById_ShouldCallTestRepositoryGetById(int id)
        {
            //Arrange
            var mockQuestionRepository = new Mock<IRepository<Question>>();
            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();

            var mockTest = new Mock<Test>();
            mockTest.Setup(x => x.Questions).Returns(new List<Question>());
            
            var mockTestRepository = new Mock<IRepository<Test>>();
            mockTestRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockTest.Object);

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
            service.GetTestById(id);

            //Assert
            mockTestRepository.Verify(x => x.GetById(id), Times.Once);
        }
    }
}
