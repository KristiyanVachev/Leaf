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
            var categories = this.submitService.GetCategories();
            var viewModel = new SubmissionViewModel { Categories = categories };

            return this.View(viewModel);
        }

        [HttpPost]
        public RedirectToRouteResult CreateSubmission(SubmissionViewModel viewModel)
        {
            var userId = authenticationProvider.CurrentUserId;

            this.submitService.CreateSubmission(userId, viewModel.CategoryName, viewModel.Condition, viewModel.CorrectAnswer);
            return this.RedirectToAction("Index");
        }


    }
}