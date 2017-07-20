using System.Collections.Generic;
using Leaf.Models;
using Leaf.Models.Enums;

namespace Leaf.Services.Contracts
{
    public interface ITestService
    {
        Test CreateTest(string userId, TestType type, IEnumerable<Question> questions);

        Test GetLastTest(string userId, TestType type);

        Test GetTestById(int testId);

        void AddAnswer(int testId, int questionId, int answerId);

        void RemoveQuestionById(int testId, int questionId);

        bool TestIsFinished(int testId);

        void EndTest(int testId);

        IDictionary<int, int[]> GatherTestStatistics(int testId);
    }
}
