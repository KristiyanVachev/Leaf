using Leaf.Auth.Contracts;
using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.ModerationServiceTests
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
            var mockQuestionService = new Mock<IQuestionService>();
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
