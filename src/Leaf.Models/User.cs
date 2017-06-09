using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Models
{
    public class User : IdentityUser
    {
        private ICollection<Test> tests;
        private ICollection<Submission> submissions;
        private ICollection<CategoryStatistic> categoryStatistics;

        public User()
        {
            this.tests = new HashSet<Test>();
            this.submissions = new HashSet<Submission>();
            this.categoryStatistics = new HashSet<CategoryStatistic>();
        }

        public User(string userName) 
            : this()
        {
            this.UserName = userName;
        }

        public bool IsLastTestFinished { get; set; }

        public bool IsLastPracticeFinished { get; set; }

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

        public virtual ICollection<CategoryStatistic> CategoryStatistics
        {
            get { return this.categoryStatistics; }
            set { this.categoryStatistics = value; }
        }
    }
}
