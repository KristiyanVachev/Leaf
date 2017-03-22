using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class Submission
    {
        private ICollection<SubmissionAnswer> incorrectAnswers;

        public Submission()
        {
            this.incorrectAnswers = new HashSet<SubmissionAnswer>();
        }

        public Submission(string userId, string category, string condition, string correctAnswer) : this()
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

        public virtual ICollection<SubmissionAnswer> IncorrectAnswers
        {
            get { return this.incorrectAnswers; }
            set { this.incorrectAnswers = value; }
        }
    }
}
