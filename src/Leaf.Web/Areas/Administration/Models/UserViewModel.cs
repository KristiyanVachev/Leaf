using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Leaf.Web.Areas.Administration.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            
        }

        public UserViewModel(string userId, string userName, bool isModerator, bool isAdmin)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.IsModerator = isModerator;
            this.IsAdmin = isAdmin;
        }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public bool IsModerator { get; set; }

        public bool IsAdmin { get; set; }
    }
}