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

        //[TestCase("423rwefs6")]
        //[TestCase("4ruwefsjl-t0ed")]
        //public void AddCategoryStatistics_Should(string id)
        //{
        //    //Arrange
        //    var mockUserRepository = new Mock<IRepository<User>>();
        //    var mockCategoryStatisticsRepository = new Mock<IRepository<CategoryStatistic>>();
        //    var mockUserFactory = new Mock<IUserFactory>();
        //    var mockUnitOfWork = new Mock<IUnitOfWork>();

        //    var utility = new UserUtility(mockUserRepository.Object,
        //        mockCategoryStatisticsRepository.Object,
        //        mockUserFactory.Object,
        //        mockUnitOfWork.Object
        //    );

        //    var fakeCategoryStatistics = new List<CategoryStatisticHelper>()
        //    {
        //        new CategoryStatisticHelper(0)
        //    };

        //    var mock = new Mock<IQueryable<CategoryStatistic>>();

        //    //TODO get a mockable replacement of Entities
        //    //mockCategoryStatisticsRepository.Setup(x => x.Entities.FirstOrDefault()).Returns(new CategoryStatistic());

        //    //Act && Assert
        //    Assert.DoesNotThrow(() => utility.AddCategoryStatistics(id, fakeCategoryStatistics));
        //}
    }
}
