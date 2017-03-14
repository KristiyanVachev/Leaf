using System;
using Leaf.Data;
using Leaf.Data.Contracts;
using Leaf.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Data.Repository
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_PassDbContextNull_ShouldThrowArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Repository< FakeRepositoryType > (null));
        }

        [Test]
        public void Constructor_PassDbContextCorrectly_ShouldNotThrow()
        {
            // Arrange
            var mockedDbContext = new Mock<ILeafDbContext>();

            // Act & Assert
            Assert.DoesNotThrow(() => new Repository<FakeRepositoryType>(mockedDbContext.Object));
        }

        [Test]
        public void Constructor_PassDbContextCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedDbContext = new Mock<ILeafDbContext>();

            // Act
            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(repository);
        }
    }
}
