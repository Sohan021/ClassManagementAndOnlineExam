using Microsoft.AspNetCore.Http;
using onlineexam.Utilities;
using System.ComponentModel.DataAnnotations;

namespace onlineexam.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain(allowedDomain: "gmail.com",
        ErrorMessage = "Email domain must be gmail.com")]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Identity { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public string RoleId { get; set; }


        public IFormFile Image { get; set; }
    }
}
