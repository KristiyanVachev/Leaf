//using Leaf.Auth.Contracts;
//using Leaf.Models;
//using Leaf.Models.Enums;
//using Leaf.Services;
//using Leaf.Services.Contracts;
//using Moq;
//using NUnit.Framework;

//namespace Leaf.Tests.Services.Noit.FullTestServiceTests
//{
//    [TestFixture]
//    public class CreateTestTests
//    {
//        [Test]
//        public void CreateTest_ShouldCallGetUserId()
//        {
//            //Arrange
//            var mockTestService = new Mock<ITestService>();
//            mockTestService.Setup(x => x.IsNullOrFinished(It.IsAny<Test>())).Returns(true);

//            var mockUserService = new Mock<IUserService>();
//            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

//            var service = new TestsService(mockTestService.Object,
//                mockUserService.Object,
//                mockAuthenticationProvider.Object);
//            //Act 
//            service.CreateTest(TestType.Test);

//            //Assert
//            mockAuthenticationProvider.Verify(x => x.CurrentUserId, Times.Once);
//        }

//        [TestCase("3")]
//        [TestCase("dsdws")]
//        public void CreateTest_ShouldCallCreateTest_WithCorrectId(string id)
//        {
//            //Arrange
//            var mockTestService = new Mock<ITestService>();
//            var mockUserService = new Mock<IUserService>();
//            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

//            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(id);

//            var service = new TestsService(mockTestService.Object,
//                mockUserService.Object,
//                mockAuthenticationProvider.Object);

//            //Act 
//            service.CreateTest(TestType.Test);

//            //Assert
//            mockTestService.Verify(x => x.CreateTest(id), Times.Once);   
//        }

//        [TestCase("4")]
//        [TestCase("fasfs")]
//        public void CreateTest_ShouldReturnCreatedTest(string id)
//        {
//            //Arrange
//            var mockTestService = new Mock<ITestService>();
//            var mockTest = new Mock<Test>();
//            mockTestService.Setup(x => x.CreateTest(id)).Returns(mockTest.Object);

//            var mockUserService = new Mock<IUserService>();
//            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
//            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(id);

//            var service = new TestsService(mockTestService.Object,
//                mockUserService.Object,
//                mockAuthenticationProvider.Object);

//            //Act 
//            var result = service.CreateTest(TestType.Test);

//            //Assert
//            Assert.AreSame(mockTest.Object, result);
//        }
//    }
//}
