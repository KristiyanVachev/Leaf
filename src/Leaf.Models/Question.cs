using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class Question
    {
        private ICollection<Answer> answers;
        private ICollection<Test> tests;

        public Question()
        {
            this.answers = new HashSet<Answer>();
            this.tests = new HashSet<Test>();
        }

        public Question(string condition) : this()
        {
            this.Condition = condition;
        }

        public int Id { get; set; }

        public string Condition { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

        public virtual ICollection<Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }
    }
}
