﻿using System.Collections.Generic;
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

        public Submission GetSubmissionById(int id)
        {
            return this.submissionRepository.GetById(id);
        }

        public void Approve(int id)
        {
            //Convert the submission to question
        }
    }
}
