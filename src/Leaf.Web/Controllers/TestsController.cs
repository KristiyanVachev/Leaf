using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Services.Helpers;
using Leaf.Web.Models;
using Leaf.Web.Models.Tests;

namespace Leaf.Web.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly ITestService testService;
        private readonly IHelperFactory helperFactory;
        private readonly IViewModelFactory viewModelFactory;

        public TestsController(ITestService testService, IHelperFactory helperFactory, IViewModelFactory viewModelFactory)
        {
            Guard.WhenArgument(testService, "TestService cannot be null").IsNull().Throw();
            Guard.WhenArgument(helperFactory, "HelperFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(viewModelFactory, "ViewModelFactory cannot be null").IsNull().Throw();

            this.testService = testService;
            this.helperFactory = helperFactory;
            this.viewModelFactory = viewModelFactory;
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
            var testDetailsViewModel = this.viewModelFactory.CreateTestDetailsViewModel(test.CorrectCount);
            //var testDetailsViewModel = new TestDetailsViewModel(test.CorrectCount);


            return View("FinishedTest", testDetailsViewModel);
        }

        [HttpGet]
        public ActionResult New(TestType type)
        {
            var test = this.testService.NewTest(type);

            //TODO pass start time
            var newTestViewModel = this.viewModelFactory.CreateNewTestViewModel(test.Id, test.Questions);
            return View("New", newTestViewModel);
        }

        [HttpPost]
        public RedirectToRouteResult New(NewTestViewModel newTestViewModel)
        {
            //Validate viewModel

            //End test
            var finishedTestInfo = this.helperFactory.CreateFinishedTest(newTestViewModel.TestId);

            foreach (var question in newTestViewModel.Questions)
            {
                finishedTestInfo.AnsweredQuestions.Add(this.helperFactory.CreateAnsweredQuestion(question.QuestionId, question.SelectedAnswerId));
            }

            var test = this.testService.EndTest(finishedTestInfo);

            var testViewModel = this.viewModelFactory.CreateTestViewModel(test.Id);
            return this.RedirectToAction("Test", testViewModel);
        }
    }
}