using System.Collections.Generic;
using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services;
using Leaf.Services.Utilities.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.TestServiceTests
{
    [TestFixture]
    public class CreateTestTests
    {
        //TODO finish implementation of method and then write the other tests
        [TestCase(TestType.Test)]
        //[TestCase(TestType.Practice)]
        public void CreateTest_ShouldReturnTest(TestType type)
        {
            //Arrange
            var mockTestUtility = new Mock<ITestUtility>();
            var mockTest = new Mock<Test>();
            
            mockTestUtility.Setup(x => x.GetLastUnfinishedTest(It.IsAny<string>(), type));

            mockTestUtility.Setup(x => x.CreateTest(It.IsAny<string>(), type, It.IsAny<IEnumerable<Question>>()))
                .Returns(mockTest.Object);

            var mockQuestionUtility = new Mock<IQuestionUtility>();
            var mockUserUtility = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
            
            var service = new TestService(mockTestUtility.Object,
                mockQuestionUtility.Object,
                mockUserUtility.Object,
                mockAuthenticationProvider.Object);

            //Act 
            var result = service.NewTest(TestType.Test);

            //Assert
            Assert.AreSame(mockTest.Object, result);
        }

        [TestCase(TestType.Test)]
        public void CreateTest_ShouldReturnExistingTest_WhenTestOfTypeExists(TestType type)
        {
            //Arrange
            var mockTestUtility = new Mock<ITestUtility>();
            var mockTest = new Mock<Test>();

            mockTestUtility.Setup(x => x.GetLastUnfinishedTest(It.IsAny<string>(), type));

            mockTestUtility.Setup(x => x.CreateTest(It.IsAny<string>(), type, It.IsAny<IEnumerable<Question>>()))
                .Returns(mockTest.Object);

            var mockQuestionUtility = new Mock<IQuestionUtility>();
            var mockUserUtility = new Mock<IUserUtility>();
            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var fakeExistingTest = new Test {Type = type};
            mockTestUtility.Setup(x => x.GetLastUnfinishedTest(It.IsAny<string>(), type)).Returns(fakeExistingTest);

            var service = new TestService(mockTestUtility.Object,
                mockQuestionUtility.Object,
                mockUserUtility.Object,
                mockAuthenticationProvider.Object);

            //Act 
            var result = service.NewTest(TestType.Test);

            //Assert
            Assert.AreSame(fakeExistingTest, result);
        }
    }
}
