using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Leaf.Web.Areas.Noit.Models
{
    public class SubmissionViewModel
    {
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public string Condition { get; set; }

        public string CorrectAnswer { get; set; }

        public string IncorrectAnswerOne { get; set; }
    }
}