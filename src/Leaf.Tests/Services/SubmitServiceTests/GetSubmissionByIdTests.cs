using Leaf.Commom.Contracts;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.SubmitServiceTests
{
    [TestFixture]
    public class GetSubmissionByIdTests
    {
        [TestCase(0)]
        [TestCase(24332)]
        public void GetSubmissionById_ShouldCallSubmissionRepositoryGetById(int id)
        {
            //Arrange
            var mockSubmitFactory = new Mock<ISubmitFactory>();
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();


            var service = new SubmitService(mockSubmitFactory.Object,
                mockSubmissionRepository.Object,
                mockCategoryRepository.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );

            //Act
            service.GetSubmissionById(id);

            //Assert
            mockSubmissionRepository.Verify(x => x.GetById(id), Times.Once);
        }
    }
}
