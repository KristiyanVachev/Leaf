using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class AnsweredQuestion
    {
        public int Id { get; set; }

        public int? QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }

        [ForeignKey("AnswerId")]
        public virtual Answer Answer { get; set; }

        public int TestId { get; set; } 

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }

    }
}
