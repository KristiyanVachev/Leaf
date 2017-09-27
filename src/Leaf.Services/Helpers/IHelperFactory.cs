﻿using System;

namespace Leaf.Services.Helpers
{
    public interface IHelperFactory
    {
        AnsweredQuestionHelper CreateAnsweredQuestion(int questionId, int answerId);

        FinishedTestHelper CreateFinishedTest(int testId);

        FinishedTestHelper CreateFinishedTest(int testId, DateTime end);
    }
}
