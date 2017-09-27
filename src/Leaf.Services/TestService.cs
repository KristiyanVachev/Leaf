using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Services.Helpers.Contracts;
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

            var test = this.testUtility.GetLastUnfinishedTest(userId, type);

            if (test != null)
            {
                return test;
            }

            //TODO get tailored questions for practice tests
            var questions = this.questionUtility.GetQuestions();

            return this.testUtility.CreateTest(userId, type, questions);
        }

        public Test EndTest(IFinishedTestHelper finishedTestHelper)
        {
            //TODO Validate answers
            if (this.testUtility.GetTestById(finishedTestHelper.TestId) == null)
            {
                return null;
            }
            
            //Populate answers for the test
            this.testUtility.AddAnswers(finishedTestHelper.TestId, finishedTestHelper.AnsweredQuestions);

            //Finish test
            this.testUtility.FinishTest(finishedTestHelper.TestId);

            //Update user category statistics
            var categoryStatistics = this.testUtility.GatherCategoryStatistics(finishedTestHelper.TestId);
            var userId = this.authenticationProvider.CurrentUserId;

            this.userUtility.AddCategoryStatistics(userId, categoryStatistics);

            return this.testUtility.GetTestById(finishedTestHelper.TestId);
        }

        public Test GetTestById(int testId)
        {
            return this.testUtility.GetTestById(testId);
        }

        public bool UserIsOwner(int testId)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var test = this.testUtility.GetTestById(testId);

            if (test == null)
            {
                return false;
            }

            return test.UserId == userId;
        }
    }
}
