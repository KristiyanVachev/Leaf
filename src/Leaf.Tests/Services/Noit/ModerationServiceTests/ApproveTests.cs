using Leaf.Auth.Contracts;
using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services;
using Leaf.Services.Contracts;
using Leaf.Services.Utilities.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.ModerationServiceTests
{
    [TestFixture]
    public class ApproveTests
    {
        [TestCase(2)]
        [TestCase(432)]
        public void Aprove_ShouldCallSubmissionRepository_GetAll(int id)
        {
            //Arrange
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();

            var fakeSubmission = new Submission();
            mockSubmissionRepository.Setup(x => x.GetById(id)).Returns(fakeSubmission);

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
            controller.Approve(id);

            //Assert
            mockSubmissionRepository.Verify(x => x.GetById(id), Times.Once);
        }

        [TestCase(2)]
        [TestCase(432)]
        public void Aprove_ShouldCallQuestionService_CreateQuestion(int id)
        {
            //Arrange
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();

            var fakeSubmission = new Submission();
            mockSubmissionRepository.Setup(x => x.GetById(id)).Returns(fakeSubmission);

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
            controller.Approve(id);

            //Assert
            mockQuestionService.Verify(x => x.CreateQuestion(fakeSubmission), Times.Once);
        }

        [TestCase(2)]
        [TestCase(432)]
        public void Aprove_ShouldCallSubmissionRepository_Update(int id)
        {
            //Arrange
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();

            var fakeSubmission = new Submission();
            mockSubmissionRepository.Setup(x => x.GetById(id)).Returns(fakeSubmission);

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
            controller.Approve(id);

            //Assert
            mockSubmissionRepository.Verify(x => x.Update(fakeSubmission), Times.Once);
        }

        [TestCase(2)]
        [TestCase(432)]
        public void Aprove_ShouldCallUnitOfWork_Commit(int id)
        {
            //Arrange
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();

            var fakeSubmission = new Submission();
            mockSubmissionRepository.Setup(x => x.GetById(id)).Returns(fakeSubmission);

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
            controller.Approve(id);

            //Assert
            mockUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
