using System.Collections.Generic;

namespace Leaf.Web.Models.Submit
{
    public class SubmissionViewModel
    {
        public SubmissionViewModel(string categoryName, string condtion, string correctAnswer,
            IEnumerable<string> incorrectAnswers)
        {
            this.CategoryName = categoryName;
            this.Condition = condtion;
            this.CorrectAnswer = correctAnswer;
            this.IncorrectAnswers = incorrectAnswers;
        }

        public string CategoryName { get; set; }

        public string Condition { get; set; }

        public string CorrectAnswer { get; set; }

        public IEnumerable<string> IncorrectAnswers { get; set; }
    }
}