using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Models;

namespace Leaf.Web.Areas.Noit.Controllers
{
    public class FullTestController : Controller
    {
        private readonly IFullGameService fullGameService;
        private readonly IAuthenticationProvider authenticationProvider;

        public FullTestController(IFullGameService fullGameService, IAuthenticationProvider authenticationProvider)
        {
            Guard.WhenArgument(fullGameService, "FullGameService cannot be null").IsNull().Throw();
            Guard.WhenArgument(authenticationProvider, "AuthenticationProvider cannot be null").IsNull().Throw();

            this.fullGameService = fullGameService;
            this.authenticationProvider = authenticationProvider;
        }

        // GET: Noit/FullTest
        public ActionResult Index()
        {
            //TODO: Show begin or continue button
            //TODO: List previous tests with their results

            var userId = this.authenticationProvider.CurrentUserId;
            var hasUnfinishedTest = this.fullGameService.HasUnfinishedTest(userId);

            //Return test result
            return View("FullTest", hasUnfinishedTest);
        }

        public ActionResult StartTest()
        {
            var userId = this.authenticationProvider.CurrentUserId;
            var userTest = this.fullGameService.GetUserTest(userId);

            //Return test result
            return RedirectToAction("Test", "FullTest", new { id = userTest.Id });
        }

        public ActionResult ReceiveAnswer(int questionId, int answerId)
        {
            var userId = this.authenticationProvider.CurrentUserId;
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
                var nextQuestionViewModel = new NextQuestionViewModel(nextQuestion.Id, nextQuestion.Condition, nextQuestion.Answers);
                return View("Test", nextQuestionViewModel);
            }

            var test = this.fullGameService.GetTestById(id);

            return View("FinishedTest", test);
        }
    }
}