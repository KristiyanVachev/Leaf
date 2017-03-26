using Leaf.Models;

namespace Leaf.Factories
{
    public interface IUserFactory
    {
        CategoryStatistic CreateCategoryStatistic(int categoryId);
    }
}
