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
    public class IsNullOrFinishedTests
    {
        [Test]
        public void IsNullOrFinished_ShouldReturnTrue_WhenTestIsNull()
        {
            //Arrange
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestService(mockQuestionService.Object,
                mockTestRepository.Object,
                mockTestFactory.Object,
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
            //Arrange
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestService(mockQuestionService.Object,
                mockTestRepository.Object,
                mockTestFactory.Object,
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
            //Arrange
            var mockQuestionService = new Mock<IQuestionService>();
            var mockTestRepository = new Mock<IRepository<Test>>();
            var mockTestFactory = new Mock<ITestFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var service = new TestService(mockQuestionService.Object,
                mockTestRepository.Object,
                mockTestFactory.Object,
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
