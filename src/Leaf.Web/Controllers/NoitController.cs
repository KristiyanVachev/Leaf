﻿using System.Web.Mvc;
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

        public ActionResult FullTest()
        {
            //TODO: Show begin or continue button
            //TODO: List previous tests with their results

            var userId = this.User.Identity.GetUserId();
            var hasUnfinishedTest = this.fullGameService.HasUnfinishedTest(userId);

            //Return test result
            return View(hasUnfinishedTest);
        }

        public ActionResult StartTest()
        {
            var userId = this.User.Identity.GetUserId();
            var userTest = this.fullGameService.GetUserTest(userId);

            //Return test result
            return RedirectToAction("Test", "Noit", new { testId = userTest.Id });
        }

        public ActionResult ReceiveAnswer(int questionId, int answerId)
        {
            var userId = this.User.Identity.GetUserId();
            var userTest = this.fullGameService.GetUserTest(userId);

            //Send answer
            this.fullGameService.SendAnswer(userTest.Id, questionId, answerId);

            //Return test result
            return RedirectToAction("Test", "Noit", new { testId = userTest.Id });
        }

        public ActionResult Test(int testId)
        {
            var nextQuestion = this.fullGameService.GetNextQuestion(testId);

            if (nextQuestion != null)
            //if (!test.IsFinished)
            {
                return View("Test", nextQuestion);
            }

            nextQuestion = new Question
            {
                Condition = "Finished"
            };

            return View("Test", nextQuestion);
        }
    }
}