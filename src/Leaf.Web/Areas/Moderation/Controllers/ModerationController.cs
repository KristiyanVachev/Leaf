using System.Linq;
using System.Web.Mvc;
using Leaf.Commom;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Utilities.Contracts;
using Leaf.Web.Areas.Moderation.Models;
using Leaf.Web.Models;
using PagedList;

namespace Leaf.Web.Areas.Moderation.Controllers
{
    [Authorize(Roles = Constants.Moderator)]
    public class ModerationController : Controller
    {
        private readonly IModerationService moderationService;
        private readonly IQuestionUtility questionService;
        private readonly IViewModelFactory viewModelFactory;

        public ModerationController(IModerationService moderationService,
            IQuestionUtility questionService,
            IViewModelFactory viewModelFactory)
        {
            this.moderationService = moderationService;
            this.questionService = questionService;
            this.viewModelFactory = viewModelFactory;
        }

        // GET: Moderation/Moderation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submissions(int count = 2, int page = 1)
        {
            var submissions = this.moderationService.GetPendingSubmissions()
                .Select(x => this.viewModelFactory.CreateShortSubmission(x.Id, x.Condition, x.Sender.UserName, x.SentOn.Value));

            var model = submissions.ToPagedList(page, count);

            return View(model);
        }

        public ActionResult Submission(int id)
        {
            var submission = this.moderationService.GetSubmissionById(id);

            return View(submission);
        }

        public RedirectToRouteResult Approve(int submissionId)
        {
            var question = this.moderationService.Approve(submissionId);

            return this.RedirectToAction("Question", new { id = question.Id });
        }

        [HttpGet]
        public ActionResult Reject(int submissionId)
        {
            var viewModel = new RejectViewModel(submissionId);

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public RedirectToRouteResult Reject(RejectViewModel viewModel)
        {
            this.moderationService.Reject(viewModel.Id, viewModel.Message);

            return this.RedirectToAction("Submission", new { id = viewModel.Id });
        }

        public ActionResult Question(int id)
        {
            var question = this.questionService.GetById(id);

            return View(question);
        }
    }
}