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
        private readonly ILecturerService _service;

        public LecturerController(ILecturerService service)
        {
            _service = service;
        }
        #region Lecturer
        [HttpPut("modify")]
        public ActionResult ModifyLecturer(ModifyLecturerDTO lecturerDTO)
        {
            //get id from Token
            _service.ModifyLecturer(lecturerDTO, 1);
            return Ok();
        }

        [HttpGet("info")]
        public ActionResult<LecturerDTO> GetLecturerInfo()
        {
            //get id from token
            var lecturer = _service.GetLecturer(1);
            return Ok(lecturer);
        }
        #endregion

        #region Mark Table
        [HttpPost("add/mark")]
        public ActionResult PostNewMarkForStudent(CreateMarkDTO markDTO)
        {
            _service.AddNewMark(markDTO);
            return Ok();
        }
        #endregion

        #region Students
        [HttpGet("students/all")]
        public ActionResult<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var students = _service.GetAllStudents();
            return Ok(students);
        }


        [HttpGet("students/{name}")]
        public ActionResult<IEnumerable<StudentDTO>> GetStudentByName([FromRoute] string name)
        {
            var students = _service.GetStudentsByName(name);
            return Ok(students);
        }
        #endregion

        #region Group
        [HttpGet("group/{id}")]
        public ActionResult<GroupDTO> GetGroupById([FromRoute] int id)
        {
            var selectedGroup = _service.GetGroupById(id);
            return Ok(selectedGroup);
        }
        #endregion
    }
}