using ADO_APP_Practice.Models;

namespace ADO_APP_Practice.Data
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee? GetEmployeeById(int id);
        string AddEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        string DeleteEmployee(int id);
    }
}
