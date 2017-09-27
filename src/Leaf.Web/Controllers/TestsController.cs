using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Services.Helpers;
using Leaf.Web.Models.Tests;

namespace Leaf.Web.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly ITestService testService;
        private readonly IHelperFactory helperFactory;

        public TestsController(ITestService testService, IHelperFactory helperFactory)
        {
            Guard.WhenArgument(testService, "TestService cannot be null").IsNull().Throw();
            Guard.WhenArgument(helperFactory, "HelperFactory cannot be null").IsNull().Throw();

            this.testService = testService;
            this.helperFactory = helperFactory;
        }

        // GET: Noit/FullTest
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Test(TestViewModel viewModel)
        {
            var userIsOwner = this.testService.UserIsOwner(viewModel.TestId);

            //TODO Redirect to unauthorized page (create one first)
            if (!userIsOwner)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var test = this.testService.GetTestById(viewModel.TestId);
            var testDetailsViewModel = new TestDetailsViewModel(test.CorrectCount);

            return View("FinishedTest", testDetailsViewModel);
        }

        //TODO? Should be POST? A test is created once, if it isn't finished it's returned
        [HttpGet]
        public ActionResult New(TestType type)
        {
            //Create a new test or get last unfinished one
            //Rename to getNewTest
            var test = this.testService.CreateTest(type);

            //TODO pass start time
            return View("New", new NewTestViewModel(test.Id, test.Questions));
        }

        //TODO should be PUT? Browsers can't create PUT. Could be done with ajax, but shouldn't bother...
        [HttpPost]
        public RedirectToRouteResult New(NewTestViewModel viewModel)
        {
            //Validate viewModel

            //End test
            var finishedTestInfo = this.helperFactory.CreateFinishedTest(viewModel.TestId);

            foreach (var question in viewModel.Questions)
            {
                finishedTestInfo.AnsweredQuestions.Add(this.helperFactory.CreateAnsweredQuestion(question.QuestionId, question.SelectedAnswerId));
            }

            var test = this.testService.EndTest(finishedTestInfo);

            return this.RedirectToAction("Test", new TestViewModel(test.Id));
        }
    }
}