using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface IModerationService
    {
        IEnumerable<Submission> GetSubmissions();

        Submission GetSubmissionById(int id);

        Question Approve(int id);
    }
}
