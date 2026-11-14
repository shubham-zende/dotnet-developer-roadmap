using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee name is required")]
        public string FirstName { get; set; } = null!;
        
        [Required(ErrorMessage = "Employee name is required")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Employee address is required")]
        public string EmployeeAddress { get; set; } = null!;

        [Required(ErrorMessage = "Employee email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        public string? Department { get; set; }

        public decimal? Salary { get; set; }

        [Required(ErrorMessage = "Employee joining date is required")]
        public DateOnly? JoiningDate { get; set; }
    }
}
