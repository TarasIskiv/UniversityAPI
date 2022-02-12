using Microsoft.AspNetCore.Mvc;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        /*
            student:
                -remove
            lecturer:
                -remove
        */

        #region Group

        [HttpPost("add/group")]
        public ActionResult CreateNewGroup()
        {
            return Ok();
        }

        [HttpDelete("remove/group/{groupId}")]
        public ActionResult RemoveGroup([FromRoute]int groupId)
        {
            return Ok();
        }

        [HttpPut("modify/group")]
        public ActionResult ModifyGroupName([FromBody] string name)
        {
            return Ok();
        }
        #endregion

        #region Direction
        [HttpPost("add/direction")]
        public ActionResult CreateNewDirection()
        {
            return Ok();
        }

        [HttpDelete("remove/direction/{directionId}")]
        public ActionResult RemoveDirection([FromRoute]int directionId)
        {
            return Ok();
        }

        [HttpPut("modify/direction")]
        public ActionResult ModifyDirectionName([FromBody] string name)
        {
            return Ok();
        }
        #endregion

        #region Student
        [HttpDelete("remove/student/{studentId}")]
        public ActionResult RemoveStudent([FromRoute] int studentId)
        {
            return Ok();
        }
        #endregion

        #region Lecturer
        [HttpDelete("remove/lecturer/{lecturerId}")]
        public ActionResult RemoveLecturer([FromRoute] int lecturerId)
        {
            return Ok();
        }
        #endregion
    }
}
