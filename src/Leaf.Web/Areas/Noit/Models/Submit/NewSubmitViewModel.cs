using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Leaf.Web.Areas.Noit.Models.Submit
{
    public class NewSubmitViewModel
    {
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public string Condition { get; set; }

        public string CorrectAnswer { get; set; }

        public string IncorrectAnswerOne { get; set; }
    }
}