using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface ITestService
    {
        Test CreateTest(string userId);

        Test GetLastTestByUserId(string userId);

        Test GetTestById(int testId);

        bool IsNullOrFinished(Test test);
    }
}
