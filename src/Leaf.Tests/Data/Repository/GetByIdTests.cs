using System.Data.Entity;
using Leaf.Data.Contracts;
using Leaf.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;
using Leaf.Data;

namespace Leaf.Tests.Data.Repository
{
    [TestFixture]
    public class GetByIdTests
    {
        [TestCase(1)]
        [TestCase(42)]
        public void GetById_ShouldCallDbContextSetFind(int id)
        {
            // Arrange
            var mockedSet = new Mock<DbSet<FakeRepositoryType>>();

            var mockedDbContext = new Mock<ILeafDbContext>();
            mockedDbContext.Setup(x => x.Set<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            // Act
            repository.GetById(id);

            // Assert
            mockedSet.Verify(x => x.Find(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(155)]
        public void TestGetById_ShouldReturnCorrectly(int id)
        {
            // Arrange
            var mockedResult = new Mock<FakeRepositoryType>();

            var mockedSet = new Mock<DbSet<FakeRepositoryType>>();
            mockedSet.Setup(s => s.Find(It.IsAny<object>())).Returns(mockedResult.Object);

            var mockedDbContext = new Mock<ILeafDbContext>();
            mockedDbContext.Setup(x => x.Set<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            // Act
            var result = repository.GetById(id);

            // Assert
            Assert.AreSame(mockedResult.Object, result);
        }
    }
}
