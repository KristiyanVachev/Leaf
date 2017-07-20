using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.SubmitServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockSubmitFactory = new Mock<ISubmitFactory>();
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();
            var mockSubmissionAnswerRepository = new Mock<IRepository<SubmissionAnswer>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            //Act && Assert
            Assert.DoesNotThrow(() =>
                new SubmitService(mockSubmitFactory.Object,
                    mockSubmissionRepository.Object,
                    mockSubmissionAnswerRepository.Object,
                    mockCategoryRepository.Object,
                    mockDateTimeProvider.Object,
                    mockUnitOfWork.Object
                    )
            );
        }
    }
}
