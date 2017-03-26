﻿using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullTestServiceTests
{
    [TestFixture]
    public class GetUserTestTests
    {
        [TestCase("3")]
        [TestCase("dsdws")]
        public void GetUserTest_ShouldCallGetLastTestByUserId_WithCorrectId(string id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            var mockUserService = new Mock<IUserService>();

            var service = new FullTestService(mockTestService.Object, mockUserService.Object);
            //Act 
            service.GetUserTest(id);

            //Assert
            mockTestService.Verify(x => x.GetLastTestByUserId(id), Times.Once);   
        }

        [TestCase("4")]
        [TestCase("fasfs")]
        public void GetUserTest_ShouldCallCreateTest_WhenTestIsUnfinished(string id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            mockTestService.Setup(x => x.IsNullOrFinished(It.IsAny<Test>())).Returns(true);

            var mockUserService = new Mock<IUserService>();

            var service = new FullTestService(mockTestService.Object, mockUserService.Object);

            //Act 
            service.GetUserTest(id);

            //Assert
            mockTestService.Verify(x => x.CreateTest(id), Times.Once);
        }

        [TestCase("4")]
        [TestCase("fasfs")]
        public void GetUserTest_ShouldReturnCreatedTest_WhenLastTestIsUnfinished(string id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();
            mockTestService.Setup(x => x.IsNullOrFinished(It.IsAny<Test>())).Returns(true);

            var mockTest = new Mock<Test>();
            mockTestService.Setup(x => x.CreateTest(id)).Returns(mockTest.Object);

            var mockUserService = new Mock<IUserService>();

            var service = new FullTestService(mockTestService.Object, mockUserService.Object);

            //Act 
            var result = service.GetUserTest(id);

            //Assert
            Assert.AreSame(mockTest.Object, result);
        }
    }
}
