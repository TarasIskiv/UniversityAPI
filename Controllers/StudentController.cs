using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private const string _role = "student";
        private readonly IStudentService _service;
        private readonly ITokenService _tokenService;

        public StudentController(IStudentService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }
        #region Student
        [HttpGet("info")]
        public ActionResult<StudentDTO> GetStudentInfo([FromHeader] string token)
        {
            var studentId = _tokenService.GetLoginedUserId(token,_role);
            var student = _service.GetStudentInfo(studentId);
            return Ok(student);
        }

        [HttpPut("modify")]
        public ActionResult ModifyStudent([FromHeader] string token, [FromBody] ModifyStudentDTO studentDTO)
        {
            var studentId = _tokenService.GetLoginedUserId(token,_role);
            _service.ModifyStudent(studentDTO, studentId);
            return Ok();
        }
        #endregion

        #region MarkTable
        [HttpGet("marks")]
        public ActionResult<IEnumerable<MarkTable>> GetAllMarks([FromHeader] string token)
        {
            var studentId = _tokenService.GetLoginedUserId(token,_role);            
            var marks = _service.GetStudentMarks(studentId);
            return Ok(marks);
        }
        #endregion

        #region Group
        [HttpGet("group")]
        public ActionResult<GroupDTO> GetStudentsGroup([FromHeader] string token) 
        {
            var studentId = _tokenService.GetLoginedUserId(token,_role);                        
            var studentGroup = _service.GetStudentGroup(studentId);
            return Ok(studentGroup);
        }
        #endregion

        #region Lecturer
        [HttpGet("lecturers/all")]
        public ActionResult<IEnumerable<LecturerDTO>> GetAllLecturers([FromHeader] string token)
        {
            _tokenService.ValidateToken(token,_role);
            var lecturers =_service.GetAllLecturers();
            return Ok(lecturers);
        }

        [HttpGet("lecturers/{name}")]
        public ActionResult<IEnumerable<LecturerDTO>> GetLecturersByName([FromHeader] string token,[FromRoute] string name)
        {
            _tokenService.ValidateToken(token,_role);
            var lecturers = _service.GetLecturersByName(name);
            return Ok(lecturers);
        }
        #endregion
    }
}