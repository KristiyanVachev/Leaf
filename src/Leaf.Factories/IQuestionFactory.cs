using Leaf.Models;

namespace Leaf.Factories
{
    public interface IQuestionFactory
    {
        Question CreateQuestion(string condition);

        Answer CreateAnswer(string content, bool isCorrect);
    }
}
