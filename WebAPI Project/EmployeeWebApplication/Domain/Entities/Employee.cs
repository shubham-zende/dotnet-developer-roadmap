using System;
using System.Collections.Generic;

namespace Employee.Domain.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmployeeAddress { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Department { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? JoiningDate { get; set; }
}
