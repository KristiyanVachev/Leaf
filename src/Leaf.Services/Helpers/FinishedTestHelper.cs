using System;
using System.Collections.Generic;
using Leaf.Services.Helpers.Contracts;

namespace Leaf.Services.Helpers
{
    public class FinishedTestHelper : IFinishedTestHelper
    {
        public FinishedTestHelper(int testId)
        {
            this.TestId = testId;
            this.AnsweredQuestions = new List<AnsweredQuestionHelper>();
        }

        public FinishedTestHelper(int testId, DateTime end) : this(testId)
        {
            this.End = end;
        }

        public int TestId { get; set; }

        public DateTime? End { get; set; }

        public ICollection<AnsweredQuestionHelper> AnsweredQuestions { get; set; }
    }
}
