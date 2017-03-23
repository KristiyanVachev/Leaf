using System.Web.Mvc;
using Leaf.Services.Contracts;

namespace Leaf.Web.Areas.Noit.Controllers
{
    public class ModerationController : Controller
    {
        private IModerationService moderationService;
        private IQuestionService questionService;

        public ModerationController(IModerationService moderationService, IQuestionService questionService)
        {
            this.moderationService = moderationService;
            this.questionService = questionService;
        }

        // GET: Noit/Moderation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submissions()
        {
            var submissions = this.moderationService.GetPendingSubmissions();

            return View(submissions);
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