using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Leaf.Commom;

namespace Leaf.Web.Models.Submit
{
    public class NewSubmitViewModel
    {
        public NewSubmitViewModel()
        {

        }

        public NewSubmitViewModel(IEnumerable<SelectListItem> categories)
        {
            this.Categories = categories;
        }

        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required]
        [AllowHtml]
        [MinLength(8, ErrorMessage = Constants.ConditionMinLenght)]
        [MaxLength(100, ErrorMessage = Constants.ConditionMaxLenght)]
        public string Condition { get; set; }

        [Required]
        [AllowHtml]
        [MaxLength(50, ErrorMessage = Constants.CommentMaxLenght)]
        public string CorrectAnswer { get; set; }

        [Required]
        [AllowHtml]
        //TODO Add fluent validation
        public IList<string> IncorrectAnswers { get; set; }
    }
}