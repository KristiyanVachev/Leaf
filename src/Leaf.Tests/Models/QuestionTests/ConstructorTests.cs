using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.QuestionTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            //Arrange && Act
            var question = new Question();

            //Assert
            Assert.IsNotNull(question);
        }

        [TestCase("13423")]
        [TestCase("1wdwr3eo3rd")]
        public void TestConstructor_PassValidParameters_ShouldInitalizeCorrectly(string condition)
        {
            //Arrange & Act
            var categoryStatistic = new Question(condition);

            //Assert
            Assert.IsNotNull(categoryStatistic);
        }
    }
}
