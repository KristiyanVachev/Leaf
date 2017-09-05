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
    public class GetSubmissionByIdTests
    {
        [TestCase(0)]
        [TestCase(2143)]
        public void GetSubmissionById_ShouldCallSubmissionRepository_GetById(int id)
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
            controller.GetSubmissionById(id);

            //Assert
            mockSubmissionRepository.Verify(x => x.GetById(id), Times.Once);
        }
    }
}
