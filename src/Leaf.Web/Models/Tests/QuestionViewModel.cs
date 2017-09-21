using Leaf.Models;

namespace Leaf.Web.Models.Tests
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            
        }

        public QuestionViewModel(Question question)
        {
            this.Question = question;
            this.QuestionId = question.Id;
        }

        public Question Question { get; set; }

        public int QuestionId { get; set; }

        public int SelectedAnswerId { get; set; }
    }
}