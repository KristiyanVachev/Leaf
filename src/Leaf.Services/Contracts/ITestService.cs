using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface ITestService
    {
        Test CreateTest(string userId);

        Test CreatePractice(string userId);

        Test GetLastTestByUserId(string userId);

        Test GetLastPracticeByUserId(string userId);

        Test GetTestById(int testId);

        bool IsNullOrFinished(Test test);

        void AddAnswer(int testId, int questionId, int answerId);

        void RemoveQuestionById(int testId, int questionId);

        bool TestIsFinished(int testId);

        void EndTest(int testId);

        IDictionary<int, int[]> GatherTestStatistics(int testId);
    }
}
