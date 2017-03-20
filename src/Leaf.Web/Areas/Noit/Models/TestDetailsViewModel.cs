namespace Leaf.Web.Areas.Noit.Models
{
    public class TestDetailsViewModel
    {
        public TestDetailsViewModel(int correctCount)
        {
            this.CorrectCount = correctCount;
        }

        public int CorrectCount { get; set; }
    }
}