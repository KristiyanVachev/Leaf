//using Leaf.Auth.Contracts;
//using Leaf.Models;
//using Leaf.Services;
//using Leaf.Services.Contracts;
//using Moq;
//using NUnit.Framework;

//namespace Leaf.Tests.Services.Noit.FullTestServiceTests
//{
//    [TestFixture]
//    public class UserIsOwnerTests
//    {
//        [Test]
//        public void UserIsOwner_ShouldCallGetUserId()
//        {
//            //Arrange
//            var mockTestService = new Mock<ITestService>();

//            var fakeTest = new Test { Id = 0 };
//            mockTestService.Setup(x => x.GetTestById(It.IsAny<int>())).Returns(fakeTest);

//            var mockUserService = new Mock<IUserService>();
//            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

//            var service = new TestsService(mockTestService.Object,
//                mockUserService.Object,
//                mockAuthenticationProvider.Object);
//            //Act 
//            service.UserIsOwner(It.IsAny<int>());

//            //Assert
//            mockAuthenticationProvider.Verify(x => x.CurrentUserId, Times.Once);
//        }

//        [TestCase(3)]
//        [TestCase(24)]
//        public void UserIsOwner_ShouldCallGetTestById_WithCorrectId(int id)
//        {
//            //Arrange
//            var mockTestService = new Mock<ITestService>();

//            var fakeTest = new Test { Id = 0 };
//            mockTestService.Setup(x => x.GetTestById(It.IsAny<int>())).Returns(fakeTest);

//            var mockUserService = new Mock<IUserService>();
//            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();

//            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(It.IsAny<string>());

//            var service = new TestsService(mockTestService.Object,
//                mockUserService.Object,
//                mockAuthenticationProvider.Object);

//            //Act 
//            service.UserIsOwner(id);

//            //Assert
//            mockTestService.Verify(x => x.GetTestById(id), Times.Once);
//        }

//        [TestCase("dsaf32r-dffd23")]
//        [TestCase("423rwds3")]
//        public void UserIsOwner_ShouldReturnTrue_UserIdEqualsTestsUserId(string userId)
//        {
//            //Arrange
//            var mockTestService = new Mock<ITestService>();

//            var fakeTest = new Test { Id = 0, UserId = userId };
//            mockTestService.Setup(x => x.GetTestById(It.IsAny<int>())).Returns(fakeTest);

//            var mockUserService = new Mock<IUserService>();
//            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
//            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(userId);

//            var service = new TestsService(mockTestService.Object,
//                mockUserService.Object,
//                mockAuthenticationProvider.Object);

//            //Act 
//            var result = service.UserIsOwner(It.IsAny<int>());

//            //Assert
//            Assert.IsTrue(result);
//        }

//        [TestCase("dsaf32r-dffd23", "2wdsf3redsf")]
//        [TestCase("423rwds3", "sd24ewd03")]
//        public void UserIsOwner_ShouldReturnFalse_WhenUserIdDoesNotEqualTestsUserId(string userId, string testUserId)
//        {
//            //Arrange
//            var mockTestService = new Mock<ITestService>();

//            var fakeTest = new Test { Id = 0, UserId = testUserId };
//            mockTestService.Setup(x => x.GetTestById(It.IsAny<int>())).Returns(fakeTest);

//            var mockUserService = new Mock<IUserService>();
//            var mockAuthenticationProvider = new Mock<IAuthenticationProvider>();
//            mockAuthenticationProvider.Setup(x => x.CurrentUserId).Returns(userId);

//            var service = new TestsService(mockTestService.Object,
//                mockUserService.Object,
//                mockAuthenticationProvider.Object);

//            //Act 
//            var result = service.UserIsOwner(It.IsAny<int>());

//            //Assert
//            Assert.IsFalse(result);
//        }
//    }
//}
