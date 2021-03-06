﻿using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Commom;
using Leaf.Commom.Contracts;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Helpers;
using Leaf.Services.Utilities.Contracts;

namespace Leaf.Services.Utilities
{
    public class TestUtility : ITestUtility
    {
        private readonly IRepository<Test> testRepository;
        private readonly IRepository<AnsweredQuestion> answeredQuestionRepository;
        private readonly ITestFactory testFactory;
        private readonly IHelperFactory helperFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDateTimeProvider dateTimeProvider;

        public TestUtility(IRepository<Test> testRepository,
            IRepository<AnsweredQuestion> answeredQuestionRepository,
            ITestFactory testFactory,
            IHelperFactory helperFactory,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(testRepository, "testRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(answeredQuestionRepository, "answeredQuestionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(testFactory, "testFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(helperFactory, "helperFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.testRepository = testRepository;
            this.answeredQuestionRepository = answeredQuestionRepository;
            this.testFactory = testFactory;
            this.helperFactory = helperFactory;
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

        public Test GetLastUnfinishedTest(string userId, TestType type)
        {
            return this.testRepository.Entities
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Id)
                .Where(x => x.Type == type)
                .FirstOrDefault(x => x.IsFinished == false);
        }

        public Test GetTestById(int testId)
        {
            return this.testRepository.GetById(testId);
        }

        public void AddAnswers(int testId, ICollection<Helpers.AnsweredQuestionHelper> answeredQuestions)
        {
            var test = this.testRepository.GetById(testId);

            if (test == null)
            {
                return;
            }

            foreach (var answeredQuestion in answeredQuestions)
            {
                var newAnsweredQuestion = this.testFactory.CreateAnsweredQuestion(testId, answeredQuestion.QuestionId, answeredQuestion.AnswerId);

                this.answeredQuestionRepository.Add(newAnsweredQuestion);
                test.AnsweredQuestions.Add(newAnsweredQuestion);
            }

            this.testRepository.Update(test);
            this.unitOfWork.Commit();
        }

        public void FinishTest(int testId)
        {
            var test = this.testRepository.GetById(testId);

            if (test == null)
            {
                return;
            }

            var answeredQuestions = this.answeredQuestionRepository
                .QueryObjectGraph(x => x.TestId == testId, "Answer")
                .ToList();

            var correctsCount = answeredQuestions.Count(answeredQuestion => answeredQuestion.Answer.IsCorrect);
            test.CorrectCount = correctsCount;

            test.IsFinished = true;

            this.testRepository.Update(test);
            this.unitOfWork.Commit();
        }

        public IEnumerable<CategoryStatisticHelper> GatherCategoryStatistics(int testId)
        {
            var answeredQuestions = this.answeredQuestionRepository
                .QueryObjectGraph(x => x.TestId == testId, "Answer", "Question")
                .ToList();

            var categoryStatistics = new Dictionary<int, CategoryStatisticHelper>();

            foreach (var answeredQuestion in answeredQuestions)
            {
                var categoryId = answeredQuestion.Question.CategoryId;

                if (!categoryStatistics.ContainsKey(categoryId))
                {
                    categoryStatistics[categoryId] = this.helperFactory.CreateCategoryStatisticHelper(categoryId);
                }

                if (answeredQuestion.Answer.IsCorrect)
                {
                    categoryStatistics[categoryId].AddCorrect();
                }
                else
                {
                    categoryStatistics[categoryId].AddIncorrect();
                }
            }

            return categoryStatistics.Values.ToList();
        }
    }
}
