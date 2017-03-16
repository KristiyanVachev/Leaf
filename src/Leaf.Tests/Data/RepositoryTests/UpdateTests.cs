using Leaf.Data;
using Leaf.Data.Contracts;
using Leaf.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Data.RepositoryTests
{
    [TestFixture]
    public class UpdateTests
    {
        [Test]
        public void Update_ShouldCallDbContextSetUpdated()
        {
            // Arrange
            var mockedDbContext = new Mock<ILeafDbContext>();

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeRepositoryType>();

            // Act
            repository.Update(entity.Object);

            // Assert
            mockedDbContext.Verify(c => c.SetUpdated(entity.Object), Times.Once);
        }
    }
}
