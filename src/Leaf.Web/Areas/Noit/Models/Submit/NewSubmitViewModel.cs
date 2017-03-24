using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Leaf.Web.Areas.Noit.Models.Submit
{
    public class NewSubmitViewModel
    {
        public NewSubmitViewModel()
        {
            
        }

        public NewSubmitViewModel(IEnumerable<SelectListItem> categories, string[] incorrectAnswers)
        {
            this.Categories = categories;
            this.IncorrectAnswers = incorrectAnswers;
        }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Condition must be atleast 8 symbols long")]
        [MaxLength(100, ErrorMessage = "Condition must be below 100 symbols long.")]
        public string Condition { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Correct answer must be below 50 symbols long.")]
        public string CorrectAnswer { get; set; }

        [Required]
        public string[] IncorrectAnswers { get; set; }
    }
}