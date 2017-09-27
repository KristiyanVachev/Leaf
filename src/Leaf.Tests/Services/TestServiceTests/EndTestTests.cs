using System.Collections.Generic;
using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Services;
using Leaf.Services.Helpers;
using Leaf.Services.Helpers.Contracts;
using Leaf.Services.Utilities.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.TestServiceTests
{
    public class EndTestTests
    {
        [TestCase(4)]
        [TestCase(53242)]
        public void EndTest_ShouldReturnInstanceOfTest_WhenValidId(int id)
        {
            //Arrange
            var mockTestUtility = new Mock<ITestUtility>();
            var mockQuestionUtility = new Mock<IQuestionUtility>();
            var mockUserUtility = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var service = new TestService(mockTestUtility.Object,
                mockQuestionUtility.Object,
                mockUserUtility.Object,
                mockAuthenticationProvider.Object);

            var mockFinishedTest = new Mock<IFinishedTestHelper>();
            mockFinishedTest.SetupGet(x => x.TestId).Returns(id);
            mockFinishedTest.SetupGet(x => x.AnsweredQuestions).Returns(new List<AnsweredQuestionHelper>());

            mockTestUtility.Setup(x => x.GetTestById(id)).Returns(new Test());

            //Act 
            var result = service.EndTest(mockFinishedTest.Object);

            //Assert
            Assert.IsInstanceOf<Test>(result);
        }

        [TestCase(4)]
        [TestCase(53242)]
        public void EndTest_ShouldReturnNull_WhenInvalidId(int id)
        {
            //Arrange
            var mockTestUtility = new Mock<ITestUtility>();
            var mockQuestionUtility = new Mock<IQuestionUtility>();
            var mockUserUtility = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var service = new TestService(mockTestUtility.Object,
                mockQuestionUtility.Object,
                mockUserUtility.Object,
                mockAuthenticationProvider.Object);

            var mockFinishedTest = new Mock<IFinishedTestHelper>();
            mockFinishedTest.SetupGet(x => x.TestId).Returns(id);
            mockFinishedTest.SetupGet(x => x.AnsweredQuestions).Returns(new List<AnsweredQuestionHelper>());

            //Act 
            var result = service.EndTest(mockFinishedTest.Object);

            //Assert
            Assert.IsNull(result);
        }
    }
}
