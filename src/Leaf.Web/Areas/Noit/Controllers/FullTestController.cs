using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Models;
using Leaf.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace Leaf.Web.Areas.Noit.Controllers
{
    public class FullTestController : Controller
    {
        private readonly IFullGameService fullGameService;

        public FullTestController(IFullGameService fullGameService)
        {
            Guard.WhenArgument(fullGameService, "FullGameService cannot be null").IsNull().Throw();

            this.fullGameService = fullGameService;
        }

        // GET: Noit/FullTest
        public ActionResult Index()
        {
            //TODO: Show begin or continue button
            //TODO: List previous tests with their results

            var userId = this.User.Identity.GetUserId();
            var hasUnfinishedTest = this.fullGameService.HasUnfinishedTest(userId);

            //Return test result
            return View("FullTest", hasUnfinishedTest);
        }

        public ActionResult StartTest()
        {
            var userId = this.User.Identity.GetUserId();
            var userTest = this.fullGameService.GetUserTest(userId);

            //Return test result
            return RedirectToAction("Test", "FullTest", new { id = userTest.Id });
        }

        public ActionResult ReceiveAnswer(int questionId, int answerId)
        {
            var userId = this.User.Identity.GetUserId();
            var userTest = this.fullGameService.GetUserTest(userId);

            //Send answer
            this.fullGameService.SendAnswer(userTest.Id, questionId, answerId);

            //Return test result
            return RedirectToAction("Test", "FullTest", new { id = userTest.Id });
        }

        public ActionResult Test(int id)
        {
            var nextQuestion = this.fullGameService.GetNextQuestion(id);

            if (nextQuestion != null)
            //if (!test.IsFinished)
            {
                return View("Test", nextQuestion);
            }

            var test = this.fullGameService.GetTestById(id);

            return View("FinishedTest", test);
        }
    }
}