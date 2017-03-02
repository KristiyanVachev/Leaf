using Leaf.Data.Contracts;
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

        public static LeafDbContext Create()
        {
            return new LeafDbContext();
        }
    }
}
