using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Utilities.Contracts
{
    public interface IQuestionUtility
    {
        IEnumerable<Question> GetQuestions();

        Question CreateQuestion(Submission submission);

        Question GetById(int id);
    }
}
