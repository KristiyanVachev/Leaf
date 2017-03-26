using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.CategoryStatisticTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            //Arrange && Act
            var categoryStatistic = new CategoryStatistic();

            //Assert
            Assert.IsNotNull(categoryStatistic);
        }

        [TestCase(0)]
        [TestCase(3123)]
        public void TestConstructor_PassValidParameters_ShouldInitalizeCorrectly(int categoryId)
        {
            //Arrange & Act
            var categoryStatistic = new CategoryStatistic(categoryId);

            //Assert
            Assert.IsNotNull(categoryStatistic);
        }
    }
}
