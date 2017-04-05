﻿using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Services.Contracts;
using Leaf.Web.Areas.Noit.Models.FullTest;

namespace Leaf.Web.Areas.Noit.Controllers
{
    [Authorize]
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
            //TODO: List previous tests with their results

            var hasUnfinishedTest = this.fullGameService.HasUnfinishedTest();

            //Return test result
            return View("FullTest", hasUnfinishedTest);
        }

        public ActionResult GetUserTest()
        {
            var hasUnfinishedTest = this.fullGameService.HasUnfinishedTest();

            var userTest = hasUnfinishedTest ? this.fullGameService.ContinueTest() : this.fullGameService.CreateTest();

            //Return test result
            var testViewModel = new TestViewModel(userTest.Id);
            return RedirectToAction("Test", "FullTest", testViewModel);
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
            return RedirectToAction("Test", "FullTest", testViewModel);
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