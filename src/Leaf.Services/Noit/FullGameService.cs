using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class FullGameService : IFullGameService
    {
        //TODO: Extract IQuestion interface
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public FullGameService(IRepository<Question> questionRepository,
            IRepository<Category> categoryRepository, 
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(questionRepository, "queRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(categoryRepository, "categoryRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.questionRepository = questionRepository;
            this.categoryRepository = categoryRepository;
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

        public void CreateTest()
        {
            
        }
    }
}
