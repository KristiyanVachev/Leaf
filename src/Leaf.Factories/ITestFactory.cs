using System;
using System.Collections.Generic;
using Leaf.Models;
using Leaf.Models.Enums;

namespace Leaf.Factories
{
    public interface ITestFactory
    {
        Test CreateTest(string userId, IEnumerable<Question> questions, DateTime createdOn, TestType type);

        AnsweredQuestion CreateAnsweredQuestion(int testId, int questionId, int answerId);
    }
}
