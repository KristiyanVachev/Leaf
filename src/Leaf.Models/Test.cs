using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class Test
    {
        private ICollection<AnsweredQuestion> answeredQuestions;
        private ICollection<Question> questions;

        public Test()
        {
            this.answeredQuestions = new HashSet<AnsweredQuestion>();
            this.questions = new HashSet<Question>();
        }

        public Test(string userId, ICollection<Question> questions, bool isFinished ) : this()
        {
            this.UserId = userId;
            this.questions = questions;
            this.IsFinished = isFinished;
        }

        public int Id { get; set; }

        public bool IsFinished { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public int CorrectCount { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<AnsweredQuestion> AnsweredQuestions
        {
            get { return this.answeredQuestions; }
            set { this.answeredQuestions = value; }
        }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}
