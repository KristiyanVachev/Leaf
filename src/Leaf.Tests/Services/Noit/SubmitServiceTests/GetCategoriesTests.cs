using System.Web.Mvc;
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
    public class GetCategoriesTests
    {
        [Test]
        public void GetCategories_ShouldCallCategoryRepositoryGetALl()
        {
            //Arrange
            var mockSubmitFactory = new Mock<ISubmitFactory>();
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();
            var mockSubmissionAnswerRepository = new Mock<IRepository<SubmissionAnswer>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();


            var service = new SubmitService(mockSubmitFactory.Object,
                mockSubmissionRepository.Object,
                mockSubmissionAnswerRepository.Object,
                mockCategoryRepository.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );


            //Act
            service.GetCategories();

            //Assert
            mockCategoryRepository.Verify(x => x.Entities, Times.Once);
        }

        [Test]
        public void GetCategories_ShouldReturnInstanceOfSelectList()
        {
            //Arrange
            var mockSubmitFactory = new Mock<ISubmitFactory>();
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();
            var mockSubmissionAnswerRepository = new Mock<IRepository<SubmissionAnswer>>();
            var mockCategoryRepository = new Mock<IRepository<Category>>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();


            var service = new SubmitService(mockSubmitFactory.Object,
                mockSubmissionRepository.Object,
                mockSubmissionAnswerRepository.Object,
                mockCategoryRepository.Object,
                mockDateTimeProvider.Object,
                mockUnitOfWork.Object
            );


            //Act
            var categories = service.GetCategories();

            //Assert
            Assert.IsInstanceOf<SelectList>(categories);
        }
    }
}
