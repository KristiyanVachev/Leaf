using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullTestServiceTests
{
    [TestFixture]
    public class GetNextQuestionTests
    {
        [TestCase(2)]
        [TestCase(4567)]
        public void GetNextQuestion_ShouldCallTestRepositoryGetById(int id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();

            var fakaTest = new Test
            {
                Questions = { new Question() }
            };

            mockTestService.Setup(x => x.GetTestById(id)).Returns(fakaTest);

            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new FullTestService(mockTestService.Object,
                mockAnswerRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockUnitOfWork.Object
            );

            //Act 
            service.GetNextQuestion(id);

            //Assert
            mockTestService.Verify(x => x.GetTestById(id), Times.Once);
        }

        [TestCase(2)]
        [TestCase(4567)]
        public void GetNextQuestion_ShouldReturnTestsFirstQuestion(int id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();

            var fakeQuestion = new Question();
            var fakaTest = new Test
            {
                Questions = { fakeQuestion }
            };

            mockTestService.Setup(x => x.GetTestById(id)).Returns(fakaTest);

            var mockAnswerRepository = new Mock<IRepository<Answer>>();
            var mockAnsweredQuestionRepository = new Mock<IRepository<AnsweredQuestion>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new FullTestService(mockTestService.Object,
                mockAnswerRepository.Object,
                mockAnsweredQuestionRepository.Object,
                mockTestFactory.Object,
                mockUnitOfWork.Object
            );

            //Act 
            var result = service.GetNextQuestion(id);

            //Assert
            Assert.AreSame(fakeQuestion, result);
        }
    }
}
