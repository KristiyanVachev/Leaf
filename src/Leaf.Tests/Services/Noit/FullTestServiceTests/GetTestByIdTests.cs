using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Noit.FullTestServiceTests
{
    [TestFixture]
    public class GetTestByIdTests
    {
        [TestCase(4)]
        [TestCase(53242)]
        public void GetTestById_ShouldCallTestRepositoryGetById(int id)
        {
            //Arrange
            var mockTestService = new Mock<ITestService>();

            var service = new FullTestService(mockTestService.Object);

            //Act 
            service.GetTestById(id);

            //Assert
            mockTestService.Verify(x => x.GetTestById(id), Times.Once);
        }
    }
}
