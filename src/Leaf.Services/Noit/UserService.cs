using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<CategoryStatistic> categoryStatisticsRepository;
        private readonly IUserFactory userFactory;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> userRepository,
            IRepository<CategoryStatistic> categoryStatisticsRepository,
            IUserFactory userFactory,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userRepository, "userRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(categoryStatisticsRepository, "categoryStatisticsRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(userFactory, "userFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.userRepository = userRepository;
            this.categoryStatisticsRepository = categoryStatisticsRepository;
            this.userFactory = userFactory;
            this.unitOfWork = unitOfWork;
        }

        public void UpdateUserStatistics(string userId, IDictionary<int, int[]> statistics)
        {
            var user = this.userRepository.GetById(userId);

            foreach (var statisticsKey in statistics.Keys)
            {
                var categoryStatistic = user.CategoryStatistics.FirstOrDefault(x => x.CategoryId == statisticsKey);

                if (categoryStatistic == null)
                {
                    var newCategoryStatistic = this.userFactory.CreateCategoryStatistic(statisticsKey);

                    //TODO ASK: newCategoryStatistic is added to the database even without calling the repository
                    //TODO ASK: Should I leave it to EF to do is magic and add it anyway, or is it better to add it 
                    //TODO ASK: just for readability or maybe optimization
                    //this.categoryStatisticsRepository.Add(newCategoryStatistic);
                    user.CategoryStatistics.Add(newCategoryStatistic);

                    categoryStatistic = newCategoryStatistic;
                }

                categoryStatistic.Correct += statistics[statisticsKey][0];
                categoryStatistic.Incorrect += statistics[statisticsKey][1];
            }

            this.userRepository.Update(user);
            this.unitOfWork.Commit();
        }
    }
}
