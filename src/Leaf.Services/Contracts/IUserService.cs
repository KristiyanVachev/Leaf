using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface IUserService
    {
        void UpdateUserStatistics(string userId, IDictionary<int, int[]> statistics);

        IEnumerable<User> GetAll();
    }
}
