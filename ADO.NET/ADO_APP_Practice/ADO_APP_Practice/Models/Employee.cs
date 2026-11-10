using System.ComponentModel.DataAnnotations;

namespace ADO_APP_Practice.Models
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name is required!!!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!!!")]
        public string LastName { get; set; }
        public string EmployeeAddress { get; set; }
        [Required(ErrorMessage ="Email is required!!!")]
        [EmailAddress(ErrorMessage ="Email is invalid !!!")]
        public string Email {  get; set; }
        public string Department { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? JoiningDate { get; set; }
    }
}
