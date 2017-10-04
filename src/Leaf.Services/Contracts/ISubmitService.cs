using System.Collections.Generic;
using System.Web.Mvc;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface ISubmitService
    {
        Submission CreateSubmission(string userId,
            int categoryId,
            string condition,
            string correctAnswer,
            ICollection<string> incorrectAnswers
            );

        IEnumerable<SelectListItem> GetCategories();

        Submission GetSubmissionById(int id);
    }
}
