using FinalProj.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {   
            Employee e = new Employee();
            return e.Read();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{empNum}")]
        public string Get(int empNum)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            int e = employee.Insert();
            if (e > 0)
            {
                return Ok(e);
            }
            else
            {
                return NotFound("Faild to add a new employee");
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{UpdateEmployee}")]
        public IActionResult Put([FromBody] Employee employee)
        {
            //user.Email= id; // because the mail is the primary key
            int e = employee.Update();
            if (e > 0)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound("Something went wrong, Please check the Employee Number");
            }

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{employeeNum}")]
        public void Delete(int employeeNum)
        {
        }
    }
}
