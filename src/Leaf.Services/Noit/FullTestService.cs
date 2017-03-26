using System.Linq;
using Bytes2you.Validation;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class FullTestService : IFullGameService
    {
        private readonly ITestService testService;

        public FullTestService(ITestService testService)
        {
            //TODO: Extract "cannot be null" message to costant
            Guard.WhenArgument(testService, "testService cannot be null").IsNull().Throw();

            this.testService = testService;
        }

        public bool HasUnfinishedTest(string userId)
        {
            var userTest = this.testService.GetLastTestByUserId(userId);

            return !this.testService.IsNullOrFinished(userTest);
        }

        public Test GetUserTest(string userId)
        {
            var userTest = this.testService.GetLastTestByUserId(userId);

            if (this.testService.IsNullOrFinished(userTest))
            {
                userTest = this.testService.CreateTest(userId);
            }

            return userTest;
        }

        public Test GetTestById(int testId)
        {
            return this.testService.GetTestById(testId);
        }

        public void SendAnswer(int testId, int questionId, int answerId)
        {
            this.testService.AddAnswer(testId, questionId, answerId);

            this.testService.RemoveQuestionById(testId, questionId);
        }

        public Question GetNextQuestion(int testId)
        {
            var test = this.testService.GetTestById(testId);

            return test.Questions.FirstOrDefault();
        }

        public void EndTest(int testId)
        {
            this.testService.EndTest(testId);

            this.testService.UpdateUserCategoriesStatistics(testId);
        }
    }
}
