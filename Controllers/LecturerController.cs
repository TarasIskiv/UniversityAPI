using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/lecturer")]
    public class LecturerController : ControllerBase
    {
        private const string _role = "lecturer";
        private readonly ILecturerService _service;
        private readonly ITokenService _tokenService;
        private readonly IMailSendler _mailSendler;

        public LecturerController(ILecturerService service, ITokenService tokenService, IMailSendler mailSendler)
        {
            _service = service;
            _tokenService = tokenService;
            _mailSendler = mailSendler;
        }
        #region Lecturer
        [HttpPut("modify")]
        public ActionResult ModifyLecturer([FromHeader] string token,[FromBody]ModifyLecturerDTO lecturerDTO)
        {
            //get id from Token
            var lecturerId = _tokenService.GetLoginedUserId(token,_role);
            _service.ModifyLecturer(lecturerDTO, lecturerId);
            return Ok();
        }

        [HttpGet("info")]
        public ActionResult<LecturerDTO> GetLecturerInfo([FromHeader] string token)
        {
            //get id from token
            var lecturerId = _tokenService.GetLoginedUserId(token,_role);
            var lecturer = _service.GetLecturer(lecturerId);
            return Ok(lecturer);
        }
        #endregion

        #region Mark Table
        [HttpPost("add/mark")]
        public ActionResult PostNewMarkForStudent([FromHeader] string token,[FromBody] CreateMarkDTO markDTO)
        {
            _tokenService.ValidateToken(token,_role);
            _service.AddNewMark(markDTO);
            _mailSendler.SendStudentsMarks(markDTO.StudentId, markDTO.Subject, markDTO.StudentId);
            return Ok();
        }
        #endregion

        #region Students
        [HttpGet("students/all")]
        public ActionResult<IEnumerable<StudentDTO>> GetAllStudents([FromHeader] string token)
        {
            _tokenService.ValidateToken(token,_role);
            var students = _service.GetAllStudents();
            return Ok(students);
        }


        [HttpGet("students/{name}")]
        public ActionResult<IEnumerable<StudentDTO>> GetStudentByName([FromHeader] string token, [FromRoute] string name)
        {
            _tokenService.ValidateToken(token,_role);
            var students = _service.GetStudentsByName(name);
            return Ok(students);
        }
        #endregion

        #region Group
        [HttpGet("group/{id}")]
        public ActionResult<GroupDTO> GetGroupById([FromHeader] string token, [FromRoute] int id)
        {
            _tokenService.ValidateToken(token,_role);
            var selectedGroup = _service.GetGroupById(id);
            return Ok(selectedGroup);
        }
        #endregion
    }
}