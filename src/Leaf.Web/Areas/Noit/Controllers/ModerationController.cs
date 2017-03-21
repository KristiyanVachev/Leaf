using System.Web.Mvc;
using Leaf.Services.Contracts;

namespace Leaf.Web.Areas.Noit.Controllers
{
    public class ModerationController : Controller
    {
        private IModerationService moderationService;

        public ModerationController(IModerationService moderationService)
        {
            this.moderationService = moderationService;
        }

        // GET: Noit/Moderation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submissions()
        {
            var submissions = this.moderationService.GetSubmissions();

            return View(submissions);
        }
    }
}