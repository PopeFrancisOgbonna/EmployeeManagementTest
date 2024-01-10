using EmployeeManagementSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.DataTransferObject
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage ="First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Address1 is required")]
        public string? Address1 { get; set; }

        public decimal PayPerHour { get; set; }
    }
    public class EmployeeDetailsDTO
    {
        IList<Employee> Employees { get; set; }
        IList<Supervisor> Supervisors { get; set; }
        IList<Manager> Managers { get; set; }
    }
}
