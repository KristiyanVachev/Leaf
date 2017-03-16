using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Leaf.Data.Contracts;
using Leaf.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;
using Leaf.Data;

namespace Leaf.Tests.Data.RepositoryTests
{
    [TestFixture]
    public class GetAllTests
    {
        private IQueryable<FakeRepositoryType> GetData()
        {
            return new List<FakeRepositoryType>
            {
               new FakeRepositoryType(),
               new FakeRepositoryType(),
               new FakeRepositoryType()
            }.AsQueryable();
        }

        [Test]
        public void GetAll_ShouldCallDbContextSet()
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<IDbSet<FakeRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILeafDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            // Act
            repository.GetAll();

            // Assert
            mockedDbContext.Verify(db => db.DbSet<FakeRepositoryType>(), Times.Once);
        }

        [Test]
        public void GetAll_WithoutExpressions_ShouldReturnCorrectly()
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<IDbSet<FakeRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILeafDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            // Act
            var result = repository.GetAll();

            // Assert
            CollectionAssert.AreEqual(data, result);
        }

        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void GetAll_WithSortingExpression_ShouldReturnCorrectly(bool firstBoolean, bool secondBooleran)
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<IDbSet<FakeRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILeafDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            Expression<Func<FakeRepositoryType, bool>> expression = (FakeRepositoryType t) => t.BooleanProperty;

            var expected = data.Where(expression);

            // Act
            var result = repository.GetAll(expression);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void GetAll_WithSortingAndOrderByExpression_ShouldReturnCorrectly(bool firstBoolean, bool secondBooleran)
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<IDbSet<FakeRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILeafDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            Expression<Func<FakeRepositoryType, bool>> sortingExpression = (FakeRepositoryType t) => t.BooleanProperty;
            Expression<Func<FakeRepositoryType, int>> orderExpression = (t) => t.GetHashCode();

            var expected = data.Where(sortingExpression)
                .OrderBy(orderExpression);

            // Act
            var result = repository.GetAll(sortingExpression, orderExpression, false);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void GetAll_WithSortingAndOrderByDescendingExpression_ShouldReturnCorrectly(bool firstBoolean, bool secondBooleran)
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<IDbSet<FakeRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILeafDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            Expression<Func<FakeRepositoryType, bool>> sortingExpression = (FakeRepositoryType t) => t.BooleanProperty;
            Expression<Func<FakeRepositoryType, int>> orderExpression = (t) => t.GetHashCode();

            var expected = data.Where(sortingExpression)
                .OrderByDescending(orderExpression);

            // Act
            var result = repository.GetAll(sortingExpression, orderExpression, true);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void GetAll_WithSortingOrderByAndSelectExpression_ShouldReturnCorrectly(bool firstBoolean, bool secondBooleran)
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<IDbSet<FakeRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ILeafDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new Repository<FakeRepositoryType>(mockedDbContext.Object);

            Expression<Func<FakeRepositoryType, bool>> sortingExpression = (FakeRepositoryType t) => t.BooleanProperty;
            Expression<Func<FakeRepositoryType, int>> orderExpression = (t) => t.GetHashCode();
            Expression<Func<FakeRepositoryType, bool>> selectExpression = (t) => t.BooleanProperty;

            var expected = data.Where(sortingExpression)
                .OrderBy(orderExpression)
                .Select(selectExpression);

            // Act
            var result = repository.GetAll(sortingExpression, orderExpression, selectExpression);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
