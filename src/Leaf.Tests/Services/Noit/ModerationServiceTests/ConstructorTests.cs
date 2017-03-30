using Leaf.Auth.Contracts;
using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.ModerationServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            //Act && Assert
            Assert.DoesNotThrow(() =>
                new ModerationService(mockSubmissionRepository.Object,
                    mockQuestionService.Object,
                    mockDateTimeProvider.Object,
                    mockAuthenticationProvider.Object,
                    mockUnitOfWork.Object
                    )
            );
        }
    }
}
