using System.ComponentModel.DataAnnotations;

namespace Backend_Web.Models
{
    public class Login
    {
        /*[EmailAddress(ErrorMessage = "Email is not correct ")]
        [Required(ErrorMessage ="Email is required ")]
        public string Email { get; set; }*/

        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        public string Password { get; set; }
    }
}
