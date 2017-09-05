using System;
using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.SubmitServiceTests
{
    [TestFixture]
    public class CreateSubmission
    {
        [Test]
        public void CreateSubmission_ShouldCallDateTimeProviderGetCurrentTime()
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

            var fakeIncorrectAnswers = new string[0];

            //Act
            service.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                fakeIncorrectAnswers);

            //Assert
            mockDateTimeProvider.Verify(x => x.GetCurrenTime(), Times.Once);
        }

        [Test]
        public void CreateSubmission_SubmissionFactoryCreate()
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

            var fakeIncorrectAnswers = new string[0];

            //Act
            service.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                fakeIncorrectAnswers);

            //Assert
            mockSubmitFactory.Verify(x => x.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>()),
                Times.Once);
        }

        [Test]
        public void CreateSubmission_ShouldCallSubmitFactoryCreateSubmissionAnswer_WhenIncorrectAnswersIsNotEmpty()
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

            var fakeSubmission = new Submission();

            mockSubmitFactory.Setup(x => x.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>())).Returns(fakeSubmission);

            var fakeIncorrectAnswers = new string[] { "FakeIncorrect" };

            //Act
            service.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                fakeIncorrectAnswers);

            //Assert
            mockSubmitFactory.Verify(x => x.CreateSubmissionAnswer(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CreateSubmission_ShouldCallSubmissionAnswerRepositoryAdd_WhenIncorrectAnswersIsNotEmpty()
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

            var fakeSubmission = new Submission();

            mockSubmitFactory.Setup(x => x.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>())).Returns(fakeSubmission);

            var fakeIncorrectAnswers = new string[] { "FakeIncorrect" };

            //Act
            service.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                fakeIncorrectAnswers);

            //Assert
            mockSubmissionAnswerRepository.Verify(x => x.Add(It.IsAny<SubmissionAnswer>()), Times.Once);
        }

        [Test]
        public void CreateSubmission_ShouldCallSubmissionRepository()
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

            var fakeIncorrectAnswers = new string[0];

            //Act
            service.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                fakeIncorrectAnswers);

            //Assert
            mockSubmissionRepository.Verify(x => x.Add(It.IsAny<Submission>()), Times.Once);
        }

        [Test]
        public void CreateSubmission_ShouldCallUnitOfWork()
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

            var fakeIncorrectAnswers = new string[0];

            //Act
            service.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                fakeIncorrectAnswers);

            //Assert
            mockUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void CreateSubmission_ShouldReturnAnInstaneOfSubmission()
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

            var fakeSubmission = new Submission();

            mockSubmitFactory.Setup(x => x.CreateSubmission(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>())).Returns(fakeSubmission);

            var fakeIncorrectAnswers = new string[0];

            //Act
            var result = service.CreateSubmission(It.IsAny<string>(),
                 It.IsAny<string>(),
                 It.IsAny<string>(),
                 It.IsAny<string>(),
                 fakeIncorrectAnswers);

            //Assert
            Assert.IsInstanceOf<Submission>(result);
        }
    }
}
