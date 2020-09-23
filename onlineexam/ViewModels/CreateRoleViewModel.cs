using System.ComponentModel.DataAnnotations;

namespace onlineexam.ViewModels
{
    public class CreateRoleViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
