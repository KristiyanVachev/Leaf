using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.CategoryStatisticTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(2)]
        [TestCase(423)]
        public void Id_ShouldSetCorrectly(int value)
        {
            //Arrange
            var categoryStatistic = new CategoryStatistic();

            //Act
            categoryStatistic.Id = value;

            //Assert
            Assert.AreEqual(value, categoryStatistic.Id);
        }

        [TestCase(2)]
        [TestCase(4421)]
        public void Correct_ShouldSetCorrectly(int value)
        {
            //Arrange
            var categoryStatistic = new CategoryStatistic();

            //Act
            categoryStatistic.Correct = value;

            //Assert
            Assert.AreEqual(value, categoryStatistic.Correct);
        }

        [TestCase(2)]
        [TestCase(4421)]
        public void Incorrect_ShouldSetCorrectly(int value)
        {
            //Arrange
            var categoryStatistic = new CategoryStatistic();

            //Act
            categoryStatistic.Incorrect = value;

            //Assert
            Assert.AreEqual(value, categoryStatistic.Incorrect);
        }

        [TestCase("adsadd32-5303ed")]
        [TestCase("2145332-5322535")]
        public void UserId_ShouldSetCorrectly(string value)
        {
            //Arrange
            var categoryStatistic = new CategoryStatistic();

            //Act
            categoryStatistic.UserId = value;

            //Assert
            Assert.AreEqual(value, categoryStatistic.UserId);
        }

        [Test]
        public void Users_ShouldSetCorrectly()
        {
            //Arrange
            var fakeUser = new User();
            var categoryStatistic = new CategoryStatistic();

            //Act
            categoryStatistic.User = fakeUser;

            //Assert
            Assert.AreSame(fakeUser, categoryStatistic.User);
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
    }
}
