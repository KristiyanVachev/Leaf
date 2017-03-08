using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class Test
    {
        private ICollection<AnsweredQuestion> answeredQuestions;

        public Test()
        {
            this.answeredQuestions = new HashSet<AnsweredQuestion>();
        }

        public int Id { get; set; }

        public bool IsFinished { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
      
        public virtual ICollection<AnsweredQuestion> AnsweredQuestions
        {
            get { return this.answeredQuestions; }
            set { this.answeredQuestions = value; }
        }
    }
}
