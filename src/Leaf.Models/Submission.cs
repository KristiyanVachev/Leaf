using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class Submission
    {
        public Submission()
        {
            
        }

        public Submission(string userId, string category, string condition, string correctAnswer)
        {
            this.UserId = userId;
            this.Category = category;
            this.Condition = condition;
            this.CorrectAnswer = correctAnswer;
        }

        public int Id { get; set; }

        public string Category { get; set; }

        public string Condition { get; set; }

        public string CorrectAnswer { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Sender { get; set; }
    }
}
