using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Factories;

namespace Leaf.Services.Noit
{
    public class FullTestService : IFullGameService
    {
        private readonly ITestService testService;
        private readonly IRepository<Answer> answerRepository;
        private readonly IRepository<AnsweredQuestion> answeredQuestionRepository;
        private readonly ITestFactory testFactory;
        private readonly IUnitOfWork unitOfWork;

        public FullTestService(ITestService testService,
            IRepository<Answer> answerRepository,
            IRepository<AnsweredQuestion> answeredQuestionRepository,
            ITestFactory testFactory,
            IUnitOfWork unitOfWork)
        {
            //TODO: Extract "cannot be null" message to costant
            Guard.WhenArgument(testService, "testService cannot be null").IsNull().Throw();
            Guard.WhenArgument(answerRepository, "answerRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(answeredQuestionRepository, "answeredQuestionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(testFactory, "testFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.testService = testService;
            this.answerRepository = answerRepository;
            this.answeredQuestionRepository = answeredQuestionRepository;
            this.testFactory = testFactory;
            this.unitOfWork = unitOfWork;
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
            var test = this.testService.GetTestById(testId);

            //Verify if answer is correct
            var answer = this.answerRepository.GetById(answerId);

            if (answer.IsCorrect)
            {
                test.CorrectCount++;
            }

            //Add answer
            var newAnsweredQuestion = this.testFactory.CreateAnsweredQuestion(testId, questionId, answerId);
            this.answeredQuestionRepository.Add(newAnsweredQuestion);

            //Remove the question
            test.Questions.Remove(test.Questions.FirstOrDefault(x => x.Id == questionId));

            //Finished the test if no more questions
            if (!test.Questions.Any())
            {
                test.IsFinished = true;
            }

            this.unitOfWork.Commit();

        }

        public Question GetNextQuestion(int testId)
        {
            var test = this.testService.GetTestById(testId);

            return test.Questions.FirstOrDefault();
        }
    }
}
