using System;
using System.Collections.Generic;

namespace Leaf.Services.Helpers.Contracts
{
    public interface IFinishedTestHelper
    {
        int TestId { get; set; }

        DateTime? End { get; set; }

        ICollection<AnsweredQuestionHelper> AnsweredQuestions { get; set; }
    }
}
