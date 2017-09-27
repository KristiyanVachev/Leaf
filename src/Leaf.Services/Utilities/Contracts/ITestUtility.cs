using System.Collections.Generic;
using Leaf.Models;
using Leaf.Models.Enums;

namespace Leaf.Services.Utilities.Contracts
{
    public interface ITestUtility
    {
        Test CreateTest(string userId, TestType type, IEnumerable<Question> questions);

        Test GetLastUnfinishedTest(string userId, TestType type);

        Test GetTestById(int testId);

        void AddAnswers(int testId, ICollection<Helpers.AnsweredQuestionHelper> answeredQuestions);

        void FinishTest(int testId);

        IEnumerable<CategoryStatistic> GatherCategoryStatistics(Dictionary<int, int> answeredQuestions);
    }
}
