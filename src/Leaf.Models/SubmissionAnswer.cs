using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class SubmissionAnswer
    {
        public SubmissionAnswer()
        {
            
        }

        public SubmissionAnswer(string content)
        {
            this.Content = content;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public int SubmissionId { get; set; }

        [ForeignKey("SubmissionId")]
        public virtual Submission Submission { get; set; }
    }
}
