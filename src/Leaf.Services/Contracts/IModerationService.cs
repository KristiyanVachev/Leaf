using System.Collections.Generic;
using Leaf.Models;

namespace Leaf.Services.Contracts
{
    public interface IModerationService
    {
        IEnumerable<Submission> GetPendingSubmissions();

        Submission GetSubmissionById(int id);

        Question Approve(int id);

        void Reject(int id, string message);
    }
}
