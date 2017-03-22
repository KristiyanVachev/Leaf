using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class Answer
    {
        public Answer()
        {

        }

        public Answer(string content, bool isCorrect) : this()
        {
            this.Content = content;
            this.IsCorrect = isCorrect;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
