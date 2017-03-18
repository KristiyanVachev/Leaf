using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.AnswerTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(2)]
        [TestCase(423)]
        public void Id_ShouldSetCorrectly(int value)
        {
            //Arrange
            var answer = new Answer();

            //Act
            answer.Id = value;

            //Assert
            Assert.AreEqual(value, answer.Id);
        }

        [TestCase("What is the purpose of this test?")]
        [TestCase("Nana-nana-na-nananana")]
        public void Content_ShouldSetCorrectly(string value)
        {
            //Arrange
            var answer = new Answer();

            //Act
            answer.Content = value;

            //Assert
            Assert.AreEqual(value, answer.Content);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsCorrect_ShouldSetCorrectly(bool value)
        {
            //Arrange
            var answer = new Answer();

            //Act
            answer.IsCorrect = value;

            //Assert
            Assert.AreEqual(value, answer.IsCorrect);
        }

        [TestCase(2)]
        [TestCase(423)]
        public void QuestionId_ShouldSetCorrectly(int value)
        {
            //Arrange
            var answer = new Answer();

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
            var answer = new Answer();

            //Act
            answer.Question = fakeQuestions;

            //Assert
            Assert.AreSame(fakeQuestions, answer.Question);
        }
    }
}
