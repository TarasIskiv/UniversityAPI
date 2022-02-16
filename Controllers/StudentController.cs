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
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }
        #region Student
        [HttpGet("info")]
        public ActionResult<StudentDTO> GetStudentInfo()
        {
            var student = _service.GetStudentInfo(3);
            return Ok(student);
        }

        [HttpPut("modify")]
        public ActionResult ModifyStudent(ModifyStudentDTO studentDTO)
        {
            _service.ModifyStudent(studentDTO, 3);
            return Ok();
        }
        #endregion

        #region MarkTable
        [HttpGet("marks")]
        public ActionResult<IEnumerable<MarkTable>> GetAllMarks() // not correct work
        {
            var marks = _service.GetStudentMarks(3);
            return Ok(marks);
        }
        #endregion

        #region Group
        [HttpGet("group")]
        public ActionResult<GroupDTO> GetStudentsGroup() // not work
        {
            var studentGroup = _service.GetStudentGroup(3);
            return Ok(studentGroup);
        }
        #endregion

        #region Lecturer
        [HttpGet("lecturers/all")]
        public ActionResult<IEnumerable<LecturerDTO>> GetAllLecturers()
        {
            var lecturers =_service.GetAllLecturers();
            return Ok(lecturers);
        }

        [HttpGet("lecturers/{name}")]
        public ActionResult<IEnumerable<LecturerDTO>> GetLecturersByName([FromRoute] string name)
        {
            var lecturers = _service.GetLecturersByName(name);
            return Ok(lecturers);
        }
        #endregion
    }
}