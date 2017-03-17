using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Category> categoryRepository;

        public QuestionService(IRepository<Question> questionRepository, IRepository<Category> categoryRepository)
        {
            Guard.WhenArgument(questionRepository, "questionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(categoryRepository, "categoryRepository cannot be null").IsNull().Throw();

            this.questionRepository = questionRepository;
            this.categoryRepository = categoryRepository;
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
    }
}
