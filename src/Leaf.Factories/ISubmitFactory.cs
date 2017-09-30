using System;
using Leaf.Models;

namespace Leaf.Factories
{
    public interface ISubmitFactory
    {
        Submission CreateSubmission(string userId, int categoryId, string condition, string correctAnswer, DateTime sentOn);

        SubmissionAnswer CreateSubmissionAnswer(string content);
    }
}
