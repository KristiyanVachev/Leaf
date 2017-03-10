using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Factories
{
    public interface ITestFactory
    {
        Test CreateTest(string userId, IEnumerable<Question> questions, bool isFinished = false);
    }
}
