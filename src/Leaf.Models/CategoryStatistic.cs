using System.ComponentModel.DataAnnotations.Schema;

namespace Leaf.Models
{
    public class CategoryStatistic
    {
        public int Id { get; set; }

        public int Correct { get; set; }

        public int Incorrect { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
