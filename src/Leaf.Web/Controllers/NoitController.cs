using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Models;
using Leaf.Services.Contracts;
using Microsoft.Ajax.Utilities;

namespace Leaf.Web.Controllers
{
    public class NoitController : Controller
    {
        private readonly IFullGameService fullGameService;
        private IEnumerable<Question> questions = new List<Question>();

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
        public ActionResult FullTest(string answer)
        {
            this.questions = Session["Questions"] as List<Question>;

            if (this.questions == null || !this.questions.Any())
            {
                this.questions = this.fullGameService.GetQuestions();
                Session["Questions"] = this.questions;
            }

            if (!answer.IsNullOrWhiteSpace())
            {
                //Return next question
                return View(questions.LastOrDefault());
            }

            //Return first question
            return View(questions.FirstOrDefault());
        }

        //Something to be called with AJAX and containing the given answer and preferbly the question ID,
        //Then it would pass the same partial view with the next question

    }
}