using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.AnsweredQuestionsTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(2)]
        [TestCase(423)]
        public void Id_ShouldSetCorrectly(int value)
        {
            //Arrange
            var answer = new AnsweredQuestion();

            //Act
            answer.Id = value;

            //Assert
            Assert.AreEqual(value, answer.Id);
        }

        [TestCase(2)]
        [TestCase(423)]
        public void TestId_ShouldSetCorrectly(int value)
        {
            //Arrange
            var answer = new AnsweredQuestion();

            //Act
            answer.TestId = value;

            //Assert
            Assert.AreEqual(value, answer.TestId);
        }

        [Test]
        public void Test_ShouldSetCorrectly()
        {
            //Arrange
            var fakeTest = new Test();
            var answer = new AnsweredQuestion();

            //Act
            answer.Test = fakeTest;

            //Assert
            Assert.AreSame(fakeTest, answer.Test);
        }

        [TestCase(2)]
        [TestCase(423)]
        public void QuestionId_ShouldSetCorrectly(int value)
        {
            //Arrange
            var answer = new AnsweredQuestion();

            //Act
            answer.QuestionId = value;

            //Assert
            Assert.AreEqual(value, answer.QuestionId);
        }

        [Test]
        public void Questions_ShouldSetCorrectly()
        {
            //Arrange
            var fakeQuestions = new Question();
            var answer = new AnsweredQuestion();

            //Act
            answer.Question = fakeQuestions;

            //Assert
            Assert.AreSame(fakeQuestions, answer.Question);
        }

        [TestCase(2)]
        [TestCase(423)]
        public void AnswerId_ShouldSetCorrectly(int value)
        {
            //Arrange
            var answer = new AnsweredQuestion();

            //Act
            answer.AnswerId = value;

            //Assert
            Assert.AreEqual(value, answer.AnswerId);
        }

        [Test]
        public void Answer_ShouldSetCorrectly()
        {
            //Arrange
            var fakeAnswer = new Answer();
            var answer = new AnsweredQuestion();

            //Act
            answer.Answer = fakeAnswer;

            //Assert
            Assert.AreSame(fakeAnswer, answer.Answer);
        }
    }
}
