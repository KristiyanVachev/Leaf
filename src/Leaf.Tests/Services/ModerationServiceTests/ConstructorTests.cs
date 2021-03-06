﻿using Leaf.Auth.Contracts;
using Leaf.Commom;
using Leaf.Commom.Contracts;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services;
using Leaf.Services.Utilities.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.ModerationServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockSubmissionRepository = new Mock<IRepository<Submission>>();
            var mockQuestionService = new Mock<IQuestionUtility>();
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
