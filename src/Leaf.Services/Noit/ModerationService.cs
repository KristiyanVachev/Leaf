using System.Collections.Generic;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class ModerationService : IModerationService
    {
        private IRepository<Submission> submissionRepository;
        private IQuestionService questionService;

        public ModerationService(IRepository<Submission> submissionRepository,
            IQuestionService questionService
            )
        {
            Guard.WhenArgument(submissionRepository, "submissionRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(questionService, "questionService cannot be null").IsNull().Throw();

            this.submissionRepository = submissionRepository;
            this.questionService = questionService;
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
            //Get submission
            var submission = this.submissionRepository.GetById(id);

            //Convert the submission to question

            //TODO redirect to moderation/question/{id}
            var question =  this.questionService.CreateQuestion(submission);

            return question;
            //Add approved by and date of approval to submission

        }
    }
}
