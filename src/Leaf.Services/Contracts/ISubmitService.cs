using System.Collections.Generic;
using System.Web.Mvc;

namespace Leaf.Services.Contracts
{
    public interface ISubmitService
    {
        void CreateSubmission(string userId ,string category, string condition, string correctAnswer);

        IEnumerable<SelectListItem> GetCategories();
    }
}
