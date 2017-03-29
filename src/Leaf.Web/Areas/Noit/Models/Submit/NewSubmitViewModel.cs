using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Leaf.Commom;

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
        [MaxLength(50, ErrorMessage = Constants.CommentMaxLenght)]
        public string IncorrectAnswerOne { get; set; }

        [Required]
        [AllowHtml]
        [MaxLength(50, ErrorMessage = Constants.CommentMaxLenght)]
        public string IncorrectAnswerTwo { get; set; }

        [Required]
        [AllowHtml]
        [MaxLength(50, ErrorMessage = Constants.CommentMaxLenght)]
        public string IncorrectAnswerThree { get; set; }

        [AllowHtml]
        [Required]
        public string[] IncorrectAnswers { get; set; }
    }
}