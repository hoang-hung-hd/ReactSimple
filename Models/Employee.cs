using System.ComponentModel.DataAnnotations;

namespace Backend_Web.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }


        public string? EmployeeAvatar { get; set; }
    }
}
