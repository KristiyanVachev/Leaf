namespace Leaf.Services.Helpers
{
    public class CategoryStatisticHelper
    {
        public CategoryStatisticHelper(int categoryId, int total, int correct)
        {
            this.CategoryId = categoryId;
            this.Total = total;
            this.Correct = correct;
        }

        public int CategoryId { get; set; }

        public int Total { get; set; }

        public int Correct { get; set; }
    }
}
