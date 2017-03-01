using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
