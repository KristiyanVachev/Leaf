using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Utilities.UserUtilityTests
{
    public class ConstructorTests
    {
        [Test]
        public void Constructor_ShouldNotThrow_WhenParametersNotNull()
        {
            //Arrange
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockCategoryStatisticsRepository = new Mock<IRepository<CategoryStatistic>>();
            var mockUserFactory = new Mock<IUserFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            //Act && Assert
            Assert.DoesNotThrow(() =>
                new UserUtility(mockUserRepository.Object,
                    mockCategoryStatisticsRepository.Object,
                    mockUserFactory.Object,
                    mockUnitOfWork.Object
                )
            );
        }
    }
}
