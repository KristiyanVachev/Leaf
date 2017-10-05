using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class SubmissionAnswer
    {
        public SubmissionAnswer()
        {
            
        }

        public SubmissionAnswer(bool isCorrect, string content)
        {
            this.IsCorrect = isCorrect;
            this.Content = content;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int SubmissionId { get; set; }

        [ForeignKey("SubmissionId")]
        public virtual Submission Submission { get; set; }
    }
}
