using Leaf.Models;
using NUnit.Framework;

namespace Leaf.Tests.Models.CategoryTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            //Arrange && Act
            var category = new Category();

            //Assert
            Assert.IsNotNull(category);
        }
    }
}
