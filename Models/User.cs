using System.ComponentModel.DataAnnotations;

namespace Backend_Web.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Emaill wrong !!!")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string? Avatar { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
