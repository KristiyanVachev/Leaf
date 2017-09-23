﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Leaf.Web.Models.Submit;

namespace Leaf.Web.Models
{
    public interface IViewModelFactory
    {
        NewSubmitViewModel CreateNewSubmitViewModel(IEnumerable<SelectListItem> categories, string[] incorrectAnswers);

        SubmissionViewModel CreateSubmissionViewModel(string categoryName, string condtion, string correctAnswer,
            IEnumerable<string> incorrectAnswers);

        ShortSubmission CreateShortSubmission(int id, string condition, string sender, DateTime sentOn);
    }
}