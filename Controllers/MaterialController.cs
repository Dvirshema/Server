using FinalProj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        [HttpGet]
        public IEnumerable<Material> Get()
        {
            Material m = new Material();
            return m.Read();
        }
        
        [HttpPut("UpdateMatiral")]
        public IActionResult Put(int numMat,int amount)
        {
            //user.Email= id; // because the mail is the primary key
            int m = Material.Update(numMat, amount);
            if (m > 0)
            {
                return Ok(m);
            }
            else
            {
                return NotFound("Something went wrong, Please check the Employee Number");
            }

        }

        [HttpPut("UpdateMatiralAdmin")]
        public IActionResult AdminPut(int numMat, int amount)
        {
            //user.Email= id; // because the mail is the primary key
            int m = Material.AdminUpdate(numMat, amount);
            if (m > 0)
            {
                return Ok(m);
            }
            else
            {
                return NotFound("Something went wrong, Please check the Employee Number");
            }

        }
    }
}
