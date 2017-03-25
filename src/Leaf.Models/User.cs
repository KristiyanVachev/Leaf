using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Models
{
    public class User : IdentityUser
    {
        private ICollection<Test> tests;
        private ICollection<Submission> submissions;

        public User()
        {
            this.tests = new HashSet<Test>();
            this.submissions = new HashSet<Submission>();
        }

        public User(string userName) 
            : this()
        {
            this.UserName = userName;
        }

        public int Points { get; set; }

        public int Level { get; set; }

        public bool IsLastTestFinished { get; set; }

        public virtual ICollection<Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }

        public virtual ICollection<Submission> Submissions
        {
            get { return this.submissions; }
            set { this.submissions = value; }
        }
    }
}
