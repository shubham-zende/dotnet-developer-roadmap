using Employee.Domain.Entities;
using Employee.Infrastructure.Data;
using Employee.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetActionResult()
        {
            try
            {
                var employees = _employeeDbContext.Employees.ToList();
                if (employees == null || employees.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [Route("GetEmployeeById/{id}")]
        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeDbContext.Employees.ToList();
                employee = employee.Where(e => e.EmployeeId == id).ToList();
                if(employee == null || employee.Count == 0)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(
            [FromBody] Domain.Entities.Employee employee
            )
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _employeeDbContext.Add(employee);
                _employeeDbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, employee);
            }
            catch ( Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(
            int id,
            [FromBody] Domain.Entities.Employee employee
            )
        {
            try
            {
                var emp = _employeeDbContext.Employees.Find(id);
                if (emp == null)
                {
                    return NotFound("Employee Not Found!!");
                }
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.EmployeeAddress = employee.EmployeeAddress;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
                emp.Salary = employee.Salary;
                emp.JoiningDate = employee.JoiningDate;
                _employeeDbContext.SaveChanges();
                return Ok(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _employeeDbContext.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound("Employee Not Found!!");
                }
                _employeeDbContext.Employees.Remove(employee);
                _employeeDbContext.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent,"Employee Deleted Successfully!!");
            }
            catch ( Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                throw;
            }
        }
    }
}
