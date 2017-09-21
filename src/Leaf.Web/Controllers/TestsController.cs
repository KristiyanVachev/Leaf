using System.Linq;
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
        private readonly ITestService testsService;

        public TestsController(ITestService testsService)
        {
            Guard.WhenArgument(testsService, "FullGameService cannot be null").IsNull().Throw();

            this.testsService = testsService;
        }

        // GET: Noit/FullTest
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Test(TestViewModel viewModel)
        {
            var userIsOwner = this.testsService.UserIsOwner(viewModel.TestId);

            //TODO Redirect to unauthorized page (create one first)
            if (!userIsOwner)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var test = this.testsService.GetTestById(viewModel.TestId);
            var testDetailsViewModel = new TestDetailsViewModel(test.CorrectCount);

            return View("FinishedTest", testDetailsViewModel);
        }

        //TODO? Should be POST? A test is created once, if it isn't finished it's returned
        [HttpGet]
        public ActionResult New(TestType type)
        {
            //Create a new test or get last unfinished one
            var test = this.testsService.CreateTest(type);

            //TODO pass start time
            return View("New", new NewTestViewModel(test.Id, test.Questions));
        }

        //TODO should be PUT? Browsers can't create PUT. Could be done with ajax, but shouldn't bother...
        [HttpPost]
        public RedirectToRouteResult New(NewTestViewModel viewModel)
        {
            //Validate viewModel

            //End test
            var answeredQuestions = viewModel.Questions.ToDictionary(answeredQuestion => answeredQuestion.QuestionId, answeredQuestion => answeredQuestion.SelectedAnswerId);

            var test = this.testsService.EndTest(viewModel.TestId, answeredQuestions);

            return this.RedirectToAction("Test", new TestViewModel(test.Id));
        }
    }
}