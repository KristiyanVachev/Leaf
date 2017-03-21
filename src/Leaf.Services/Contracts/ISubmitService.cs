namespace Leaf.Services.Contracts
{
    public interface ISubmitService
    {
        void CreateSubmission(string userId ,string category, string condition, string correctAnswer);

    }
}
