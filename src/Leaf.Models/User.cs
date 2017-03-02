using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Models
{
    public class User : IdentityUser
    {
        private ICollection<FullTest> quizes;

        public User()
        {
            this.quizes = new HashSet<FullTest>();
        }

        public virtual ICollection<FullTest> Quizes
        {
            get
            {
                return this.quizes;
            }
            set
            {
                this.quizes = value;
            }
        }

        public int Points { get; set; }

        public int Level { get; set; }

        public ICollection<Category> CategoryExp { get; set; }
    }
}
