using ADO_APP_Practice.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO_APP_Practice.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBConnectionFactory dBConnectionFactory;
        public EmployeeRepository(DBConnectionFactory _dbConnectionFactory)
        {
            dBConnectionFactory = _dbConnectionFactory;
        }

        public string AddEmployee(Employee employee)
        {
            string msg = "";
            using (SqlConnection con = dBConnectionFactory.CreateConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    msg = "Employee Added Successfully.";
                }
                else
                {
                    msg = "Error!!!";
                }
            }
            return msg;
        }

        public string DeleteEmployee(int id)
        {
            string msg = "";
            using (SqlConnection con = dBConnectionFactory.CreateConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    msg = "Employee Deleted Successfully.";
                }
                else
                {
                    msg = "Error!!!!";
                }
            }
            return msg;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = dBConnectionFactory.CreateConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee model = new Employee();
                    model.EmployeeId = Convert.ToInt32(dr["EmployeeId"].ToString());
                    model.FirstName = dr["FirstName"].ToString();
                    model.LastName = dr["LastName"].ToString();
                    model.Email = dr["Email"].ToString();
                    model.Department = dr["Department"].ToString();
                    model.EmployeeAddress = dr["EmployeeAddress"].ToString();
                    model.Salary = Convert.ToDecimal(dr["Salary"].ToString());
                    model.JoiningDate = Convert.ToDateTime(dr["JoiningDate"].ToString());
                    employees.Add(model);
                }
            }
            return employees;
        }

        public Employee? GetEmployeeById(int id)
        {
            Employee model = null;
            using (SqlConnection con = dBConnectionFactory.CreateConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_GetEmployeesById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    model = new Employee();
                    model.EmployeeId = Convert.ToInt32(dr["EmployeeId"].ToString());
                    model.FirstName = dr["FirstName"].ToString();
                    model.LastName = dr["LastName"].ToString();
                    model.Email = dr["Email"].ToString();
                    model.EmployeeAddress = dr["EmployeeAddress"].ToString();
                    model.Department = dr["Department"].ToString();
                    model.Salary = Convert.ToDecimal(dr["Salary"].ToString());
                    model.JoiningDate = Convert.ToDateTime(dr["JoiningDate"].ToString());
                }
            }
            return model;
        }

        public string UpdateEmployee(Employee employee)
        {
            string msg = "";
            using(SqlConnection con = dBConnectionFactory.CreateConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                int cnt = cmd.ExecuteNonQuery();
                if(cnt > 0)
                {
                    msg = "Employee Updated Successfully.";
                }
                else
                {
                    msg = "Employee not Found";
                }
            }
            return msg;
        }
    }
}
