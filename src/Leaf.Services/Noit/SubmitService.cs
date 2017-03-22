using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class SubmitService : ISubmitService
    {
        private ISubmitFactory submitFactory;
        private IRepository<Submission> submissionRepository;
        private IRepository<SubmissionAnswer> submissionAnswerRepository;
        private IRepository<Category> categoryRepository;
        private IUnitOfWork unitOfWork;

        public SubmitService(ISubmitFactory submitFactory,
             IRepository<Submission> submissionRepository,
             IRepository<SubmissionAnswer> submissionAnswerRepository,
             IRepository<Category> categoryRepository,
             IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(submitFactory, "submitFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(submissionRepository, "submissionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(submissionAnswerRepository, "submissionAnswerRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(categoryRepository, "categoryRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.submitFactory = submitFactory;
            this.submissionRepository = submissionRepository;
            this.submissionAnswerRepository = submissionAnswerRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public Submission CreateSubmission(string userId, string category, string condition, string correctAnswer, string[] incorrectAnswers)
        {
            var newSubmission = this.submitFactory.CreateSubmission(userId, category, condition, correctAnswer);

            foreach (var incorrectAnswer in incorrectAnswers)
            {
                var newSubmissionAnswer = this.submitFactory.CreateSubmissionAnswer(incorrectAnswer);
                newSubmission.IncorrectAnswers.Add(newSubmissionAnswer);
                submissionAnswerRepository.Add(newSubmissionAnswer);
            }

            this.submissionRepository.Add(newSubmission);
            this.unitOfWork.Commit();

            return newSubmission;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = categoryRepository.GetAll().Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Name,
                                    Text = x.Name
                                });

            return new SelectList(categories, "Value", "Text");
        }

        public Submission GetSubmissionById(int id)
        {
            return this.submissionRepository.GetById(id);
        }
    }
}
