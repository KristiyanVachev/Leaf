namespace Leaf.Web.Models.Tests
{
    public class IndexViewModel
    {
        public IndexViewModel(bool hasUnfinishedTest, bool hasUnfinishedPractice)
        {
            this.HasUnfinishedTest = hasUnfinishedTest;
            this.HasUnfinishedPractice = hasUnfinishedPractice;
        }

        public bool HasUnfinishedTest { get; set; }
        public bool HasUnfinishedPractice { get; set; }
    }
}