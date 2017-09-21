using System;
using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Web.Models.Tests
{
    public class NewTestViewModel
    {
        public NewTestViewModel()
        {

        }

        public NewTestViewModel(int testId, IEnumerable<Question> questions)
        {
            this.TestId = testId;
            
            this.Questions = new List<QuestionViewModel>();

            foreach (var question in questions)
            {
                this.Questions.Add(new QuestionViewModel(question));
            }
        }

        public int TestId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public IList<QuestionViewModel> Questions { get; set; }
    }
}