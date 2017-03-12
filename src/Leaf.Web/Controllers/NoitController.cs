using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Models;
using Leaf.Services.Contracts;
using Microsoft.AspNet.Identity;

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

        //Takes an optional object of an answered question. If not is passed then begin a new test
        public ActionResult FullTest(int questionId = -1, int answerId = -1)
        {
            var userId = this.User.Identity.GetUserId();
            var userTest = this.fullGameService.GetUserTest(userId);

            //Send answer
            if (questionId != -1)
            {
                this.fullGameService.SendAnswer(userTest.Id, questionId, answerId);
            }

            //Return test result
            return RedirectToAction("Test", "Noit", new { testId = userTest.Id });
        }

        public ActionResult Test(int testId)
        {
            var nextQuestion = this.fullGameService.GetNextQuestion(testId);

            //var test = this.fullGameService.GetUserTest(this.User.Identity.GetUserId());

            if (nextQuestion != null)
            //if (!test.IsFinished)
            {
                return View("FullTest", nextQuestion);
            }

            nextQuestion = new Question
            {
                Condition = "Finished"
            };

            return View("FullTest", nextQuestion);
        }

        //Something to be called with AJAX and containing the given answer and preferbly the question ID,
        //Then it would pass the same partial view with the next question

    }
}