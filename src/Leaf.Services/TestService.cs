using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;

namespace Leaf.Services
{
    public class TestService : ITestService
    {
        private readonly IQuestionService questionService;
        private readonly IRepository<Test> testRepository;
        private readonly IRepository<AnsweredQuestion> answeredQuestionRepository;
        private readonly ITestFactory testFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDateTimeProvider dateTimeProvider;

        public TestService(IQuestionService questionService,
            IRepository<Test> testRepository,
            IRepository<AnsweredQuestion> answeredQuestionRepository,
            ITestFactory testFactory,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(questionService, "questionService cannot be null").IsNull().Throw();
            Guard.WhenArgument(testRepository, "testRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(answeredQuestionRepository, "answeredQuestionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(testFactory, "testFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.questionService = questionService;
            this.testRepository = testRepository;
            this.answeredQuestionRepository = answeredQuestionRepository;
            this.testFactory = testFactory;
            this.dateTimeProvider = dateTimeProvider;
            this.unitOfWork = unitOfWork;
        }

        public Test CreateTest(string userId, TestType type, IEnumerable<Question> questions)
        {
            var currentTime = dateTimeProvider.GetCurrenTime();

            var test = this.testFactory.CreateTest(userId, questions, currentTime, type);

            this.testRepository.Add(test);
            this.unitOfWork.Commit();

            return test;
        }

        public Test GetLastTest(string userId, TestType type)
        {
            return this.testRepository.Entities
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault(x => x.Type == type);
        }

        public Test GetTestById(int testId)
        {
            return this.testRepository.GetById(testId);
        }

        public bool IsNullOrFinished(Test test)
        {
            return test == null || test.IsFinished;
        }

        public void AddAnswer(int testId, int questionId, int answerId)
        {
            var test = this.testRepository.GetById(testId);

            var newAnsweredQuestion = this.testFactory.CreateAnsweredQuestion(testId, questionId, answerId);

            test.AnsweredQuestions.Add(newAnsweredQuestion);

            this.answeredQuestionRepository.Add(newAnsweredQuestion);
            this.testRepository.Update(test);

            this.unitOfWork.Commit();
        }

        public void RemoveQuestionById(int testId, int questionId)
        {
            var test = this.testRepository.GetById(testId);

            test.Questions.Remove(test.Questions.FirstOrDefault(x => x.Id == questionId));

            this.testRepository.Update(test);
            this.unitOfWork.Commit(); ;
        }

        public bool TestIsFinished(int testId)
        {
            var test = this.testRepository.GetById(testId);

            return test.Questions.Any();
        }

        public void EndTest(int testId)
        {
            var test = this.testRepository.GetById(testId);

            var correctsCount = test.AnsweredQuestions.Count(answeredQuestion => answeredQuestion.Answer.IsCorrect);

            test.CorrectCount = correctsCount;
            test.IsFinished = true;

            this.testRepository.Update(test);
            this.unitOfWork.Commit();
        }

        public IDictionary<int, int[]> GatherTestStatistics(int testId)
        {
            var test = this.testRepository.GetById(testId);

            var stats = new Dictionary<int, int[]>();

            foreach (var answeredQuestion in test.AnsweredQuestions)
            {
                var categoryId = answeredQuestion.Question.Category.Id;
                var isCorrect = answeredQuestion.Answer.IsCorrect;

                if (!stats.ContainsKey(categoryId))
                {
                    stats[categoryId] = new int[] { 0, 0 };
                }

                if (isCorrect)
                {
                    stats[categoryId][0]++;
                }
                else
                {
                    stats[categoryId][1]++;
                }
            }

            return stats;
        }
    }
}
