using Leaf.Models;

namespace Leaf.Factories
{
    public interface ISubmitFactory
    {
        Submission CreateSubmission(string userId, string category, string condition, string correctAnswer);

        SubmissionAnswer CreateSubmissionAnswer(string content);
    }
}
