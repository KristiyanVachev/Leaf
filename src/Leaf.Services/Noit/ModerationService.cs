using System.Collections.Generic;
using Leaf.Data.Contracts;
using Leaf.Models;
using Leaf.Services.Contracts;

namespace Leaf.Services.Noit
{
    public class ModerationService : IModerationService
    {
        private IRepository<Submission> submissionRepository;

        public ModerationService(IRepository<Submission> submissionRepository)
        {
            this.submissionRepository = submissionRepository;
        }

        public IEnumerable<Submission> GetSubmissions()
        {
            var submissions = this.submissionRepository.GetAll();

            return submissions;
        }
    }
}
