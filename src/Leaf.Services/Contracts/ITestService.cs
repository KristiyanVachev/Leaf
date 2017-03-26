using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface ITestService
    {
        Test CreateTest(string userId);

        Test GetLastTestByUserId(string userId);

        Test GetTestById(int testId);

        bool IsNullOrFinished(Test test);

        void AddAnswer(int testId, int questionId, int answerId);

        void RemoveQuestionById(int testId, int questionId);

        bool TestIsFinished(int testId);

        void EndTest(int testId);

        void UpdateUserCategoriesStatistics(int testId);
    }
}
