namespace Leaf.Web.Areas.Noit.Models.FullTest
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