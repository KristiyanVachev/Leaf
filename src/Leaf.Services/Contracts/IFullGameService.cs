using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface IFullGameService
    {
        IEnumerable<Question> GetQuestions();

        Test CreateTest(string userId);

        bool HasUnfinishedTest(string userId);

        Test GetUserTest(string userId);

        Test GetTestById(int testId);

        void SendAnswer(int testId, int questionId, int answerId);

        Question GetNextQuestion(int test);
    }
}
