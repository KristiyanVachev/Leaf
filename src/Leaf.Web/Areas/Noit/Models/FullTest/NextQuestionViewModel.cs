using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Web.Areas.Noit.Models.FullTest
{
    public class NextQuestionViewModel
    {
        public NextQuestionViewModel(int testId, int questionId, string condition, ICollection<Answer> answers)
        {
            this.TestId = testId;
            this.QuestionId = questionId;
            this.Condition = condition;
            this.Answers = answers;
        }

        public int TestId { get; set; }

        public int QuestionId { get; set; }

        public string Condition { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}