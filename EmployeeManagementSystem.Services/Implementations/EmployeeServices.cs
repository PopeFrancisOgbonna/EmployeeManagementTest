using EmployeeManagementSystem.DataAccess.Entities;
using EmployeeManagementSystem.DataAccess.Interfaces;
using EmployeeManagementSystem.Services.DataTransferObject;
using EmployeeManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Implementations
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IDbContext _dbContext;
        public EmployeeServices(IDbContext context) 
        {
            _dbContext = context;
        }
        public Employee AddEmployee(EmployeeDTO employee)
        {
            var employeeEntity = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address1 = employee.Address1,
                PayPerHour = employee.PayPerHour,
            };
           var result =  _dbContext.AddEmployee(employeeEntity);
            return result;
        }

        public Manager Addmanager(Manager employee)
        {
            var employeeEntity = new Manager
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address1 = employee.Address1,
                PayPerHour = employee.PayPerHour,
                AnnualSalary = employee.AnnualSalary
            };
            var result = _dbContext.AddManager(employeeEntity);
            return result;
        }

        public Supervisor AddSupervisor(Supervisor employee)
        {
            throw new NotImplementedException();
        }

        public IList<EmployeeDetailsDTO> GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
