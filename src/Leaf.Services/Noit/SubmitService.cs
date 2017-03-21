using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
        private IRepository<Category> categoryRepository;
        private IUnitOfWork unitOfWork;

        public SubmitService(ISubmitFactory submitFactory,
             IRepository<Submission> submissionRepository,
             IRepository<Category> categoryRepository,
             IUnitOfWork unitOfWork)
        {
            this.submitFactory = submitFactory;
            this.submissionRepository = submissionRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateSubmission(string userId, string category, string condition, string correctAnswer)
        {
            var newSubmission = this.submitFactory.CreateSubmission(userId, category, condition, correctAnswer);

            this.submissionRepository.Add(newSubmission);
            this.unitOfWork.Commit();
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
    }
}
