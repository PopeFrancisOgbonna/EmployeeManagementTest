using EmployeeManagementSystem.DataAccess.Entities;
using EmployeeManagementSystem.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DataAccess.Implemetations
{
    public class DbContext: IDbContext
    {
        private readonly IConfiguration _config;
        private readonly string connectionString;
        public DbContext(IConfiguration config) 
        {
            _config = config;
            connectionString = _config["ConnectionStrings:DbContext"];
        }

        public Employee AddEmployee(Employee employee)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                if(conn.State != ConnectionState.Open)
                    conn.Open();

                var query = $"insert into Employees values(@firstName, @lastName,@address,@pay);SELECT SCOPE_IDENTITY()";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@firstName", employee.FirstName);
                command.Parameters.AddWithValue("@lastName", employee.LastName);
                command.Parameters.AddWithValue("@address", employee.Address1);
                command.Parameters.AddWithValue("@pay", employee.PayPerHour);

                var response = (decimal)command.ExecuteScalar();

                if(response > 0)
                {
                    employee.EmployeeID = (int)response;
                    return employee;
                }

                return null;
            }
        }

        public Manager AddManager(Manager employee)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction;
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                transaction = conn.BeginTransaction();

                var query = $"insert into Employees values(@firstName, @lastName,@address,@pay);SELECT SCOPE_IDENTITY()";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@firstName", employee.FirstName);
                command.Parameters.AddWithValue("@lastName", employee.LastName);
                command.Parameters.AddWithValue("@address", employee.Address1);
                command.Parameters.AddWithValue("@pay", employee.PayPerHour);

                var response = (decimal)command.ExecuteScalar();

                if (response > 0)
                {
                    employee.EmployeeID = (int)response;

                    var query2 = $"insert into Managers values(@empId, @anualSalary,@maxexpense);SELECT SCOPE_IDENTITY()";
                    var managerCommand = new SqlCommand(query2, conn);
                    managerCommand.Parameters.AddWithValue("@empId", employee.EmployeeID);
                    managerCommand.Parameters.AddWithValue("@anualSalary", employee.AnnualSalary);
                    managerCommand.Parameters.AddWithValue("@maxexpense", employee.MaxExpenseAmount);

                    var result = (decimal)managerCommand.ExecuteScalar();
                    if (result > 0)
                    {
                        employee.ManagerID = (int)result;
                        transaction.Commit();
                        return employee;
                    }
                    
                }
                transaction.Rollback();

                return null;
            }
        }

        public Supervisor AddSupervisor(Supervisor employee)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var query = $"select * from Employees";
                var command = new SqlCommand(query, conn);
                var dataReader = command.ExecuteReader();
                var employeeToReturn = new List<Employee>();
                while (dataReader.Read())
                {
                    var employee = new Employee();
                        employee.EmployeeID = (int)dataReader["EmployeeID"];
                        employee.FirstName = dataReader["FirstName"].ToString();
                        employee.LastName = dataReader["LastName"].ToString();
                        employee.Address1 = dataReader["Address1"].ToString();
                        employee.PayPerHour = (decimal)dataReader["PayPerHour"];
                     
                    employeeToReturn.Add(employee);
                }
                dataReader.Close();
                return employeeToReturn;
            }
        }

        public IList<Manager> GetAllManager()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var query = $"select * from Managers";
                var command = new SqlCommand(query, conn);
                var dataReader = command.ExecuteReader();
                var employeeToReturn = new List<Manager>();
                while (dataReader.Read())
                {
                    var employee = new Manager();
                    employee.EmployeeID = (int)dataReader["EmployeeID"];
                    employee.FirstName = dataReader["FirstName"].ToString();
                    employee.LastName = dataReader["LastName"].ToString();
                    employee.Address1 = dataReader["Address1"].ToString();
                    employee.PayPerHour = (decimal)dataReader["PayPerHour"];
                    employee.AnnualSalary = (decimal)dataReader["AnnualSalary"];
                    employee.ManagerID = (int)dataReader["ManagerID"];
                    employee.MaxExpenseAmount = (decimal)dataReader["MaxExpenseAmount"];

                    employeeToReturn.Add(employee);
                }
                dataReader.Close();
                return employeeToReturn;
            }
        }

        public IList<Supervisor> GetAllSupervisor()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var query = $"select * from Supervisors";
                var command = new SqlCommand(query, conn);
                var dataReader = command.ExecuteReader();
                var employeeToReturn = new List<Supervisor>();
                while (dataReader.Read())
                {
                    var employee = new Supervisor();
                    employee.EmployeeID = (int)dataReader["EmployeeID"];
                    employee.FirstName = dataReader["FirstName"].ToString();
                    employee.LastName = dataReader["LastName"].ToString();
                    employee.Address1 = dataReader["Address1"].ToString();
                    employee.PayPerHour = (decimal)dataReader["PayPerHour"];
                    employee.AnnualSalary = (decimal)dataReader["AnnualSalary"];
                    employee.SupervisorID = (int)dataReader["SupervisorID"];

                    employeeToReturn.Add(employee);
                }
                dataReader.Close();
                return employeeToReturn;
            }
        }
    }
}
