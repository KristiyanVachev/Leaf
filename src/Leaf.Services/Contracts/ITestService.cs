using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Helpers;

namespace Leaf.Services.Contracts
{
    public interface ITestService
    {
        Test CreateTest(TestType type);

        Test EndTest(FinishedTestHelper finishedTestHelper);

        Test GetTestById(int testId);

        bool UserIsOwner(int testId);
    }
}
