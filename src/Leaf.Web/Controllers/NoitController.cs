using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Services.Noit;

namespace Leaf.Web.Controllers
{
    public class NoitController : Controller
    {
        private readonly IFullGameService fullGameService;

        public NoitController(IFullGameService fullGameService)
        {
            Guard.WhenArgument(fullGameService, "FullGameService cannot be null").IsNull().Throw();

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

            //Show start test button

            var questions = this.fullGameService.GetQuestions();

            return View(questions);

        }

        //Something to be called with AJAX and containing the given answer and preferbly the question ID,
        //Then it would pass the same partial view with the next question
        public ActionResult NextQuestion(Question question)
        {


            return PartialView("_Question", question);
        }

    }
}