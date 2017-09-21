using System.Collections.Generic;
using Leaf.Models;
using Leaf.Models.Enums;

namespace Leaf.Services.Contracts
{
    public interface ITestService
    {
        Test CreateTest(TestType type);

        Test EndTest(int testId, Dictionary<int, int> answeredQuestions);

        Test GetTestById(int testId);

        bool UserIsOwner(int testId);
    }
}
