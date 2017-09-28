using Leaf.Models;

namespace Leaf.Factories
{
    public interface IUserFactory
    {
        CategoryStatistic CreateCategoryStatistic(int categoryId);

        User CreateUser(string userName, string email);
    }
}
