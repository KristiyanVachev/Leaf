using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class Question
    {
        private ICollection<Answer> answers;

        public Question()
        {
            this.answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        //[StringLenght( 100, MinimumLength = 10)]
        public string Condition { get; set; }

        //statistics for every question
        public int TimesAnswered { get; set; }

        public int CorrectlyAnsweredCount { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }
    }
}
