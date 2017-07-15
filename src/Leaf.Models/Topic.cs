using System.Collections.Generic;

namespace Leaf.Models
{
    public class Topic
    {
        private ICollection<Category> categories;
        private ICollection<Question> questions;

        public Topic()
        {
            this.questions = new HashSet<Question>();
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}
