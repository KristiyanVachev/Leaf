using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Models;
using Leaf.Web.Areas.Noit.Models.Submit;

namespace Leaf.Web.Areas.Noit.Controllers
{
    [Authorize]
    public class SubmitController : Controller
    {
        private ISubmitService submitService;
        private IAuthenticationProvider authenticationProvider;
        private IViewModelFactory viewModelFactory;

        public SubmitController(ISubmitService submitService,
            IAuthenticationProvider authenticationProvider,
            IViewModelFactory viewModelFactory)
        {
            Guard.WhenArgument(submitService, "submitService cannot be null").IsNull().Throw();
            Guard.WhenArgument(authenticationProvider, "AuthenticationProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(viewModelFactory, "viewModelFactory cannot be null").IsNull().Throw();

            this.submitService = submitService;
            this.authenticationProvider = authenticationProvider;
            this.viewModelFactory = viewModelFactory;
        }

        // GET: Noit/Submit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var categories = this.submitService.GetCategories();

            var viewModel = this.viewModelFactory.CreateNewSubmitViewModel(categories, new string[3]);

            return this.View(viewModel);
        }

        public ActionResult Submission(int id)
        {
            var submission = this.submitService.GetSubmissionById(id);

            var viewModel = this.viewModelFactory.CreateSubmissionViewModel(submission.Category, submission.Condition,
                submission.CorrectAnswer, submission.IncorrectAnswers.Select(x => x.Content));

            return this.View(viewModel);
        }

        [HttpPost]
        public RedirectToRouteResult CreateSubmission(NewSubmitViewModel viewModel)
        {
            var userId = authenticationProvider.CurrentUserId;

            var submission = this.submitService.CreateSubmission(userId,
                viewModel.CategoryName,
                viewModel.Condition,
                viewModel.CorrectAnswer,
                viewModel.IncorrectAnswers
                );

            return this.RedirectToAction("Submission", new { id = submission.Id });
        }
    }
}