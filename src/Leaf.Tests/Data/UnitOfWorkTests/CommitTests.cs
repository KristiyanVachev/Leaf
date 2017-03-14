using Leaf.Data;
using Leaf.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class CommitTests
    {
        [Test]
        public void TestCommit_ShouldCallDbContextSaveChanges()
        {
            // Arrange
            var mockedDbContext = new Mock<ILeafDbContext>();

            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Act
            unitOfWork.Commit();

            // Assert
            mockedDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
