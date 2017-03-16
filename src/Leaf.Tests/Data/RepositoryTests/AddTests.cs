using Leaf.Data;
using Leaf.Data.Contracts;
using Leaf.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;

namespace Leaf.Tests.Data.RepositoryTests
{
    [TestFixture]
    public class AddTests
    {
        [Test]
        public void Add_ShouldCallDbContextSetAdded()
        {
            //Arrange
            var mockedDbContext = new Mock<ILeafDbContext>();

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeRepositoryType>();

            //Act
            repository.Add(entity.Object);

            //Assert
            mockedDbContext.Verify(c => c.SetAdded(entity.Object), Times.Once);
        }
    }
}
