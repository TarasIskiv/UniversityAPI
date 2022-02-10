using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOS;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _service;

        public HomeController(IHomeService service)
        {
            _service = service;
        }

        [HttpGet("login")]
        public ActionResult Login(LoginUserDTO userDTO)
        {
            var result = _service.login(userDTO);
            return Ok(result.Item2);
        }

        [HttpPost("register/student")]
        public ActionResult RegisterStudent(CreateStudentDTO studentDTO)
        {
            _service.registerStudent(studentDTO);
            return Ok("Registration is success. Check your email address");
        }

        [HttpPost("register/lecturer")]
        public ActionResult RegisterLecturer(CreateLecturerDTO lecturerDTO)
        {
            _service.registerLecturer(lecturerDTO);
            return Ok("Registration is success. Check your email address");
        }
    }
}