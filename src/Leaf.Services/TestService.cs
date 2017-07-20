using System.Linq;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Services.Utilities.Contracts;

namespace Leaf.Services
{
    public class TestService : ITestService
    {
        private readonly ITestUtility testUtility;
        private readonly IQuestionUtility questionUtility;
        private readonly IUserUtility userUtility;
        private readonly IAuthenticationProvider authenticationProvider;

        public TestService(
            ITestUtility testUtility,
            IQuestionUtility questionUtility,
            IUserUtility userUtility,
            IAuthenticationProvider authenticationProvider)
        {
            //TODO: Extract "cannot be null" message to costant
            Guard.WhenArgument(testUtility, "testUtility cannot be null").IsNull().Throw();
            Guard.WhenArgument(questionUtility, "questionUtility cannot be null").IsNull().Throw();
            Guard.WhenArgument(userUtility, "userUtility cannot be null").IsNull().Throw();
            Guard.WhenArgument(authenticationProvider, "authenticationProvider cannot be null").IsNull().Throw();

            this.testUtility = testUtility;
            this.questionUtility = questionUtility;
            this.userUtility = userUtility;
            this.authenticationProvider = authenticationProvider;
        }

        public Test CreateTest(TestType type)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            //TODO get tailored questions for practice tests
            var questions = this.questionUtility.GetQuestions();

            return this.testUtility.CreateTest(userId, type, questions);
        }

        public Test ContinueTest(TestType type)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            return this.testUtility.GetLastTest(userId, type);
        }

        public bool HasUnfinishedTest(TestType type)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var userTest = this.testUtility.GetLastTest(userId, type);

            return !(userTest == null || userTest.IsFinished);
        }

        public Test GetTestById(int testId)
        {
            return this.testUtility.GetTestById(testId);
        }

        public void SendAnswer(int testId, int questionId, int answerId)
        {
            this.testUtility.AddAnswer(testId, questionId, answerId);

            this.testUtility.RemoveQuestionById(testId, questionId);
        }

        public Question GetNextQuestion(int testId)
        {
            var test = this.testUtility.GetTestById(testId);

            return test.Questions.FirstOrDefault();
        }

        public void EndTest(int testId)
        {
            this.testUtility.EndTest(testId);

            var testStats = this.testUtility.GatherTestStatistics(testId);

            var test = this.testUtility.GetTestById(testId);
            var userId = test.User.Id;

            this.userUtility.UpdateUserStatistics(userId, testStats);

            //TODO update statistics of answers
        }

        public bool UserIsOwner(int testId)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var test = this.testUtility.GetTestById(testId);

            //BUG throws when test id doesn't exist

            return test.UserId == userId;
        }
    }
}
