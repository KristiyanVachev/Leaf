using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Models.FullTest;

namespace Leaf.Web.Areas.Noit.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly IFullGameService fullGameService;

        public TestsController(IFullGameService fullGameService)
        {
            Guard.WhenArgument(fullGameService, "FullGameService cannot be null").IsNull().Throw();

            this.fullGameService = fullGameService;
        }

        // GET: Noit/FullTest
        public ActionResult Index()
        {
            //TODO: List previous tests with their results

            var hasUnfinishedTest = this.fullGameService.HasUnfinishedTest();

            //Return test result
            return View("FullTest", hasUnfinishedTest);
        }

        public ActionResult Practice()
        {
            var hasUnfinishedPractice = this.fullGameService.HasUnfinishedPractice();

            return View("Practice", hasUnfinishedPractice);
        }

        public ActionResult GetUserPractice()
        {
            var userTest = this.fullGameService.HasUnfinishedPractice() ? this.fullGameService.ContinuePractice() : this.fullGameService.CreatePractice();

            //Return test result
            var testViewModel = new TestViewModel(userTest.Id);
            return RedirectToAction("Test", "Tests", testViewModel);
        }

        public ActionResult GetUserTest()
        {
            var hasUnfinishedTest = this.fullGameService.HasUnfinishedTest();

            var userTest = hasUnfinishedTest ? this.fullGameService.ContinueTest() : this.fullGameService.CreateTest();

            //Return test result
            var testViewModel = new TestViewModel(userTest.Id);
            return RedirectToAction("Test", "Tests", testViewModel);
        }

        public ActionResult ReceiveAnswer(int testId, int questionId, int answerId)
        {
            var userIsOwner = this.fullGameService.UserIsOwner(testId);

            if (!userIsOwner)
            {
                return RedirectToAction("NotFound", "Error");
            }

            //Send answer
            this.fullGameService.SendAnswer(testId, questionId, answerId);

            //Return test result
            var testViewModel = new TestViewModel(testId);
            return RedirectToAction("Test", "Tests", testViewModel);
        }

        public ActionResult Test(TestViewModel viewModel)
        {
            var userIsOwner = this.fullGameService.UserIsOwner(viewModel.TestId);

            if (!userIsOwner)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var nextQuestion = this.fullGameService.GetNextQuestion(viewModel.TestId);

            if (nextQuestion != null)
            {
                var nextQuestionViewModel = new NextQuestionViewModel(viewModel.TestId, 
                    nextQuestion.Id,
                    nextQuestion.Condition, 
                    nextQuestion.Answers);

                return View("Test", nextQuestionViewModel);
            }
            
            this.fullGameService.EndTest(viewModel.TestId);

            var test = this.fullGameService.GetTestById(viewModel.TestId);
            var testDetailsViewModel = new TestDetailsViewModel(test.CorrectCount);

            return View("FinishedTest", testDetailsViewModel);
        }
    }
}