using Leaf.Models;
using Leaf.Models.Enums;

namespace Leaf.Services.Contracts
{
    public interface IFullGameService
    {
        bool HasUnfinishedTest(TestType type);

        Test ContinueTest(TestType type);

        Test CreateTest();

        Test CreatePractice();

        Test GetTestById(int testId);

        void SendAnswer(int testId, int questionId, int answerId);

        Question GetNextQuestion(int test);

        void EndTest(int testId);

        bool UserIsOwner(int testId);
    }
}
