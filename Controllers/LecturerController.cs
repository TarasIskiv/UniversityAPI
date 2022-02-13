using Microsoft.AspNetCore.Mvc;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/lecturer")]
    public class LecturerController : ControllerBase
    {
        /*
            lecturer:
                -modify data about himself
                -get data about himself
            marktable:
                - add new Mark for selected student
            students:
                -get all
                -get by name
            groups:
                -get group by Id
        */

        #region Lecturer
        [HttpPut("modify")]
        public ActionResult ModifyLecturer()
        {
            return Ok();
        }

        [HttpGet("info")]
        public ActionResult GetLecturerInfo()
        {
            return Ok();
        }
        #endregion

        #region Mark Table
        [HttpPost]
        public ActionResult PostNewMarkForStudent()
        {
            return Ok();
        }
        #endregion

        #region Students
        [HttpGet("students/all")]
        public ActionResult GetAllStudents()
        {
            return Ok();
        }


        [HttpGet("students/{name}")]
        public ActionResult GetStudentByName([FromRoute] string name)
        {
            return Ok();
        }
        #endregion

        #region Group
        [HttpGet("group/{id}")]
        public ActionResult GetGroupById([FromRoute] int id)
        {
            return Ok();
        }
        #endregion
    }
}