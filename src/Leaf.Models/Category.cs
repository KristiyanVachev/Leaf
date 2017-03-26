using System.Collections.Generic;

namespace Leaf.Models
{
    public class Category
    {
        private ICollection<Question> questions;
        private ICollection<CategoryStatistic> categoryStatistics;

        public Category()
        {
            this.questions = new HashSet<Question>();
            this.categoryStatistics = new HashSet<CategoryStatistic>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }

        public virtual ICollection<CategoryStatistic> CategoryStatistics
        {
            get { return this.categoryStatistics; }
            set { this.categoryStatistics= value; }
        }
    }
}
