using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bytes2you.Validation;
using Leaf.Commom;
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
        private IDateTimeProvider dateTimeProvider;
        private IUnitOfWork unitOfWork;

        public SubmitService(ISubmitFactory submitFactory,
             IRepository<Submission> submissionRepository,
             IRepository<SubmissionAnswer> submissionAnswerRepository,
             IRepository<Category> categoryRepository,
             IDateTimeProvider dateTimeProvider,
             IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(submitFactory, "submitFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(submissionRepository, "submissionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(submissionAnswerRepository, "submissionAnswerRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(categoryRepository, "categoryRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.submitFactory = submitFactory;
            this.submissionRepository = submissionRepository;
            this.submissionAnswerRepository = submissionAnswerRepository;
            this.categoryRepository = categoryRepository;
            this.dateTimeProvider = dateTimeProvider;
            this.unitOfWork = unitOfWork;
        }

        public Submission CreateSubmission(string userId, string category, string condition, string correctAnswer, string[] incorrectAnswers)
        {
            var currentTime = dateTimeProvider.GetCurrenTime();
            var newSubmission = this.submitFactory.CreateSubmission(userId, category, condition, correctAnswer, currentTime);

            //I don't like how I put the answers after the submission is created. 
            //I tried creating a collection of answers first, and then sending them in the constructor. 
            //But that resulted in the answers being created in the database with correct submissionId, but when
            //retrieving the submission, the answers are not in the collection
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
