using EmployeeManagementSystem.DataAccess.Entities;
using EmployeeManagementSystem.Services.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Interfaces
{
    public interface IEmployeeServices
    {
        IList<EmployeeDetailsDTO> GetAllEmployees();
        Employee AddEmployee(EmployeeDTO employee);
        Supervisor AddSupervisor(Supervisor employee);
        Manager Addmanager(Manager employee);
        
    }
}
