using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Commom;
using Leaf.Services.Contracts;
using Leaf.Web.Models;
using Leaf.Web.Models.Submit;

namespace Leaf.Web.Controllers
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

        [HttpGet]
        public ActionResult New()
        {
            var categories = this.submitService.GetCategories();

            var viewModel = this.viewModelFactory.CreateNewSubmitViewModel(categories);

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult New(NewSubmitViewModel viewModel)
        {
            var userId = authenticationProvider.CurrentUserId;

            var submission = this.submitService.CreateSubmission(userId,
                viewModel.CategoryId,
                viewModel.Condition,
                viewModel.CorrectAnswer,
                viewModel.IncorrectAnswers
            );

            return this.RedirectToAction("Submission", new { id = submission.Id });
        }

        public ActionResult Submission(int id)
        {
            var submission = this.submitService.GetSubmissionById(id);

            //TODO change info
            var viewModel = this.viewModelFactory.CreateSubmissionViewModel(submission.CategoryId.ToString(), submission.Condition,
                submission.CorrectAnswer, submission.IncorrectAnswers.Select(x => x.Content));

            return this.View(viewModel);
        }
    }
}