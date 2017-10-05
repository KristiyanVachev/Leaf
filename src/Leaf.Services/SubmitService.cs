using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Commom.Contracts;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services
{
    public class SubmitService : ISubmitService
    {
        private ISubmitFactory submitFactory;
        private IRepository<Submission> submissionRepository;
        private IRepository<Category> categoryRepository;
        private IDateTimeProvider dateTimeProvider;
        private IUnitOfWork unitOfWork;

        public SubmitService(ISubmitFactory submitFactory,
             IRepository<Submission> submissionRepository,
             IRepository<Category> categoryRepository,
             IDateTimeProvider dateTimeProvider,
             IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(submitFactory, "submitFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(submissionRepository, "submissionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(categoryRepository, "categoryRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.submitFactory = submitFactory;
            this.submissionRepository = submissionRepository;
            this.categoryRepository = categoryRepository;
            this.dateTimeProvider = dateTimeProvider;
            this.unitOfWork = unitOfWork;
        }

        public Submission CreateSubmission(string userId, int categoryId, string condition, string correctAnswer, ICollection<string> incorrectAnswers)
        {
            var currentTime = dateTimeProvider.GetCurrenTime();

            var submissionAnswers = new List<SubmissionAnswer>();
            submissionAnswers.Add(this.submitFactory.CreateSubmissionAnswer(true, correctAnswer));
            submissionAnswers.AddRange(incorrectAnswers.Select(incorrectAnswer => this.submitFactory.CreateSubmissionAnswer(false, incorrectAnswer)));

            var newSubmission = this.submitFactory.CreateSubmission(userId, categoryId, condition, submissionAnswers, currentTime);

            this.submissionRepository.Add(newSubmission);
            this.unitOfWork.Commit();

            return newSubmission;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = categoryRepository.Entities.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
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
