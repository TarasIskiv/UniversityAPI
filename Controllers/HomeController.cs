using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UniversityAPI.DTOS;
using UniversityAPI.Indentity;
using UniversityAPI.JWT;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _service;
        private readonly ITokenService _tokenService;

        public HomeController(IHomeService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        [HttpGet("login")]
        public ActionResult Login(LoginUserDTO userDTO)
        {
            
            var result = _service.login(userDTO);
            var userToken = _tokenService.GetUserToken(result);
           // var val = tokenHandler.ReadJwtToken(loginedUserToken).Claims.ToList();

            return Ok($"Your token : {userToken}");
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