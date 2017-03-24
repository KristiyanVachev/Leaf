using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface ISubmissionAnswerService
    {
        ICollection<SubmissionAnswer> CreateSubmissionAnswers(string[] answers);
    }
}
