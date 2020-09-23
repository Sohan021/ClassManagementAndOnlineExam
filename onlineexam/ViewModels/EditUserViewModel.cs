using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onlineexam.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Identity { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Image { get; set; }
        public int UserIdentityId { get; set; }
        public IList<string> Roles { get; set; }
    }
}
