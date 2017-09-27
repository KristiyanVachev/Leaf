using System.Collections.Generic;
using Leaf.Models;
using Leaf.Services.Helpers;

namespace Leaf.Services.Utilities.Contracts
{
    public interface IUserUtility
    {
        IEnumerable<User> GetAll();

        User GetById(string id);

        void AddCategoryStatistics(string userId, IEnumerable<CategoryStatisticHelper> categoryStatistics);
    }
}
