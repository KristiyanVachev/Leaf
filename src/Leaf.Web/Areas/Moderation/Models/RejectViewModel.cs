namespace Leaf.Web.Areas.Moderation.Models
{
    public class RejectViewModel
    {
        public RejectViewModel()
        {
            
        }

        public RejectViewModel(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public string Message { get; set; }
    }
}