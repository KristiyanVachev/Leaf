using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Leaf.Models.Enums;

namespace Leaf.Models
{
    public class Submission
    {
        private ICollection<SubmissionAnswer> answers;

        public Submission()
        {
            this.answers = new HashSet<SubmissionAnswer>();
        }
            
        public Submission(string userId, int categoryId, string condition, ICollection<SubmissionAnswer> answers, DateTime sentOn) : this()
        {
            this.SenderId = userId;
            this.CategoryId = categoryId;
            this.Condition = condition;
            //Virtual member call in construtor. May be a problem if the class gets inherited... which it won't.
            this.Answers = answers;
            this.SentOn = sentOn;
            this.State = SubmissionState.Pending;
        }

        public int Id { get; set; }

        public SubmissionState State { get; set; }

        public string ApprovedByName { get; set; }

        public DateTime? SentOn { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public int CategoryId { get; set; }

        public string Condition { get; set; }

        public string SenderId { get; set; }

        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }

        public virtual ICollection<SubmissionAnswer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }
    }
}
