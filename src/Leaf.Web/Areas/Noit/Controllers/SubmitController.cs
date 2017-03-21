using System.Net;
using System.Web.Mvc;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Models;

namespace Leaf.Web.Areas.Noit.Controllers
{
    public class SubmitController : Controller
    {
        private ISubmitService submitService;
        private IAuthenticationProvider authenticationProvider;

        public SubmitController(ISubmitService submitService,
            IAuthenticationProvider authenticationProvider)
        {
            this.submitService = submitService;
            this.authenticationProvider = authenticationProvider;
        }

        // GET: Noit/Submit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submission()
        {
            //TODO: Categories dropdown list
            //var viewModel = new SubmissionViewModel { Categories = GetCategories() };

            return this.View(new SubmissionViewModel());
        }

        [HttpPost]
        public RedirectToRouteResult CreateSubmission(SubmissionViewModel viewModel)
        {
            var userId = authenticationProvider.CurrentUserId;

            this.submitService.CreateSubmission(userId, "Category", viewModel.Condition, viewModel.CorrectAnswer);
            return this.RedirectToAction("Index");
        }

        //private IEnumerable<SelectListItem> GetCategories()
        //{
        //    var categories = categoryRepository.GetAll().Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.Id.ToString(),
        //                            Text = x.Name
        //                        });

        //    return new SelectList(categories, "Value", "Text");
        //}
    }
}