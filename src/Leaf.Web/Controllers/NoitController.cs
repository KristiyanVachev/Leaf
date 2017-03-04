using System.Web.Mvc;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;

namespace Leaf.Web.Controllers
{
    public class NoitController : Controller
    {
        private readonly IFullGameService fullGameService;

        public NoitController(IFullGameService fullGameService)
        {
            //TODO guard

            this.fullGameService = fullGameService;
        }

        // GET: Noit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Training()
        {
            return View();
        }

        public ActionResult FullTest()
        {
            //get userId
            //create a fullTest
            //collect all questions

            var question = this.fullGameService.GetQuestions();

            return View(question);
        }
    }
}