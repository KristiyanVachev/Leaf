using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Utilities.QuestionUtilityTests
{
    public class GetByIdTests
    {
        [TestCase(42)]
        [TestCase(532)]
        public void GetById_ShouldReturnNull_WhenQuestionIsNotFound(int id)
        {
            //Arrange
            var mockQuestionRepository = new Mock<IRepository<Question>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();
            var mockQuestionFactory = new Mock<IQuestionFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var utility = new QuestionUtility(mockQuestionRepository.Object,
                mockCategoryRepository.Object,
                mockQuestionFactory.Object,
                mockUnitOfWork.Object
            );

            //Act
            var question = utility.GetById(id);

            //Assert
            Assert.IsNull(question);
        }

        [TestCase(42)]
        [TestCase(532)]
        public void GetById_ShouldReturnQuestion_WhenFound(int id)
        {
            //Arrange
            var mockQuestionRepository = new Mock<IRepository<Question>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();
            var mockQuestionFactory = new Mock<IQuestionFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var utility = new QuestionUtility(mockQuestionRepository.Object,
                mockCategoryRepository.Object,
                mockQuestionFactory.Object,
                mockUnitOfWork.Object
            );

            mockQuestionRepository.Setup(x => x.GetById(id)).Returns(new Mock<Question>().Object);

            //Act
            var question = utility.GetById(id);

            //Assert
            Assert.IsInstanceOf<Question>(question);
        }
    }
}
