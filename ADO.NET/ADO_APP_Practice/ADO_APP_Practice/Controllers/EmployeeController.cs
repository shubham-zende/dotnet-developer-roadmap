using ADO_APP_Practice.Data;
using ADO_APP_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ADO_APP_Practice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees); 
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            try
            {
                _employeeRepository.AddEmployee(employee);
                TempData["SuccessMessage"] = "Employee Added Successfully.";
                return RedirectToAction("Index");
            }
            catch (SqlException ex) when (
                ex.Number == 2601 || ex.Number == 2627)
            {
                ModelState.AddModelError(
                    "Email",
                    "This email address already exists.");

                return View(employee);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = _employeeRepository.GetEmployeeById(id);
            if(emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee, int id)
        {
            if(id != employee.EmployeeId)
            {
                return BadRequest();
            }
            try
            {
                var emp = _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            catch (SqlException ex) when (
                ex.Number == 2601 || ex.Number == 2627)
            {
                ModelState.AddModelError(
                    "Email",
                    "This email address already exists.");

                return View(employee);
            }
        }
        public IActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
