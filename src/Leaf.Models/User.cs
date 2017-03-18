using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Models
{
    public class User : IdentityUser
    {
        private ICollection<Test> tests;

        public User()
        {
            this.tests = new HashSet<Test>();
        }

        public int Points { get; set; }

        public int Level { get; set; }

        public bool IsLastTestFinished { get; set; }

        public virtual ICollection<Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }
    }
}
