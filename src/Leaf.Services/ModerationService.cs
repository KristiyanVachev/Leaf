using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Commom.Contracts;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;
using Leaf.Services.Utilities.Contracts;

namespace Leaf.Services
{
    public class ModerationService : IModerationService
    {
        private IRepository<Submission> submissionRepository;
        private IQuestionUtility questionUtility;
        private IDateTimeProvider dateTimeProvider;
        private IAuthenticationProvider authenticationProvider;
        private IUnitOfWork unitOfWork;

        public ModerationService(IRepository<Submission> submissionRepository,
            IQuestionUtility questionUtility,
            IDateTimeProvider dateTimeProvider,
            IAuthenticationProvider authenticationProvider,
            IUnitOfWork unitOfWork
            )
        {
            Guard.WhenArgument(submissionRepository, "submissionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(questionUtility, "questionUtility cannot be null").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(authenticationProvider, "authenticationProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.submissionRepository = submissionRepository;
            this.questionUtility = questionUtility;
            this.dateTimeProvider = dateTimeProvider;
            this.authenticationProvider = authenticationProvider;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Submission> GetPendingSubmissions()
        {
            var submissions = this.submissionRepository.Entities
                .Where(x => x.State == SubmissionState.Pending)
                .ToList();

            return submissions;
        }

        public Submission GetSubmissionById(int id)
        {
            return this.submissionRepository.GetById(id);
        }

        public Question Approve(int id)
        {
            var submission = this.submissionRepository.GetById(id);

            var question =  this.questionUtility.CreateQuestion(submission);

            submission.ApprovedByName = authenticationProvider.CurrentUserName;
            submission.ApprovedOn = dateTimeProvider.GetCurrenTime();
            submission.State = SubmissionState.Approved;

            submissionRepository.Update(submission);
            this.unitOfWork.Commit();

            return question;
        }
    }
}
