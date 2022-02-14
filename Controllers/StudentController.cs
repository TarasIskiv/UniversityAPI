using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        /*
            student:
                -get info about current student
                -modify data
            markTable:
                get marks of current Student
            group:
                -get current group info
            lecturer:
                -get all lecturers
                -get lecturer by name
        */

        #region Student
        [HttpGet("info")]
        public ActionResult<StudentDTO> GetStudentInfo()
        {
            return Ok();
        }

        [HttpPut("modify")]
        public ActionResult ModifyStudent()
        {
            return Ok();
        }
        #endregion

        #region MarkTable
        [HttpGet]
        public ActionResult<IEnumerable<MarkTable>> GetAllMarks()
        {
            return Ok();
        }
        #endregion

        #region Group
        [HttpGet("group")]
        public ActionResult<GroupDTO> GetStudentsGroup()
        {
            return Ok();
        }
        #endregion

        #region Lecturer
        [HttpGet("lecturers/all")]
        public ActionResult<IEnumerable<LecturerDTO>> GetAllLecturers()
        {
            return Ok();
        }

        [HttpGet("lecturer/{name}")]
        public ActionResult<IEnumerable<LecturerDTO>> GetLecturersByName([FromRoute] string name)
        {
            return Ok();
        }
        #endregion
    }
}