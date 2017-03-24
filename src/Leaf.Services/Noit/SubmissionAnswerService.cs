using System.Collections.Generic;
using Bytes2you.Validation;
using Leaf.Data.Contracts;
using Leaf.Factories;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class SubmissionAnswerService : ISubmissionAnswerService
    {
        private ISubmitFactory submitFactory;
        private IRepository<SubmissionAnswer> submissionAnswerRepository;
        private IUnitOfWork unitOfWork;

        public SubmissionAnswerService(ISubmitFactory submitFactory,
            IRepository<SubmissionAnswer> submissionAnswerRepository,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(submitFactory, "submitFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(submissionAnswerRepository, "submissionAnswerRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.submitFactory = submitFactory;
            this.submissionAnswerRepository = submissionAnswerRepository;
            this.unitOfWork = unitOfWork;
        }


        public ICollection<SubmissionAnswer> CreateSubmissionAnswers(string[] answers)
        {
            var answersList = new List<SubmissionAnswer>();

            foreach (var incorrectAnswer in answers)
            {
                var newSubmissionAnswer = this.submitFactory.CreateSubmissionAnswer(incorrectAnswer);
                answersList.Add(newSubmissionAnswer);
                submissionAnswerRepository.Add(newSubmissionAnswer);
            }

            return answersList;
        }
    }
}
