using System.Collections.Generic;
using System.Web.Mvc;
using Leaf.Web.Areas.Noit.Models.Submit;

namespace Leaf.Web.Areas.Noit.Models
{
    public interface IViewModelFactory
    {
        NewSubmitViewModel CreateNewSubmitViewModel(IEnumerable<SelectListItem> categories, string[] incorrectAnswers);

        SubmissionViewModel CreateSubmissionViewModel(string categoryName, string condtion, string correctAnswer,
            IEnumerable<string> incorrectAnswers);
    }
}