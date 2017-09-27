using System.Collections.Generic;
using System.Linq;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Helpers;
using Leaf.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Utilities.UserUtilityTests
{
    public class AddCategoryStatisticsTests
    {
        [TestCase("423rwefs6")]
        [TestCase("4ruwefsjl-t0ed")]
        public void AddCategoryStatistics_ShouldNotThrow_WhenUserIdIsNotFound(string id)
        {
            //Arrange
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockCategoryStatisticsRepository = new Mock<IRepository<CategoryStatistic>>();
            var mockUserFactory = new Mock<IUserFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var utility = new UserUtility(mockUserRepository.Object,
                mockCategoryStatisticsRepository.Object,
                mockUserFactory.Object,
                mockUnitOfWork.Object
            );

            var mockCategoryStatistics = new Mock<IEnumerable<CategoryStatisticHelper>>();

            //Act && Assert
            Assert.DoesNotThrow(() => utility.AddCategoryStatistics(id, mockCategoryStatistics.Object));
        }

        [Test]
        public void AddCategoryStatistics_ShouldCreateNewCategoryStatistic_WhenItDoesntExist()
        {
            //Arrange
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockCategoryStatisticsRepository = new Mock<IRepository<CategoryStatistic>>();
            var mockUserFactory = new Mock<IUserFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var utility = new UserUtility(mockUserRepository.Object,
                mockCategoryStatisticsRepository.Object,
                mockUserFactory.Object,
                mockUnitOfWork.Object
            );

            var fakeCategoryStatisticsHelper = new List<CategoryStatisticHelper>
            {
                new CategoryStatisticHelper(0)
            }.AsEnumerable();

            var fakeUser = new User();
            mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(fakeUser);

            mockUserFactory.Setup(x => x.CreateCategoryStatistic(It.IsAny<int>())).Returns(new CategoryStatistic());

            //var fakeCategoryStatistics = new List<CategoryStatistic>
            //{
            //    new CategoryStatistic {UserId = fakeUser.Id, CategoryId = 0}
            //}.AsQueryable();

            //mockCategoryStatisticsRepository.Setup(x => x.Entities).Returns(fakeCategoryStatistics);

            //Act
            utility.AddCategoryStatistics(It.IsAny<string>(), fakeCategoryStatisticsHelper);
            
            //Assert
            mockUserFactory.Verify(x => x.CreateCategoryStatistic(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void AddCategoryStatistics_ShouldUpdateCategoryStatistic_WhenItExists()
        {
            //Arrange
            var mockUserRepository = new Mock<IRepository<User>>();
            var mockCategoryStatisticsRepository = new Mock<IRepository<CategoryStatistic>>();
            var mockUserFactory = new Mock<IUserFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var utility = new UserUtility(mockUserRepository.Object,
                mockCategoryStatisticsRepository.Object,
                mockUserFactory.Object,
                mockUnitOfWork.Object
            );

            var fakeCategoryStatisticsHelper = new List<CategoryStatisticHelper>
            {
                new CategoryStatisticHelper(0)
            }.AsEnumerable();

            var fakeUser = new User();
            mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(fakeUser);

            var fakeCategoryStatistics = new List<CategoryStatistic>
            {
                new CategoryStatistic {UserId = fakeUser.Id, CategoryId = 0}
            }.AsQueryable();

            mockCategoryStatisticsRepository.Setup(x => x.Entities).Returns(fakeCategoryStatistics);

            //Act
            utility.AddCategoryStatistics(It.IsAny<string>(), fakeCategoryStatisticsHelper);

            //Assert
            mockCategoryStatisticsRepository.Verify(x => x.Update(It.IsAny<CategoryStatistic>()), Times.Once);
        }
    }
}
