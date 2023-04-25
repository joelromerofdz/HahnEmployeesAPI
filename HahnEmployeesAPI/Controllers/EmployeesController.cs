using Microsoft.AspNetCore.Mvc;

namespace HahnEmployeesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        [HttpGet(Name = "TestingWelcome")]
        public string Get()
        {
            return "Welcome employees";
        }
    }
}