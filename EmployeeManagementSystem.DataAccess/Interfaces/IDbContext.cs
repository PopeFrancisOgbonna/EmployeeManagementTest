using EmployeeManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DataAccess.Interfaces
{
    public interface IDbContext
    {
        Employee AddEmployee(Employee employee);
        Supervisor AddSupervisor(Supervisor employee);
        Manager AddManager(Manager employee);

        IList<Employee> GetAll();
        IList<Supervisor> GetAllSupervisor();
        IList<Manager> GetAllManager();
    }

}
