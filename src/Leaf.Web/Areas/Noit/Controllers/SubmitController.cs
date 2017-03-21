using System.Web.Mvc;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Models.Submit;

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

        public ActionResult New()
        {
            var categories = this.submitService.GetCategories();
            var viewModel = new NewSubmitViewModel() { Categories = categories };

            return this.View(viewModel);
        }

        public ActionResult Submission(int id)
        {
            var submission = this.submitService.GetSubmissionById(id);

            var viewModel = new SubmissionViewModel
            {
                Condition = submission.Condition,
                CorrectAnswer = submission.CorrectAnswer
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public RedirectToRouteResult CreateSubmission(SubmissionViewModel viewModel)
        {
            var userId = authenticationProvider.CurrentUserId;

            var submission = this.submitService.CreateSubmission(userId, viewModel.CategoryName, viewModel.Condition, viewModel.CorrectAnswer);

            return this.RedirectToAction("Submission", new {id = submission.Id});
        }
    }
}