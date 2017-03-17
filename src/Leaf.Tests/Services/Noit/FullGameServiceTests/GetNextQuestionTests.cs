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
    public class GetNextQuestionTests
    {
        [TestCase(2)]
        [TestCase(4567)]
        public void GetNextQuestion_ShouldCallTestRepositoryGetById(int id)
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
            service.GetNextQuestion(id);

            //Assert
            mockTestService.Verify(x => x.GetTestById(id), Times.Once);
        }

        //TODO: Add test verifying that the first question is returned
    }
}
