namespace Leaf.Web.Models.Tests
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