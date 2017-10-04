using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Leaf.Models;
using Leaf.Web.Models.Submit;
using Leaf.Web.Models.Tests;

namespace Leaf.Web.Models
{
    public interface IViewModelFactory
    {
        NewTestViewModel CreateNewTestViewModel(int testId, IEnumerable<Question> questions);

        QuestionViewModel CreateQuestionViewModel(Question question);

        TestDetailsViewModel CreateTestDetailsViewModel(int correctCount);

        TestViewModel CreateTestViewModel(int testId);

        NewSubmitViewModel CreateNewSubmitViewModel(IEnumerable<SelectListItem> categories);

        SubmissionViewModel CreateSubmissionViewModel(string categoryName, string condtion, string correctAnswer,
            IEnumerable<string> incorrectAnswers);

        ShortSubmission CreateShortSubmission(int id, string condition, string sender, DateTime sentOn);
    }
}