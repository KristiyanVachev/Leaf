using Leaf.Data.Contracts;
using Leaf.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;
using Leaf.Data;

namespace Leaf.Tests.Data.RepositoryTests
{
    [TestFixture]
    public class DeleteTests
    {
        [Test]
        public void Delete_ShouldCallDbContextSetDeleted()
        {
            // Arrange
            var mockedDbContext = new Mock<ILeafDbContext>();

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeRepositoryType>();

            // Act
            repository.Delete(entity.Object);

            // Assert
            mockedDbContext.Verify(c => c.SetDeleted(entity.Object), Times.Once);
        }
    }
}
