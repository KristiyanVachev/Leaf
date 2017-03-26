using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.AnsweredQuestionsTests
{
    [TestFixture]
    public class ConstructorTests
    {
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            //Arrange && Act
            var answeredQuestions = new AnsweredQuestion();

            //Assert
            Assert.IsNotNull(answeredQuestions);
        }

        [TestCase(0, 0, 0)]
        [TestCase(3123, 3213, 3121)]
        public void TestConstructor_PassValidParameters_ShouldInitalizeCorrectly(int testId, int questionId, int answerId)
        {
            //Arrange && Act
            var answeredQuestions = new AnsweredQuestion(testId, questionId, answerId);

            //Assert
            Assert.IsNotNull(answeredQuestions);
        }
    }
}
