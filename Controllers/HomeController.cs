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
        private readonly IMailSendler _mailSendler;

        public HomeController(IHomeService service, ITokenService tokenService, IMailSendler mailSendler)
        {
            _service = service;
            _tokenService = tokenService;
            _mailSendler = mailSendler;
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
            _mailSendler.SendMailForNewUsers(studentDTO.FirstName, studentDTO.LastName, studentDTO.Login);
            return Ok("Registration is success.We've sent you email.Check your email address");
        }

        [HttpPost("register/lecturer")]
        public ActionResult RegisterLecturer(CreateLecturerDTO lecturerDTO)
        {
            _service.registerLecturer(lecturerDTO);
            _mailSendler.SendMailForNewUsers(lecturerDTO.FirstName, lecturerDTO.LastName, lecturerDTO.Login);            
            return Ok("Registration is success.We've sent you email.Check your email address");
        }
    }
}