using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProj.Model;
using FinalProj.Model.DAL;

namespace FinalProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {

        // GET
        [HttpGet]
        public IEnumerable<EmployeeRole> Get()
        {
            EmployeeRole r = new EmployeeRole();
            return r.Read();
        }

        // GET
        // [HttpGet("empRoleNum")]
        // public IActionResult GetRoleByNumber(int empRoleNum)
        // {
        //     string empRoleName = EmployeeRole.GETRoleByNum(empRoleNum);
        //    if (empRoleName == null)
        //     {
        //         return NotFound("Not Found");
        //      }
        //      return Ok(empRoleName);
        //  }

        [HttpGet("{num}")]
        public IActionResult GetRoleNameByNum(int num)
        {
            EmployeeRole r = new EmployeeRole();
            string roleName = r.GetRoleNameByNum(num);

            if (roleName == null)
            {
                return NotFound();
            }

            return Ok(roleName);
        }


        // POST 
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeRole empRole)
        {
            int r = empRole.insert();
            if (r > 0)
            {
                return Ok(r);
            }
            else
            {
                return NotFound("something goes wrong check the mail");
            }
        }
    }
}
