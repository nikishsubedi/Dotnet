using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class UserModel
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password didnot match")]
        public string ConfirmPassword { get; set; }
    }
}
