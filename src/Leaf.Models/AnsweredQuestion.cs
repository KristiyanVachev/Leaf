using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class AnsweredQuestion
    {
        public AnsweredQuestion()
        {
            
        }

        public AnsweredQuestion(int testId, int questionId, int answerId)
        {
            //ASK better to assign question ID or question
            this.TestId = testId;
            this.QuestionId = questionId;
            this.AnswerId = answerId;
        }

        public int Id { get; set; }

        public int TestId { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }

        public int? QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }

        [ForeignKey("AnswerId")]
        public virtual Answer Answer { get; set; }
    }
}
