using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DataAccess.Entities
{
    public  class Employee
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address1 { get; set; }
        public decimal PayPerHour { get; set; }

    }

    public class Supervisor : Employee
    {
        public int SupervisorID { get; set; }
        public decimal AnnualSalary { get; set; }
    }

    public class Manager : Employee
    {
        public int ManagerID { get; set;}
        public decimal AnnualSalary { get; set; }
        public decimal MaxExpenseAmount { get; set; }

    }
}
