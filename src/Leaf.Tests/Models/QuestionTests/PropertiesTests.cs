using System.Collections.Generic;
using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.QuestionTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(2)]
        [TestCase(423)]
        public void Id_ShouldSetCorrectly(int value)
        {
            //Arrange
            var question = new Question();

            //Act
            question.Id = value;

            //Assert
            Assert.AreEqual(value, question.Id);
        }

        [TestCase("What is the purpose of this test?")]
        [TestCase("Nana-nana-na-nananana")]
        public void Condition_ShouldSetCorrectly(string value)
        {
            //Arrange
            var question = new Question();

            //Act
            question.Condition = value;

            //Assert
            Assert.AreEqual(value, question.Condition);
        }

        [TestCase(2)]
        [TestCase(423)]
        public void CategoryId_ShouldSetCorrectly(int value)
        {
            //Arrange
            var categoryStatistic = new CategoryStatistic();

            //Act
            categoryStatistic.CategoryId = value;

            //Assert
            Assert.AreEqual(value, categoryStatistic.CategoryId);
        }

        [Test]
        public void Category_ShouldSetCorrectly()
        {
            //Arrange
            var fakeCategory = new Category();
            var categoryStatistic = new CategoryStatistic();

            //Act
            categoryStatistic.Category = fakeCategory;

            //Assert
            Assert.AreSame(fakeCategory, categoryStatistic.Category);
        }

        [Test]
        public void Answers_ShouldSetCorrectly()
        {
            //Arrange
            var fakeAnswers = new List<Answer>();

            var question = new Question();

            //Act
            question.Answers = fakeAnswers;

            //Assert
            Assert.AreEqual(fakeAnswers, question.Answers);
        }

        [Test]
        public void Tests_ShouldSetCorrectly()
        {
            //Arrange
            var fakeTests = new List<Test>();

            var question = new Question();

            //Act
            question.Tests = fakeTests;

            //Assert
            Assert.AreEqual(fakeTests, question.Tests);
        }
    }
}
