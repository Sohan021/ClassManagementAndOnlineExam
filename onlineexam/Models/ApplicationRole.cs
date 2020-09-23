using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace onlineexam.Models
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
