using System.Collections.Generic;
using Bytes2you.Validation;
using Leaf.Auth.Contracts;
using Leaf.Commom;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Models.Enums;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class ModerationService : IModerationService
    {
        private IRepository<Submission> submissionRepository;
        private IQuestionService questionService;
        private IDateTimeProvider dateTimeProvider;
        private IAuthenticationProvider authenticationProvider;
        private IUnitOfWork unitOfWork;

        public ModerationService(IRepository<Submission> submissionRepository,
            IQuestionService questionService,
            IDateTimeProvider dateTimeProvider,
            IAuthenticationProvider authenticationProvider,
            IUnitOfWork unitOfWork
            )
        {
            Guard.WhenArgument(submissionRepository, "submissionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(questionService, "questionService cannot be null").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(authenticationProvider, "authenticationProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.submissionRepository = submissionRepository;
            this.questionService = questionService;
            this.dateTimeProvider = dateTimeProvider;
            this.authenticationProvider = authenticationProvider;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Submission> GetSubmissions()
        {
            var submissions = this.submissionRepository.GetAll();

            return submissions;
        }

        public Submission GetSubmissionById(int id)
        {
            return this.submissionRepository.GetById(id);
        }

        public Question Approve(int id)
        {
            var submission = this.submissionRepository.GetById(id);

            var question =  this.questionService.CreateQuestion(submission);

            //TODO add name of moderator that has approved the question
            submission.ApprovedOn = dateTimeProvider.GetCurrenTime();
            submission.State = SubmissionState.Approved;

            submissionRepository.Update(submission);
            this.unitOfWork.Commit();

            return question;
        }
    }
}
