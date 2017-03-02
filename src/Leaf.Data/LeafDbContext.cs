using System.Data.Entity;
using Leaf.Data.Contracts;
using Leaf.Data.Migrations;
using Leaf.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Data
{
    public class LeafDbContext : IdentityDbContext<User>, ILeafDbContext
    {
        public LeafDbContext() : base("LeafDb", throwIfV1Schema: false)
        {
            this.Database.CreateIfNotExists();
        }

        public LeafDbContext(string nameOfConnectionString)
            : base(nameOfConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LeafDbContext, Configuration>());
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<FullTest> FullTests { get; set; }

        public static LeafDbContext Create()
        {
            return new LeafDbContext();
        }
    }
}
