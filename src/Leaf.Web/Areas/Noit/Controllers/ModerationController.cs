using System.Linq;
using System.Web.Mvc;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Models;
using PagedList;

namespace Leaf.Web.Areas.Noit.Controllers
{
    public class ModerationController : Controller
    {
        private readonly IModerationService moderationService;
        private readonly IQuestionService questionService;
        private readonly IViewModelFactory viewModelFactory;

        public ModerationController(IModerationService moderationService,
            IQuestionService questionService,
            IViewModelFactory viewModelFactory)
        {
            this.moderationService = moderationService;
            this.questionService = questionService;
            this.viewModelFactory = viewModelFactory;
        }

        // GET: Noit/Moderation
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

        public ActionResult Question(int id)
        {
            var question = this.questionService.GetById(id);

            return View(question);
        }
    }
}