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
        private IUnitOfWork unitOfWork;

        public SubmitService(ISubmitFactory submitFactory,
             IRepository<Submission> submissionRepository,
             IUnitOfWork unitOfWork)
        {
            this.submitFactory = submitFactory;
            this.submissionRepository = submissionRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateSubmission(string userId, string category, string condition, string correctAnswer)
        {
            var newSubmission = this.submitFactory.CreateSubmission(userId, category, condition, correctAnswer);

            this.submissionRepository.Add(newSubmission);
            this.unitOfWork.Commit();
        }
    }
}
