using Backend_Web.Models;
using Backend_Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody]Employee model)
        {
            _employeeService.CreateEmployee(model);
            return Ok(new { message = "Employee created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee model)
        {
            _employeeService.UpdateEmployee(id, model);
            return Ok(new { message = "Employee updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok(new { message = "Employee deleted" });
        }
    }
}
