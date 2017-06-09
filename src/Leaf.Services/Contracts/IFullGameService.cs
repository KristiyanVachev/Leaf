using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface IFullGameService
    {
        bool HasUnfinishedTest();

        bool HasUnfinishedPractice();

        Test ContinueTest();

        Test CreateTest();

        Test ContinuePractice();

        Test CreatePractice();

        Test GetTestById(int testId);

        void SendAnswer(int testId, int questionId, int answerId);

        Question GetNextQuestion(int test);

        void EndTest(int testId);

        bool UserIsOwner(int testId);
    }
}
