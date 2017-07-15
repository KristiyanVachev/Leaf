using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int? TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

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
