using EmployeeManagementSystem.Services.DataTransferObject;
using EmployeeManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;
        public EmployeeController(IEmployeeServices services) { _services = services; }

        [HttpPost("add-staff")]
        public IActionResult AddNewStaff(EmployeeDTO employee)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = _services.AddEmployee(employee);
            return Ok(new { data = response });
        }

        [HttpGet("employees")]
        public IActionResult GetAllEmployees()
        {

        }
    }
}
