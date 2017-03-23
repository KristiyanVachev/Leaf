using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Leaf.Models.Enums;

namespace Leaf.Models
{
    public class Submission
    {
        private ICollection<SubmissionAnswer> incorrectAnswers;

        public Submission()
        {
            this.incorrectAnswers = new HashSet<SubmissionAnswer>();
        }

        public Submission(string userId, string category, string condition, string correctAnswer, DateTime sentOn) : this()
        {
            this.SenderId = userId;
            this.Category = category;
            this.Condition = condition;
            this.CorrectAnswer = correctAnswer;
            this.SentOn = sentOn;
            this.State = SubmissionState.Pending;
        }

        public int Id { get; set; }

        public SubmissionState State { get; set; }

        public string ApprovedByName { get; set; }

        public DateTime? SentOn { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public string Category { get; set; }

        public string Condition { get; set; }

        public string CorrectAnswer { get; set; }

        public string SenderId { get; set; }

        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }

        public virtual ICollection<SubmissionAnswer> IncorrectAnswers
        {
            get { return this.incorrectAnswers; }
            set { this.incorrectAnswers = value; }
        }
    }
}
