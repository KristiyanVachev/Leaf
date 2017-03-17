using System;
using Leaf.Data;
using Leaf.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Constructor_PassDbContextNull_ShouldThrowArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork(null));
        }

        [Test]
        public void Constructor_PassDbContextCorrectly_ShouldNotThrow()
        {
            // Arrange
            var mockedDbContext = new Mock<ILeafDbContext>();

            // Act, Assert
            Assert.DoesNotThrow(() => new UnitOfWork(mockedDbContext.Object));
        }

        [Test]
        public void Constructor_PassDbContextCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedDbContext = new Mock<ILeafDbContext>();

            // Act
            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(unitOfWork);
        }
    }
}
