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

        public static LeafDbContext Create()
        {
            return new LeafDbContext();
        }
    }
}
