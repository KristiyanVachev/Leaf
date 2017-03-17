using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class TestService : ITestService
    {
        private readonly IQuestionService questionService;
        private readonly IRepository<Test> testRepository;
        private readonly ITestFactory testFactory;
        private readonly IUnitOfWork unitOfWork;

        public TestService(IQuestionService questionService,
            IRepository<Test> testRepository,
            ITestFactory testFactory,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(questionService, "questionService cannot be null").IsNull().Throw();
            Guard.WhenArgument(testRepository, "testRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(testFactory, "testFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.questionService = questionService;
            this.testRepository = testRepository;
            this.testFactory = testFactory;
            this.unitOfWork = unitOfWork;
        }

        public Test CreateTest(string userId)
        {
            var questions = this.questionService.GetQuestions();

            var test = this.testFactory.CreateTest(userId, questions);

            this.testRepository.Add(test);
            this.unitOfWork.Commit();

            return test;
        }

        public Test GetLastTestByUserId(string userId)
        {
            return this.testRepository.Entities.LastOrDefault(x => x.UserId == userId);
        }

        public Test GetTestById(int testId)
        {
            return this.testRepository.GetById(testId);
        }

        public bool IsNullOrFinished(Test test)
        {
            return test == null || test.IsFinished;
        }
    }
}
