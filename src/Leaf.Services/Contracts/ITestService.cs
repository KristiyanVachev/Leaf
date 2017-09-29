using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Helpers.Contracts;

namespace Leaf.Services.Contracts
{
    public interface ITestService
    {
        Test NewTest(TestType type);

        Test EndTest(IFinishedTestHelper finishedTestHelper);

        Test GetTestById(int testId);

        bool UserIsOwner(int testId);
    }
}
