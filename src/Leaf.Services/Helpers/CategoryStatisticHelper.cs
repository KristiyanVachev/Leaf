namespace Leaf.Services.Helpers
{
    public class CategoryStatisticHelper
    {
        public CategoryStatisticHelper(int categoryId, int total = 0, int correct = 0)
        {
            this.CategoryId = categoryId;
            this.Total = total;
            this.Correct = correct;
        }

        public int CategoryId { get; set; }

        public int Total { get; set; }

        public int Correct { get; set; }

        public void AddCorrect()
        {
            this.Correct++;
            this.Total++;
        }

        public void AddIncorrect()
        {
            this.Total++;
        }
    }
}
