using System.Data.Entity;
using Leaf.Data.Contracts;
using Leaf.Data.Migrations;
using Leaf.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Data
{
    public class LeafDbContext : IdentityDbContext<User>, ILeafDbContext
    {
        public LeafDbContext() : this("LeafDb")
        {
        }

        public LeafDbContext(string nameOfConnectionString)
            : base(nameOfConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LeafDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<LeafDbContext>());
        }

        public virtual IDbSet<Test> Tests { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<Answer> Answers { get; set; }

        public virtual IDbSet<AnsweredQuestion> AnsweredQuestions { get; set; }

        public virtual IDbSet<Submission> Submissions { get; set; }

        public virtual IDbSet<CategoryStatistic> CategoryStatistics { get; set; }

        public static LeafDbContext Create()
        {
            return new LeafDbContext();
        }

        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public void SetAdded<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void SetDeleted<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void SetUpdated<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
