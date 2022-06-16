using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public bool? IsActive { get; set; }

        //[Required]
        //public string Password { get set; }
        //[Compare(Password,ErrorMessage ="Please use the same password")]
        //public string ConfirmPassword { get set; }
    }

}
