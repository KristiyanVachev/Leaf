using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;
using Leaf.Factories;

namespace Leaf.Services.Noit
{
    public class FullGameService : IFullGameService
    {
        //TODO: Extract IQuestion interface
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Test> testRepository;
        private readonly IRepository<AnsweredQuestion> answeredQuestionRepository;
        private readonly ITestFactory testFactory;
        private readonly IUnitOfWork unitOfWork;

        public FullGameService(IRepository<Question> questionRepository,
            IRepository<Category> categoryRepository,
            IRepository<Test> testRepository,
            IRepository<AnsweredQuestion> answeredQuestionRepository,
            ITestFactory testFactory,
            IUnitOfWork unitOfWork)
        {
            //TODO: Extract "cannot be null" message to costant
            Guard.WhenArgument(questionRepository, "questionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(categoryRepository, "categoryRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(testRepository, "testRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(answeredQuestionRepository, "answeredQuestionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(testFactory, "testFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.questionRepository = questionRepository;
            this.categoryRepository = categoryRepository;
            this.testRepository = testRepository;
            this.answeredQuestionRepository = answeredQuestionRepository;
            this.testFactory = testFactory;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Question> GetQuestions()
        {
            //Get all categories.
            //Get 3 questions from each category

            List<Question> questions = new List<Question>();

            //TODO get only id's
            var categories = this.categoryRepository.Entities;

            foreach (var category in categories)
            {
                //TODO: Optimization: Avoid sorting all the questions by getting all the needed question's Id's and then getting 3 random Id's
                var categoryQuestions = this.questionRepository
                    .GetAll(x => x.CategoryId == category.Id)
                    .OrderBy(x => Guid.NewGuid())
                    .Take(3);

                //TODO extract as a constant
                foreach (var categoryQuestion in categoryQuestions)
                {
                    questions.Add(categoryQuestion);
                }
            }

            return questions;
        }

        public Test CreateTest(string userId)
        {
            //var retrievedTest = this.testRepository.Entities.Where(x => x.UserId == userId).FirstOrDefault();

            //var newAQ = new AnsweredQuestion
            //{
            //    QuestionId = retrievedTest.Questions.FirstOrDefault().Id,
            //    AnswerId = retrievedTest.Questions.FirstOrDefault().Answers.FirstOrDefault().Id,
            //    TestId = retrievedTest.Id
            //};

            //this.answeredQuestionRepository.Add(newAQ);
            //this.unitOfWork.Commit();


            //Fix for the double creation. Works.
            var userTest = this.testRepository.Entities.LastOrDefault(x => x.UserId == userId);
            if (!(userTest == null || userTest.IsFinished))
            {
                return userTest;
            }

            var questions = GetQuestions();

            var test = this.testFactory.CreateTest(userId, questions);

            this.testRepository.Add(test);
            this.unitOfWork.Commit();

            return test;
        }

        public Test GetUserTest(string userId)
        {
            var userTest = this.testRepository.Entities.LastOrDefault(x => x.UserId == userId);

            if (userTest == null || userTest.IsFinished)
            {
                userTest = CreateTest(userId);
            }

            return userTest;
        }
    }
}
