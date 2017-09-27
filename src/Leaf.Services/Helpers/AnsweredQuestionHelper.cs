namespace Leaf.Services.Helpers
{
    public class AnsweredQuestionHelper
    {
        public AnsweredQuestionHelper(int questionId, int answerId)
        {
            this.QuestionId = questionId;
            this.AnswerId = answerId;
        }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }
    }
}
