using System.Collections.Generic;

namespace Leaf.Web.Models.Submit
{
    public class SubmissionViewModel
    {
        public SubmissionViewModel(string categoryName, string condtion,IEnumerable<string> answers)
        {
            this.CategoryName = categoryName;
            this.Condition = condtion;
            this.Answers = answers;
        }

        public string CategoryName { get; set; }

        public string Condition { get; set; }

        public string CorrectAnswer { get; set; }

        public IEnumerable<string> Answers { get; set; }
    }
}