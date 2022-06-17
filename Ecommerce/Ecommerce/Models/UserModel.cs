using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class UserModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required,Compare("Password",ErrorMessage ="Password didnot Match")]
        public string ConfirmPassword { get; set; }
    }
}
