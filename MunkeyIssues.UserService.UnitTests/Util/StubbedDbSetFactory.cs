using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FakeItEasy;

namespace MunkeyIssues.UserService.UnitTests.Util
{
    public class StubbedDbSetFactory
    {
        /// <summary>
        /// Creates an empty stubbed DbSet
        /// </summary>
        /// <typeparam name="TEntity">The type to create a DbSet for</typeparam>
        /// <returns>An empty stubbed DbSet</returns>
        public static DbSet<TEntity> Create<TEntity>() where TEntity : class
        {
            var emptyList = new List<TEntity>();
            return Create(emptyList);
        }

        /// <summary>
        /// Creates a stubbed DbSet that only contains the specified entity
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to create a DbSet for</typeparam>
        /// <param name="entity">The entity the DbSet should contain</param>
        /// <returns>A stubbed DbSet that only contains the specified entity</returns>
        public static DbSet<TEntity> Create<TEntity>(TEntity entity) where TEntity : class
        {
            var testData = new List<TEntity> {entity};
            return Create(testData);
        }

        /// <summary>
        /// Creates a stubbed DbSet that only contains the specified entities
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to create a DbSet for</typeparam>
        /// <param name="entities">List of entities that the DbSet should contain</param>
        /// <returns>A stubbed DbSet that only contains the specified entity</returns>
        public static DbSet<TEntity> Create<TEntity>(List<TEntity> entities) where TEntity : class
        {
            var data = entities.AsQueryable();
            IQueryable<TEntity> stub = A.Fake<DbSet<TEntity>>(builder => builder.Implements(typeof(IQueryable<TEntity>)));

            A.CallTo(() => stub.Provider).Returns(data.Provider);
            A.CallTo(() => stub.Expression).Returns(data.Expression);
            A.CallTo(() => stub.ElementType).Returns(data.ElementType);
            A.CallTo(() => stub.GetEnumerator()).Returns(data.GetEnumerator());

            return stub as DbSet<TEntity>;
        }
    }
}
