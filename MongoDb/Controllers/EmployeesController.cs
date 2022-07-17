using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeeService _Employee;
        public EmployeesController(EmployeeService Employee)
        {
            _Employee = Employee;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _Employee.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _Employee.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
