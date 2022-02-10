using Microsoft.AspNetCore.Mvc;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet("login")]
        public ActionResult Login()
        {
            return Ok();
        }

        [HttpPost("register/student")]
        public ActionResult RegisterStudent()
        {
            return Ok();
        }

        [HttpPost("register/lecturer")]
        public ActionResult RegisterLecturer()
        {
            return Ok();
        }
    }
}