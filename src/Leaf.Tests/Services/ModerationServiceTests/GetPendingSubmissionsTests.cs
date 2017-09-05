using System.Collections.Generic;
using Leaf.Auth.Contracts;
using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services;
using Leaf.Services.Utilities.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.ModerationServiceTests
{
    [TestFixture]
    public class GetPendingSubmissionsTests
    {
        [Test]
        public void GetPendingSubmissions_ShouldCallSubmissionRepository_GetAll()
        {
            //Arrange
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();
            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var controller = new ModerationService(mockSubmissionRepository.Object,
                mockQuestionService.Object,
                mockDateTimeProvider.Object,
                mockAuthenticationProvider.Object,
                mockUnitOfWork.Object
            );

            //Act
            controller.GetPendingSubmissions();

            //Assert
            mockSubmissionRepository.Verify(x => x.Entities, Times.Once);
        }

        [Test]
        public void GetPendingSubmissions_ShouldReturnInstanceOfIEnumerable()
        {
            //Arrange
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();
            var mockQuestionService = new Mock<IQuestionUtility>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var controller = new ModerationService(mockSubmissionRepository.Object,
                mockQuestionService.Object,
                mockDateTimeProvider.Object,
                mockAuthenticationProvider.Object,
                mockUnitOfWork.Object
            );

            //Act
            var result = controller.GetPendingSubmissions();

            //Assert
            Assert.IsInstanceOf<IEnumerable<Submission>>(result);
        }
    }
}
