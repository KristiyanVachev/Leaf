using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface IFullGameService
    {
        IEnumerable<Question> GetQuestions();

        Test CreateTest(string userId);

        Test GetUserTest(string userId);
    }
}
