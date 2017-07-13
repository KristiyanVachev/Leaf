using System;

namespace Leaf.Web.Models.Submit
{
    public class ShortSubmission
    {
        public ShortSubmission(int id, string condition, string sender, DateTime sentOn)
        {
            this.Id = id;
            this.Condition = condition;
            this.Sender = sender;
            this.SentOn = sentOn;
        }

        public int Id { get; set; }

        public string Condition { get; set; }

        public string Sender { get; set; }

        public DateTime SentOn { get; set; }
    }
}