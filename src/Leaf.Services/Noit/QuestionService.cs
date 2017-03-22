using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IQuestionFactory questionFactory;
        private readonly IUnitOfWork unitOfWork;

        public QuestionService(IRepository<Question> questionRepository,
            IRepository<Category> categoryRepository,
            IQuestionFactory questionFactory,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(questionRepository, "questionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(categoryRepository, "categoryRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(questionFactory, "questionFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.questionRepository = questionRepository;
            this.categoryRepository = categoryRepository;
            this.questionFactory = questionFactory;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Question> GetQuestions()
        {
            var questions = new List<Question>();

            var categoryIds = this.categoryRepository.Entities.Select(x => x.Id);

            foreach (var categoryId in categoryIds)
            {
                //TODO: Optimization: Avoid sorting all the questions by getting all the needed question's Id's and then getting 3 random Id's
                var categoryQuestions = this.questionRepository
                    .GetAll(x => x.CategoryId == categoryId)
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

        public Question CreateQuestion(Submission submission)
        {
            var newQuestion = this.questionFactory.CreateQuestion(submission.Condition);

            //Category
            var category = categoryRepository.GetAll(x => x.Name == submission.Category).FirstOrDefault();
            newQuestion.Category = category;

            //Answers
            var answers = new List<Answer>();
            answers.Add(this.questionFactory.CreateAnswer(submission.CorrectAnswer, true));

            foreach (var incorrectAnswer in submission.IncorrectAnswers)
            {
                answers.Add(this.questionFactory.CreateAnswer(incorrectAnswer.Content, false));
            }

            newQuestion.Answers = answers;

            //TODO: ASK adding the answers to answerRepository?

            this.questionRepository.Add(newQuestion);
            this.unitOfWork.Commit();

            return newQuestion;
        }

        public Question GetById(int id)
        {
            return this.questionRepository.GetById(id);
        }
    }
}
