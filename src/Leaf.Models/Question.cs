namespace Leaf.Models
{
    public class Question
    {
        public int Id { get; set; }

        //[StringLenght( 100, MinimumLength = 10)]
        public string Condition { get; set; }

        public string CorrectAnswer { get; set; }

        public string FirstIncorrect { get; set; }

        public string SecondIncorrect { get; set; }

        public string ThirdIncorrect { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        //statistics for every question
        public int? CorrectsCount { get; set; }

        public int? IncorrectsCount { get; set; }
    }
}
