using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace onlineexam.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Identity { get; set; }

        public string Image { get; set; }

        public virtual ApplicationRole Role { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
