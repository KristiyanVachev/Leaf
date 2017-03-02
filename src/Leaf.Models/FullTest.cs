using System;
using System.Collections.Generic;

namespace Leaf.Models
{
    public class FullTest
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual User User { get; set; }

        public string GameType { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public int CorrectCount { get; set; }

        public int InCorrectCount { get; set; }

        public virtual ICollection<Question> CorrectAnswered { get; set; }

        public virtual ICollection<Question> InCorrectAnswered { get; set; }
    }
}
