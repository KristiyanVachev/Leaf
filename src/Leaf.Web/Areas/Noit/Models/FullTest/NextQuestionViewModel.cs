﻿using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Web.Areas.Noit.Models.FullTest
{
    public class NextQuestionViewModel
    {
        public NextQuestionViewModel(int questionId, string condition, ICollection<Answer> answers)
        {
            this.QuestionId = questionId;
            this.Condition = condition;
            this.Answers = answers;
        }

        public int QuestionId { get; set; }

        public string Condition { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}