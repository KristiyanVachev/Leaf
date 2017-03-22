namespace Leaf.Web.Areas.Noit.Models.Submit
{
    public class SubmissionViewModel
    {
        public string CategoryName { get; set; }

        public string Condition { get; set; }

        public string CorrectAnswer { get; set; }

        public string[] IncorrectAnswers { get; set; }
    }
}