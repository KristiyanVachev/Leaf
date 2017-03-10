using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Models;
using Leaf.Services.Contracts;
using Microsoft.Ajax.Utilities;
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

        //private List<Question> questions; 
        //Takes an optional object of an answered question. If not is passed then begin a new test
        public ActionResult FullTest(int questionId = -1, string answer = "")
        {
            //create new test
            if (questionId == -1)
            {
                //this.service.create test
                //pass first question to view
            }

            var userId = this.User.Identity.GetUserId();
            var userTest = this.fullGameService.GetUserTest(userId);

            //Return first question
            return View(userTest.Questions.FirstOrDefault());
        }

        public void Test(int questionId = -1, string answer = "")
        {

        }

        //Something to be called with AJAX and containing the given answer and preferbly the question ID,
        //Then it would pass the same partial view with the next question

    }
}