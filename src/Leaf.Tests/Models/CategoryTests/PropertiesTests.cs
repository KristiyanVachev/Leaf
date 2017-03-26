using System.Collections.Generic;
using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.CategoryTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(2)]
        [TestCase(423)]
        public void Id_ShouldSetCorrectly(int value)
        {
            //Arrange
            var category = new Category();

            //Act
            category.Id = value;

            //Assert
            Assert.AreEqual(value, category.Id);
        }

        [TestCase("Категория")]
        [TestCase("Category Name")]
        public void Name_ShouldSetCorrectly(string value)
        {
            //Arrange
            var category = new Category();

            //Act
            category.Name = value;

            //Assert
            Assert.AreEqual(value, category.Name);
        }

        [Test]
        public void Question_ShouldSetCorrectly()
        {
            //Arrange
            var fakeQuestions = new List<Question>();

            var category = new Category();

            //Act
            category.Questions = fakeQuestions;

            //Assert
            Assert.AreEqual(fakeQuestions, category.Questions);
        }

        [Test]
        public void CategoryStatistic_ShouldSetCorrectly()
        {
            //Arrange
            var fakeCategoryStatistci = new List<CategoryStatistic>();

            var category = new Category();

            //Act
            category.CategoryStatistics = fakeCategoryStatistci;

            //Assert
            Assert.AreEqual(fakeCategoryStatistci, category.CategoryStatistics);
        }
    }
}
