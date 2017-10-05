using System;
using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Factories
{
    public interface ISubmitFactory
    {
        Submission CreateSubmission(string userId, int categoryId, string condition, ICollection<SubmissionAnswer> answers, DateTime sentOn);

        SubmissionAnswer CreateSubmissionAnswer(bool isCorrect, string content);
    }
}
