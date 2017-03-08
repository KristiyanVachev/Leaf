using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Tests = new HashSet<Test>();
        }

        public int Points { get; set; }

        public int Level { get; set; }

        public bool IsLastTestFinished { get; set; }
       
        public virtual ICollection<Test> Tests { get; set; }
    }
}
