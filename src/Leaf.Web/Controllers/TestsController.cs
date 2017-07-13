using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Web.Models.Tests;

namespace Leaf.Web.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly ITestsService testsService;

        public TestsController(ITestsService testsService)
        {
            Guard.WhenArgument(testsService, "FullGameService cannot be null").IsNull().Throw();

            this.testsService = testsService;
        }

        // GET: Noit/FullTest
        public ActionResult Index()
        {
            //TODO: List previous tests with their results

            var hasUnfinishedTest = this.testsService.HasUnfinishedTest(TestType.Test);

            //Return test result
            return View("FullTest", hasUnfinishedTest);
        }

        public ActionResult Practice()
        {
            var hasUnfinishedPractice = this.testsService.HasUnfinishedTest(TestType.Practice);

            return View("Practice", hasUnfinishedPractice);
        }

        public ActionResult GetUserPractice()
        {
            var userTest = this.testsService.HasUnfinishedTest(TestType.Practice)
                ? this.testsService.ContinueTest(TestType.Practice)
                : this.testsService.CreateTest(TestType.Practice);

            //Return test result
            var testViewModel = new TestViewModel(userTest.Id);
            return RedirectToAction("Test", "Tests", testViewModel);
        }

        public ActionResult GetUserTest()
        {
            var hasUnfinishedTest = this.testsService.HasUnfinishedTest(TestType.Test);

            var userTest = hasUnfinishedTest 
                ? this.testsService.ContinueTest(TestType.Test) 
                : this.testsService.CreateTest(TestType.Test);

            //Return test result
            var testViewModel = new TestViewModel(userTest.Id);
            return RedirectToAction("Test", "Tests", testViewModel);
        }

        public ActionResult ReceiveAnswer(int testId, int questionId, int answerId)
        {
            var userIsOwner = this.testsService.UserIsOwner(testId);

            if (!userIsOwner)
            {
                return RedirectToAction("NotFound", "Error");
            }

            //Send answer
            this.testsService.SendAnswer(testId, questionId, answerId);

            //Return test result
            var testViewModel = new TestViewModel(testId);
            return RedirectToAction("Test", "Tests", testViewModel);
        }

        public ActionResult Test(TestViewModel viewModel)
        {
            var userIsOwner = this.testsService.UserIsOwner(viewModel.TestId);

            //TODO Redirect to unauthorized page (create one first)
            if (!userIsOwner)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var nextQuestion = this.testsService.GetNextQuestion(viewModel.TestId);

            if (nextQuestion != null)
            {
                var nextQuestionViewModel = new NextQuestionViewModel(viewModel.TestId,
                    nextQuestion.Id,
                    nextQuestion.Condition,
                    nextQuestion.Answers);

                return View("Test", nextQuestionViewModel);
            }

            this.testsService.EndTest(viewModel.TestId);

            var test = this.testsService.GetTestById(viewModel.TestId);
            var testDetailsViewModel = new TestDetailsViewModel(test.CorrectCount);

            return View("FinishedTest", testDetailsViewModel);
        }
    }
}