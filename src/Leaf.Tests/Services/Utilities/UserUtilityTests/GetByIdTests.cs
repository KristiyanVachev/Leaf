using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Utilities;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Services.Utilities.UserUtilityTests
{
    public class GetByIdTests
    {
        [TestCase("423rwefs6")]
        [TestCase("4ruwefsjl-t0ed")]
        public void GetById_ShouldReturnNull_WhenQuestionIsNotFound(string id)
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

            //Act
            var user = utility.GetById(id);

            //Assert
            Assert.IsNull(user);
        }

        [TestCase("frttgyhujik")]
        [TestCase("fugihjipok[iuygfugh")]
        public void GetById_ShouldReturnQuestion_WhenFound(string id)
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


            mockUserRepository.Setup(x => x.GetById(id)).Returns(new Mock<User>().Object);

            //Act
            var question = utility.GetById(id);

            //Assert
            Assert.IsInstanceOf<User>(question);
        }
    }
}
