using System;
using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Factories
{
    public interface ITestFactory
    {
        Test CreateTest(string userId, IEnumerable<Question> questions, DateTime createdOn);

        AnsweredQuestion CreateAnsweredQuestion(int testId, int questionId, int answerId);
    }
}
