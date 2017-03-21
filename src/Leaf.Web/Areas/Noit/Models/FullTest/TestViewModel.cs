namespace Leaf.Web.Areas.Noit.Models.FullTest
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            
        }

        public TestViewModel(int testId)
        {
            this.TestId = testId;
        }

        public int TestId { get; set; }
    }
}