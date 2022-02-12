using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOS;

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
        public ActionResult CreateNewGroup([FromBody] CreateGroupDTO groupDTO)
        {
            return Ok();
        }

        [HttpDelete("remove/group/{groupId}")]
        public ActionResult RemoveGroup([FromRoute]int groupId)
        {
            return Ok();
        }

        [HttpPut("modify/group")]
        public ActionResult ModifyGroupName([FromBody] ModifyGroupDTO groupDTO)
        {
            return Ok();
        }
        #endregion

        #region Direction
        [HttpPost("add/direction")]
        public ActionResult CreateNewDirection([FromBody] CreateDirectionDTO directionDTO)
        {
            return Ok();
        }

        [HttpDelete("remove/direction/{directionId}")]
        public ActionResult RemoveDirection([FromRoute]int directionId)
        {
            return Ok();
        }

        [HttpPut("modify/direction")]
        public ActionResult ModifyDirectionName([FromBody] ModifyDirectionDTO directionDTO)
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
