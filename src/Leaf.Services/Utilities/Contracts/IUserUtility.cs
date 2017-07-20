using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Utilities.Contracts
{
    public interface IUserUtility
    {
        void UpdateUserStatistics(string userId, IDictionary<int, int[]> statistics);

        IEnumerable<User> GetAll();

        User GetById(string id);
    }
}
