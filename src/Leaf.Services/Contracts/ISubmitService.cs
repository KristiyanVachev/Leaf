using System.Collections.Generic;
using System.Web.Mvc;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface ISubmitService
    {
        Submission CreateSubmission(string userId,
            string category,
            string condition,
            string correctAnswer,
            string[] incorrectAnswers
            );

        IEnumerable<SelectListItem> GetCategories();

        Submission GetSubmissionById(int id);
    }
}
