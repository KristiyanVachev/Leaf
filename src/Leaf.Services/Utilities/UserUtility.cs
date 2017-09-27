using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Helpers;
using Leaf.Services.Utilities.Contracts;

namespace Leaf.Services.Utilities
{
    public class UserUtility : IUserUtility
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<CategoryStatistic> categoryStatisticsRepository;
        private readonly IUserFactory userFactory;
        private readonly IUnitOfWork unitOfWork;

        public UserUtility(IRepository<User> userRepository,
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

        //TODO add paging
        public IEnumerable<User> GetAll()
        {
            return this.userRepository.Entities.ToList();
        }

        public User GetById(string id)
        {
            return this.userRepository.GetById(id);
        }

        public void AddCategoryStatistics(string userId, IEnumerable<CategoryStatisticHelper> categoryStatistics)
        {
            var user = this.userRepository.GetById(userId);

            if (user == null)
            {
                return;
            }
   
            foreach (var newCategoryStatistics in categoryStatistics)
            {
                //Get if exists
                var categoryStatistic = this.categoryStatisticsRepository.Entities
                    .Where(x => x.UserId == user.Id)
                    .FirstOrDefault(x => x.CategoryId == newCategoryStatistics.CategoryId);

                //Create if it doesn't exist
                if (categoryStatistic == null)
                {
                    categoryStatistic = this.userFactory.CreateCategoryStatistic(newCategoryStatistics.CategoryId);

                    categoryStatistic.Correct += newCategoryStatistics.Correct;
                    categoryStatistic.Total += newCategoryStatistics.Total;
                    categoryStatistic.UserId = userId;

                    this.categoryStatisticsRepository.Add(categoryStatistic);
                }
                else
                {
                    //Update
                    categoryStatistic.Correct += newCategoryStatistics.Correct;
                    categoryStatistic.Total += newCategoryStatistics.Total;

                    this.categoryStatisticsRepository.Update(categoryStatistic);
                }
            }

            this.unitOfWork.Commit();
        }
    }
}
