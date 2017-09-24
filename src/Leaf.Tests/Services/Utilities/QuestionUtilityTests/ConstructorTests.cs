using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Utilities.QuestionUtilityTests
{
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockQuestionRepository = new Mock<IRepository<Question>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();
            var mockQuestionFactory = new Mock<IQuestionFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            //Act && Assert
            Assert.DoesNotThrow(() =>
                new QuestionUtility(mockQuestionRepository.Object,
                    mockCategoryRepository.Object,
                    mockQuestionFactory.Object,
                    mockUnitOfWork.Object
                )
            );
        }
    }
}
